namespace Foodie.Authentication.IAuth
{
    public interface IAuth
    {
        public string GenerateToken(Foodie.Models.Users users);
    }
}
