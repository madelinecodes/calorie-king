using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieKing.Models
{
    public class MealItem
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public DateTime Date { get; set; }
    }
}
