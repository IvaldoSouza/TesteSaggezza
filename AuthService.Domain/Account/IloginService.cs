namespace AuthService.Domain.Account
{
    public interface IloginService
    {
        Task<bool> Authenticate(string email, string password);
    }
}
