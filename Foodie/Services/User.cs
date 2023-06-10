using Foodie.Database;
using Foodie.Iservices;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Services
{
    public class User : IUser
    {
        //database 
        private readonly FoodieContext _foodie;
        public User(FoodieContext foodie)
        {
            _foodie =   foodie;

        }
        //get the user by its id
        public Users GetUserById(int id)
        {
            Users? users = _foodie.Users.Where(x => x.Id == id).FirstOrDefault();

            return users;
        }

        //new user registration
        public async Task<ContentResult> NewUserRegistration(Users user)
        {
            //first verifu that email already exist or not

            Users? u = await _foodie.Users.Where(m => m.Email == user.Email).FirstOrDefaultAsync();
            if(u != null) {
                return new ContentResult
                {
                    StatusCode = 400,
                    Content = "{'message' : 'Email Already Exist'}", //  JSON content here
                    ContentType = "application/json"
                };
            }
            else
            {
                Users users = new Users()
                {
                    Name = user.Name,
                    Address = user.Address,
                    Email = user.Email,
                    Password = user.Password,
                    Phone = user.Phone,
                };

                try
                {
                    await _foodie.Users.AddAsync(users);
                    await _foodie.SaveChangesAsync();

                  return new ContentResult
                    {
                        StatusCode = 200,
                        Content = "{'message' : 'User Added succesfully'}", //  JSON content here
                        ContentType = "application/json"
                    };

                }
                catch (Exception)
                {

                    return new ContentResult
                    {
                        StatusCode = 400,
                        Content = "{'message' : 'Something went wrong'}", //  JSON content here
                        ContentType = "application/json"
                    };
                }


            }


        }
        //user sign in
        public int UserSignIn(string Email, string Password)
        {
          //verifying the username and the password
           var isexist =  _foodie.Users.Where(x=>x.Email ==  Email && x.Password == Password).FirstOrDefault();

            if (isexist != null)
                return isexist.Id;
            else
                return 0;
            
        }
    }
}
