/*
ParameterizeAllTheThingsDmlExample.sql
<#@ template language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
*/

DELETE
FROM [<#= DatabaseName #>].[<#= SchemaName #>].[<#= TableName #>]
WHERE LastUpdated < @CutoffDate
