namespace PetBook.Infrastructure.Repository
{
    public interface IRepository
    {
        void SaveFile(string content, string reportName);
    }
}