namespace IkeaAssignmentCore.Infraestructure.Persistance.common
{
    using Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Threading.Tasks;

    public class TableService
    {
        private readonly AppConfiguration _configuration;

        public TableService()
        {
            _configuration = new AppConfiguration();
        }

        public CloudTable GetTableReference(string tableName, bool createIfNotExists = false)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(_configuration.StorageConnectionString);
            CloudTableClient client = account.CreateCloudTableClient();

            var table = client.GetTableReference(tableName);

            if (createIfNotExists)
            {
                table.CreateIfNotExists();
            }

            return table;
        }

        public async Task AddObject<T>(CloudTable table, T value) where T : ITableEntity
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            TableOperation operation = TableOperation.InsertOrReplace(value);
            await table.ExecuteAsync(operation);
        }
    }
}
