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

        public async Task FillWithSampleData(CloudTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            PhotoEntity[] photos = new PhotoEntity[] {
                new PhotoEntity()
                {
                    PartitionKey = "Jorge Puerta",
                    RowKey = "979-8618555777",
                    Id = "The Secret Adversary",
                    Width = 100,
                    Height = 100,
                    Downloads = 100,
                    Change = 100,
                    Percentage = 100,
                    UserId = "1234",
                    UserName = "jorgepuerta",

                },
                new PhotoEntity()
                {
                    PartitionKey = "Diana Orozco",
                    RowKey = "979-8618555778",
                    Id = "The Secret Adversary",
                    Width = 900,
                    Height = 900,
                    Downloads = 100,
                    Change = 100,
                    Percentage = 100,
                    UserId = "9234",
                    UserName = "dianaorozco",
                },
            };

            foreach (var photo in photos)
            {
                await AddObject(table, photo);
            }
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
