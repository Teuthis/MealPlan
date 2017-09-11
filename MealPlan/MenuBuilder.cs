using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlan
{
    class MenuBuilder
    {
        List<Recipe> pool;
        List<Recipe> menu;
        List<bool> pins;


        public double AveragePrepTime
        {
            get
            {
                double sum = 0.0;
                foreach (var meal in menu) {
                    sum += meal.PreparationTime;
                }
                return sum / menu.Count;
            }
        }

        public double AverageCost
        {
            get
            {
                double sum = 0.0;
                foreach (var meal in menu) {
                    sum += meal.Cost;
                }
                return sum / menu.Count;
            }
        }

        public double AverageNaughtiness
        {
            get
            {
                double sum = 0.0;
                foreach (var meal in menu) {
                    sum += meal.Naughtiness;
                }
                return sum / menu.Count;
            }
        }

        public double AverageHeaviness
        {
            get
            {
                double sum = 0.0;
                foreach (var meal in menu) {
                    sum += meal.Heaviness;
                }
                return sum / menu.Count;
            }
        }

        public int LeftoversCount
        {
            get
            {
                int sum = 0;
                foreach (var meal in menu) {
                    if (meal.ProducesLeftovers) sum++;
                }
                return sum;
            }
        }
    }
}
