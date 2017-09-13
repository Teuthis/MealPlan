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
        Random random;


        public double AveragePrepTime
        {
            get
            {
                if (menu == null || menu.Count == 0) {
                    return 0.0;
                }
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
                if (menu == null || menu.Count == 0) {
                    return 0.0;
                }
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
                if (menu == null || menu.Count == 0) {
                    return 0.0;
                }
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
                if (menu == null || menu.Count == 0) {
                    return 0.0;
                }
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

        public bool IsPinned(int index) {
            if (index < 0 || index >= pins.Count) {
                return false;
            }
            return pins[index];
        }

        public Recipe GetMeal(int index) {
            if (index < 0 || index >= menu.Count) {
                return null;
            }
            return menu[index];
        }

        public void GetNewRandomMenu(int numMeals) {
            menu = new List<Recipe>(numMeals);
            pins = new List<bool>(numMeals);
            for (int i = 0; i < numMeals; i++) {
                int r = -1;
                while (r == -1 || menu.Contains(pool[r])) {
                    r = random.Next( pool.Count - 1 );
                }
                menu.Add( pool[r] );
                pins.Add( false );
            }
        }

        public void ReshuffleMenu() {
            for (int i = 0; i < menu.Count; i++) {
                if (!pins[i]) {
                    var previous = menu[i];
                    int r = -1;
                    while (r == -1 || menu.Contains( pool[r] )) {
                        r = random.Next( pool.Count - 1 );
                    }

                }
            }
        }
    }
}
