using System;
using System.Data.SqlTypes;

namespace Experiments.CanIHazT4Sql
{
    partial class ParameterizeAllTheThingsDmlExample
    {
        public ParameterizeAllTheThingsDmlExample(string databaseName, string schemaName, string tableName, SqlDateTime cutoffDate)
        {
            DatabaseName = databaseName;
            SchemaName = schemaName;
            TableName = tableName;
            CutoffDate = cutoffDate;
        }

        public string DatabaseName { get; }
        public string SchemaName { get; }
        public string TableName { get; }
        public SqlDateTime CutoffDate { get; }
    }
}
