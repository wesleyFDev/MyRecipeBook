namespace MyRecipeBook.domain.Security.PasswordHasher
{
    internal interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
    