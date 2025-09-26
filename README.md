# clear-filter-xamarin-datagrid

A compact sample showing how to apply and clear DataGrid filters in a Xamarin.Forms app. It includes a grid bound to sample data, a single action to clear all filters, and a helper to clear a specific column. Use it as a quick reference for wiring filter logic with MVVM.

## What this sample shows
- Clear all filters across every column with one action
- Clear a single column’s filter by mapping/header name
- Optional default filters on page load and easy reset after refresh
- MVVM-friendly commands for toolbar/menu integration

## Quick start
1) Open FilteringDemo in Visual Studio.
2) Restore NuGet packages.
3) Deploy to Android/iOS (or UWP if available).
4) Add a few filters via the grid UI, then use the “Clear Filters” action to reset.

## How it works
- ItemsSource is an ObservableCollection<T>.
- Commands expose simple entry points:
  - ClearAllFiltersCommand: wipes all column predicates, then refreshes.
  - ClearColumnFilterCommand: targets one column by MappingName/HeaderText.
- Optionally reapply default filters after data reloads.

### Code sketch
```csharp
void ClearAllFilters()
{
    foreach (var c in DataGrid.Columns)
        c.FilterPredicates?.Clear();
    DataGrid.View?.RefreshFilter();
}

void ClearColumnFilter(string columnName)
{
    var c = DataGrid.Columns.FirstOrDefault(x => x.MappingName == columnName || x.HeaderText == columnName);
    if (c == null) return;
    c.FilterPredicates?.Clear();
    DataGrid.View?.RefreshFilter();
}
```

## MVVM and UX notes
- Bind ClearAllFiltersCommand to a toolbar/menu button.
- Disable the clear button when no filters are active for better feedback.
- Prefer a small helper/service to keep filter logic in one place.


