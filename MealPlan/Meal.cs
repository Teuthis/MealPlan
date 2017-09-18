using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlan
{
    class Meal
    {
        private string name;
        private string link;
        private int prepTime;
        private int naughtiness;
        private int cost;
        private int heaviness;
        private bool leftovers;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string RecipeLink
        {
            get { return link; }
            set { link = value; }
        }

        public int PreparationTime
        {
            get { return prepTime; }
            set { prepTime = Math.Min( Math.Max( 1, value ), 5 ); }
        }

        public int Naughtiness
        {
            get { return naughtiness; }
            set { naughtiness = Math.Min( Math.Max( 1, value ), 5 ); }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = Math.Min( Math.Max( 1, value ), 5 ); }
        }

        public int Heaviness
        {
            get { return heaviness; }
            set { heaviness = Math.Min( Math.Max( 1, value ), 5 ); }
        }

        public bool ProducesLeftovers
        {
            get { return leftovers; }
            set { leftovers = value; }
        }

    }
}
