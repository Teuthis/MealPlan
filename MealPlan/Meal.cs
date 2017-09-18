/******************************************************************************
 * 
 *  Meal.cs
 *  Copyright: Chris Aiken, 2017
 *  License: LGPL
 * 
 *****************************************************************************/ 

using System;

namespace MealPlan
{
    /// <summary>
    /// Represents a roughly complete meal with a set of ratings describing
    /// cost, prep time, etc
    /// </summary>
    class Meal
    {
        // The name of the meal
        private string name;
        
        // URL to the recipe(s) to make the meal
        private string link;

        // Relative 1-5 rating of preparation time
        private int prepTime;

        // Relative 1-5 rating of calories, fat, cheesy goodness, etc
        private int naughtiness;

        // Relative 1-5 rating of ingredient cost
        private int cost;

        // Relative 1-5 rating of how heavy/filling/rich the meal is
        private int heaviness;

        // Indicates whether the meal usually produces useful leftovers
        private bool leftovers;

        /// <summary>
        /// Constructs a new Meal object
        /// </summary>
        /// <param name="name">The name/identifier of the meal</param>
        /// <param name="recipeUrl">Link to the recipe(s) to make meal</param>
        /// <param name="cost">Ingredient cost relative rating (1 = cheap, 5 = expensive)</param>
        /// <param name="prep">Prep time relative rating (1 = quick, 5 = all damn day)</param>
        /// <param name="naughty">Naughtiness relative rating (1 = kale, 5 = mac & cheese)</param>
        /// <param name="heavy">Heaviness relative rating (1 = light summer snack, 5 = thanksgiving feast)</param>
        /// <param name="hasLeftovers">True if the meal usually produces useful leftovers, false otherwise</param>
        public Meal(string name, string recipeUrl, int cost, int prep, 
            int naughty, int heavy, bool hasLeftovers) {
            this.name = name;
            this.link = recipeUrl;
            this.cost = cost;
            this.prepTime = prep;
            this.naughtiness = naughty;
            this.heaviness = heavy;
            this.leftovers = hasLeftovers;
        }

        /// <summary>
        /// Constructs a new Meal object
        /// </summary>
        public Meal() : this("New Meal", "", 3, 3, 3, 3, false) {

        }

        /// <summary>
        /// Constructs a new Meal object
        /// </summary>
        /// <param name="name">The name/identifier of the meal</param>
        public Meal(string name) : this(name, "", 3, 3, 3, 3, false) {

        }

        /// <summary>
        /// Constructs a new Meal object
        /// </summary>
        /// <param name="name">The name/identifier of the meal</param>
        /// <param name="recipeUrl">Link to the recipe(s) to make meal</param>
        public Meal(string name, string recipeUrl) 
            : this(name, recipeUrl, 3, 3, 3, 3, false) {

        }

        /// <summary>
        /// Gets or sets the identifying name of the meal
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        /// <summary>
        /// Gets or sets the URL(s) to the meal recipes
        /// </summary>
        public string RecipeLink
        {
            get { return link; }
            set { link = value; }
        }

        /// <summary>
        /// Gets or sets the preparation time rating (1-5)
        /// 1 = quick, 5 = all damn day
        /// </summary>
        public int PreparationTime
        {
            get { return prepTime; }
            set { prepTime = Math.Min( Math.Max( 1, value ), 5 ); }
        }

        /// <summary>
        /// Gets or sets the naughtiness rating (1-5)
        /// 1 = kale, 5 = mac & cheese w/ bacon
        /// </summary>
        public int Naughtiness
        {
            get { return naughtiness; }
            set { naughtiness = Math.Min( Math.Max( 1, value ), 5 ); }
        }

        /// <summary>
        /// Gets or sets the ingredient cost rating (1-5)
        /// 1 = very cheap, 5 = very expensive
        /// </summary>
        public int Cost
        {
            get { return cost; }
            set { cost = Math.Min( Math.Max( 1, value ), 5 ); }
        }

        /// <summary>
        /// Gets or sets the heaviness rating (1-5)
        /// 1 = light summer snack, 5 = thanksgiving feast
        /// </summary>
        public int Heaviness
        {
            get { return heaviness; }
            set { heaviness = Math.Min( Math.Max( 1, value ), 5 ); }
        }

        /// <summary>
        /// Gets or sets the leftovers flag
        /// </summary>
        public bool ProducesLeftovers
        {
            get { return leftovers; }
            set { leftovers = value; }
        }

    }
}
