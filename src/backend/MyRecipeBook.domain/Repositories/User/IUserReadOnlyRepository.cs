namespace MyRecipeBook.domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> ExistActiveUserWithEmail(string email);
    }
}
