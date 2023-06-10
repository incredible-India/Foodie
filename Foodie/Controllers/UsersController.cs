using Foodie.Iservices;
using Foodie.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Controllers
{   /// <summary>
    ///Authentication Related user login, logout,new user resistration 
    /// </summary>
    [Route("api/user/service/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //services
        private readonly IUser _user;


        //constructor
        public UsersController(IUser user)
        {
           _user = user; 
        }


        //controllers

        #region GET

        //getting the user by its id
        [HttpGet("user/{id}",Name ="UserByID")]
        public IActionResult GetUserById([FromRoute] int id)
        {

            //if id is inccorrect
        
                var response = new ContentResult
                {
                    StatusCode = 404,
                    Content = "{'message' : 'No user Found'}", //  JSON content here
                    ContentType = "application/json"
                };
           Users u = _user.GetUserById(id);
            if(id <=0 || u==null)
            {
                return response;
            }
           else
            return Ok(u);
        
            
         
            
        }
        #endregion
        #region POST
        //user signin
        [HttpPost("signin")]
        [ProducesResponseType(200)] 
        public IActionResult signIn([FromForm] string Email, [FromForm] string Password )
        {

            int user = _user.UserSignIn(Email, Password);
            //redirecting to getuserbyid controller
            return RedirectToAction("GetUserById", new { id = user});
        }
        #endregion

        #region PUT
        ///New user registration
        [HttpPut("newuser")]
        [ProducesResponseType(200)]
        public async Task<ContentResult> NewUser([FromBody] Users user) {
            //adding the user information in database return true on success or false for the failure
            ContentResult isRegistered = await _user.NewUserRegistration(user);
            return isRegistered;
            
        }

        

        #endregion 

    }


}