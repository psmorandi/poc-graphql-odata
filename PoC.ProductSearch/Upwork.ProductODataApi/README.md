Links:
- https://github.com/hassanhabib/ODataWithEDMAndBlazor
- https://github.com/hassanhabib/ODataDemo
- https://devblogs.microsoft.com/odata/experimenting-with-odata-in-asp-net-core-3-1/
- https://dotnetcoretutorials.com/2020/03/15/fixing-json-self-referencing-loop-exceptions/
- https://github.com/OData/WebApi/issues/157

Sample query: https://localhost:5001/odata/Products?$select=Name,Price&$expand=Category($select=name),Color($select=Name)&$orderby=Price%20desc