namespace IkeaAssignmentCore.Infraestructure.Persistance.common
{
    using IkeaAssignmentCore.Application.Common.ExtensionMethods;
    using Microsoft.Azure.Cosmos.Table;
    using System.Threading.Tasks;

    public class TableService
    {
        private readonly AppConfiguration _configuration;

        public TableService()
        {
            _configuration = new AppConfiguration();
        }

        public CloudTable GetTableReference(string tableName)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(_configuration.StorageConnectionString());
            CloudTableClient client = account.CreateCloudTableClient();

            var table = client.GetTableReference(tableName);
            table.CreateIfNotExists();

            return table;
        }

        public async Task AddObject<T>(CloudTable table, T value) where T : ITableEntity
        {
            table.ThrowIfArgumentIsNull(nameof(table) + " is null");

            TableOperation operation = TableOperation.InsertOrReplace(value);
            await table.ExecuteAsync(operation);
        }
    }
}
