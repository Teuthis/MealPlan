﻿using System;
using System.Collections.Generic;

namespace MealPlan
{
    /// <summary>
    /// Randomly generated menu container with some editing functions
    /// </summary>
    class MenuBuilder {
        
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
        /// Constructs a new MenuBuilder object with an empty menu
        /// </summary>
        /// <param name="mealPool">The pool of available meal choices</param>
        public MenuBuilder(List<Meal> mealPool) {
            pool = mealPool;
            random = new Random();
        }

        /// <summary>
        /// Constructs a new MenuBuilder object and generates a menu
        /// </summary>
        /// <param name="mealPool">The pool of available meal choices</param>
        /// <param name="numMeals">The number of meals in the menu</param>
        public MenuBuilder(List<Meal> mealPool, int numMeals) {
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
        /// Gets the pool of available meal choices
        /// </summary>
        public List<Meal> MealPool
        {
            get { return pool; }
        }

        /// <summary>
        /// Identifies whether a particular meal is pinned
        /// </summary>
        /// <param name="index">The index of the meal to check</param>
        /// <returns>True if pinned, false otherwise</returns>
        public bool IsPinned(int index) {
            if (index < 0 || pins == null || index >= pins.Count) {
                return false;
            }
            return pins[index];
        }

        /// <summary>
        /// Accesses the meal at the specified index
        /// </summary>
        /// <param name="index">The index to retrieve</param>
        /// <returns>The requested meal, or null if index is invalid</returns>
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
        /// <returns>The requested meal, or null if i is invalid</returns>
        public Meal this[int i]
        {
            get { return GetMeal( i ); }
        }

        /// <summary>
        /// Pins or unpins the meal at the specified index
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
        public void GetNewRandomMenu(int numMeals) {
            menu = new List<Meal>(numMeals);
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

        /// <summary>
        /// Replaces all unpinned meals in the menu with new random selections.
        /// </summary>
        public void ReshuffleMenu() {
            if (menu == null) return;
            for (int i = 0; i < menu.Count; i++) {
                if (!pins[i]) {
                    var previous = menu[i];
                    int r = -1;
                    while (r == -1 || menu.Contains( pool[r] )) {
                        r = random.Next( pool.Count - 1 );
                    }
                    menu[i] = pool[r];
                }
            }
        }

        /// <summary>
        /// Replaces the specified meal with a new specified meal. Ignores pins
        /// </summary>
        /// <param name="indexToReplace">The index of the meal to replace</param>
        /// <param name="newMeal">The pool index of the new meal</param>
        public void ReplaceMeal(int indexToReplace, int newMeal) {
            if (indexToReplace < 0 || menu == null 
                || indexToReplace >= menu.Count) {
                return;
            }
            if (newMeal < 0 || newMeal >= pool.Count) {
                return;
            }
            menu[indexToReplace] = pool[newMeal];
        }

        /// <summary>
        /// Adds an additional random meal to the menu
        /// </summary>
        public void AddAnotherMeal() {
            int r = -1;
            while (r == -1 || menu.Contains( pool[r] )) {
                r = random.Next( pool.Count - 1 );
            }
            menu.Add( pool[r] );
            pins.Add( false );
        }
    }
}
