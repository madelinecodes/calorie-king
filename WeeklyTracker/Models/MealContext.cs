using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CalorieKing.Models
{
    public class MealContext : DbContext
    {
        public MealContext(DbContextOptions<MealContext> options)
            : base(options)
        {

        }

        public DbSet<MealItem> MealItems { get; set; }

    }
}
