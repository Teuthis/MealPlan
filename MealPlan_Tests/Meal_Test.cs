
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MealPlan;

namespace MealPlan_Tests
{
    [TestClass]
    public class Meal_Test
    {
        [TestMethod]
        public void PrepValueHighClamp()
        {
            Meal meal = new Meal();
            meal.PreparationTime = 43;
            int expected = 5;
            int actual = meal.PreparationTime;
            Assert.AreEqual( expected, actual );
        }
    }
}
