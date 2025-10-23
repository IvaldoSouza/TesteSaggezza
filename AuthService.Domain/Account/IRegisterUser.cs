namespace AuthService.Domain.Account
{
    public interface IRegisterUser
    {
        Task<bool> RegisterUser(string email, string password);
    }
}
