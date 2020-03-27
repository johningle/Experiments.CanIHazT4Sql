using System.Data.SqlTypes;
using Xunit;

namespace Experiments.CanIHazT4Sql
{
    public class T4TextTemplateSqlTests
    {
        [Fact]
        public void Sql_Query_File_Using_T4_Correctly_Transforms_At_Runtime()
        {
            var dbName = "Some_Database";

            #region Expectd Sql
            // looks ugly here, but exact whitespace reproduction is crucial to the assert
            var expected = $@"/*
ParameterizedDatabaseNameQueryExample.sql
*/

SELECT TOP(10) *
FROM [{dbName}].[dbo].[Some_Table]
";
            #endregion

            var dbQueryTemplate = new ParameterizedDatabaseNameQueryExample(dbName);
            var actual = dbQueryTemplate.TransformText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sql_Dml_File_Using_T4_Correctly_Transforms_At_Runtime()
        {
            var dbName = "Some_Database";
            var schemaName = "Some_Schema";
            var tableName = "Some_Table";
            var cutoffDate = new SqlDateTime(1999, 12, 31);

            #region Expected Sql
            var expected = $@"/*
ParameterizeAllTheThingsDmlExample.sql
*/

DELETE
FROM [{dbName}].[{schemaName}].[{tableName}]
WHERE LastUpdated < '{cutoffDate}'
";
            #endregion

            var dbQueryTemplate = new ParameterizeAllTheThingsDmlExample(dbName, schemaName, tableName, cutoffDate);
            var actual = dbQueryTemplate.TransformText();
            Assert.Equal(expected, actual);
        }
    }
}
