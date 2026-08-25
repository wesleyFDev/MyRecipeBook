namespace MyRecipeBook.domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
