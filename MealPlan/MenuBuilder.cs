/******************************************************************************
 * 
 *  MenuBuilder.cs
 *  Copyright: Chris Aiken, 2017
 *  License: LGPL
 * 
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace MealPlan
{
    /// <summary>
    /// Randomly generated menu container with some editing functions
    /// </summary>
    public class MenuBuilder {
        
        // Collection of all known recipes/meals
        private List<Meal> pool;

        // The current menu
        private List<Meal> menu;

        // Parallel collection for menu, allows specific elements
        // to be pinned - pinned items are not replaced in a reshuffle
        private List<bool> pins;

        // Random number generator
        private Random random;

        /// <summary>
        /// Constructs a new <c>MenuBuilder</c> object with an empty menu
        /// </summary>
        /// <param name="mealPool">The pool of available meal choices</param>
        /// <exception cref="ArgumentNullException"><c>mealPool</c> is null.</exception>
        public MenuBuilder(List<Meal> mealPool) {
            if (mealPool == null) {
                throw new ArgumentNullException( "mealPool", 
                    "Argument may not be null." );
            }
            pool = mealPool;
            random = new Random();
        }

        /// <summary>
        /// Constructs a new <c>MenuBuilder</c> object and generates a menu
        /// </summary>
        /// <param name="mealPool">The pool of available meal choices</param>
        /// <param name="numMeals">The number of meals in the menu</param>
        /// <exception cref="ArgumentNullException"><c>mealPool</c> is null.</exception>
        public MenuBuilder(List<Meal> mealPool, int numMeals) {
            if (mealPool == null) {
                throw new ArgumentNullException( "mealPool",
                    "Argument may not be null." );
            }
            pool = mealPool;
            random = new Random();
            GetNewRandomMenu( numMeals );
        }

        /// <summary>
        /// Gets the average prep time rating for this collection of meals
        /// </summary>
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

        /// <summary>
        /// Gets the average cost rating for this collection of meals
        /// </summary>
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

        /// <summary>
        /// Gets the average naughtiness rating for this collection of meals
        /// </summary>
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

        /// <summary>
        /// Gets the average heaviness rating for this collection of meals
        /// </summary>
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

        /// <summary>
        /// Gets the total number of leftover-producing meals in the collection
        /// </summary>
        public int LeftoversCount
        {
            get
            {
                if (menu == null) {
                    return 0;
                }
                int sum = 0;
                foreach (var meal in menu) {
                    if (meal.ProducesLeftovers) sum++;
                }
                return sum;
            }
        }

        /// <summary>
        /// Gets the number of meals in the current menu
        /// </summary>
        public int Count
        {
            get { return menu?.Count ?? 0; }
        }

        /// <summary>
        /// Gets the pool of available <c>Meal</c> choices
        /// </summary>
        public List<Meal> MealPool
        {
            get { return pool; }
        }

        /// <summary>
        /// Identifies whether a particular <c>Meal</c> is pinned
        /// </summary>
        /// <param name="index">The index of the <c>Meal</c> to check</param>
        /// <returns><c>true</c> if pinned, <c>false</c> otherwise</returns>
        public bool IsPinned(int index) {
            if (index < 0 || pins == null || index >= pins.Count) {
                return false;
            }
            return pins[index];
        }

        /// <summary>
        /// Accesses the <c>Meal</c> at the specified index
        /// </summary>
        /// <param name="index">The index to retrieve</param>
        /// <returns>The requested <c>Meal</c>, or <c>null</c> if index is invalid</returns>
        public Meal GetMeal(int index) {
            if (index < 0 || menu == null || index >= menu.Count) {
                return null;
            }
            return menu[index];
        }

        /// <summary>
        /// Provides subscript access to the meals in the menu
        /// </summary>
        /// <param name="i">The index to retrieve</param>
        /// <returns>The requested <c>Meal</c>, or null if i is invalid</returns>
        public Meal this[int i]
        {
            get { return GetMeal( i ); }
        }

        /// <summary>
        /// Pins or unpins the <c>Meal</c> at the specified index
        /// </summary>
        /// <param name="index">The index of the meal to pin</param>
        /// <returns>A bool indicating the new pinned state</returns>
        public bool TogglePin(int index) {
            if (index < 0 || pins == null || index >= pins.Count) {
                return false;
            }
            pins[index] = !pins[index];
            return pins[index];
        }

        /// <summary>
        /// Generates a random menu plan. Clears any prior menu.
        /// </summary>
        /// <param name="numMeals">The number of meals to include</param>
        /// <exception cref="InvalidOperationException">The selection pool is null, empty, or too small for the requested operation.</exception>
        public void GetNewRandomMenu(int numMeals) {
            if (pool == null || pool.Count == 0 || pool.Count < numMeals) {
                throw new InvalidOperationException(
                    "Meal pool is null, empty, or smaller than menu" );
            }
            menu = new List<Meal>(numMeals);
            pins = new List<bool>(numMeals);
            for (int i = 0; i < numMeals; i++) {
                int r = -1;
                while (r == -1 || menu.Contains(pool[r])) {
                    r = random.Next( 0, pool.Count );
                }
                menu.Add( pool[r] );
                pins.Add( false );
            }
        }

        /// <summary>
        /// Replaces all unpinned meals in the menu with new random selections.
        /// </summary>
        /// <exception cref="InvalidOperationException">The selection pool is null, empty, or too small for the requested operation.</exception>
        public void ReshuffleMenu() {
            if (menu == null) return;
            if (pool == null || pool.Count == 0 || pool.Count < menu.Count) {
                throw new InvalidOperationException(
                    "Meal pool is null, empty, or smaller than menu" );
            }
            for (int i = 0; i < menu.Count; i++) {
                if (!pins[i]) {
                    var previous = menu[i];
                    int r = -1;
                    while (r == -1 || menu.Contains( pool[r] )) {
                        r = random.Next( pool.Count );
                    }
                    menu[i] = pool[r];
                }
            }
        }

        /// <summary>
        /// Replaces the specified <c>Meal</c> with a new specified <c>Meal</c>. Ignores pins
        /// </summary>
        /// <param name="indexToReplace">The index of the meal to replace</param>
        /// <param name="newMeal">The replacement <c>Meal</c></param>
        public void ReplaceMeal(int indexToReplace, Meal newMeal) {
            if (indexToReplace < 0 || menu == null 
                || indexToReplace >= menu.Count) {
                return;
            }
            menu[indexToReplace] = newMeal;
        }

        /// <summary>
        /// Adds an additional random <c>Meal</c> to the menu
        /// </summary>
        /// <exception cref="InvalidOperationException">The selection pool is null, empty, or too small for the requested operation.</exception>
        public void AddAnotherMeal() {
            if (pool == null || pool.Count == 0 
                || pool.Count < (menu.Count + 1)) {
                throw new InvalidOperationException(
                    "Meal pool is null, empty, or smaller than menu" );
            }
            int r = -1;
            while (r == -1 || menu.Contains( pool[r] )) {
                r = random.Next( pool.Count );
            }
            menu.Add( pool[r] );
            pins.Add( false );
        }
    }
}
