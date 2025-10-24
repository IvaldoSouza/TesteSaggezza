namespace AuthService.Domain.Account
{
    public interface IRegisterUser
    {
        Task<bool> RegisterUser(string userName, string phoneNumber, string email, string password);
    }
}
