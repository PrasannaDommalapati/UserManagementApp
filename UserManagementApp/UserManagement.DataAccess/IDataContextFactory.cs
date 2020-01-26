namespace UserManagement.DataAccess
{
    public interface IDataContextFactory
    {
        IDataContext Create();
    }
}
