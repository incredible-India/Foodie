using Foodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Database
{
    public class FoodieContext :DbContext
    {
        public FoodieContext(DbContextOptions<FoodieContext> options) : base(options)
        {



        }

        //Foodie User Table

        public DbSet<Users> Users { get; set; }
    }
}
