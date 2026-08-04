# Search ranking tie-break surfaces the core entity first

Spec #12 (parent) said search ties break "queries-before-commands, then module, then name" — but
under that exact ordering, `monitor_api_search "part"` ranks the Inventory `Parts` query at
0-based position 19 (after 19 compound names like `PartConfigurationPresets`, `PartActivities`,
`PartCodes` that share the prefix), outside the default `limit` 10. That fails issue #13's
acceptance criterion that `monitor_api_search "part"` returns the Inventory Parts query.

So `CatalogIndex.Search` orders ties: exact > prefix > substring, then queries before commands,
then **shorter name first**, then `ApiCategory` order, then name ordinal. Shorter names are the
core entities — `Parts` for `"part"`, `Orders` for `"order"` — and surface before compound names
that merely share the prefix. Implemented in `src/MonitorErpMcp.Catalog/Search/CatalogIndex.cs`;
this is a deliberate override of #12's "then module, then name" tie-break, not a bug.
