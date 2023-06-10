using Foodie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Iservices
{
    public interface IUser
    {
        //adding new user
        public Task<ContentResult> NewUserRegistration(Users user);

        //user signIn
        public int UserSignIn(string Email,string Password);

        //get user by id

        public Users GetUserById(int id);
    }
}
