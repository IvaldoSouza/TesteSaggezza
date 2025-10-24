namespace AuthService.Domain.Account
{
    public interface IAuthenticate : IloginService, IRegisterUser, IlogoutService
    {
    }
}
