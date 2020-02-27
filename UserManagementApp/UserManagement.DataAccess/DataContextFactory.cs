using Microsoft.Extensions.Options;

namespace UserManagement.DataAccess
{
    public class DataContextFactory : IDataContextFactory
    {
        public string ConnectionString { get; }

        public DataContextFactory(IOptions<DataContextConfiguration> configuration) : this(configuration.Value) { }

        public DataContextFactory(DataContextConfiguration dataContextConfiguration)
        {
            ConnectionString = dataContextConfiguration.SQLConnectionString;
        }

        public IDataContext Create() => new DataContext(ConnectionString);
    }
}