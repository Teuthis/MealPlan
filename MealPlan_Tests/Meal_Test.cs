
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MealPlan;

namespace MealPlan_Tests
{
    [TestClass]
    public class Meal_Test
    {
        [TestMethod]
        [Timeout( 2 )]
        public void PrepValueHighClamp()
        {
            Meal meal = new Meal();
            meal.PreparationTime = 43;
            int expected = 5;
            int actual = meal.PreparationTime;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void PrepValueLowClamp() {
            Meal meal = new Meal();
            meal.PreparationTime = -3;
            int expected = 1;
            int actual = meal.PreparationTime;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void PrepValueInRange() {
            Meal meal = new Meal();
            meal.PreparationTime = 1;
            int expected = 1;
            int actual = meal.PreparationTime;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void CostValueHighClamp() {
            Meal meal = new Meal();
            meal.Cost = 43;
            int expected = 5;
            int actual = meal.Cost;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void CostValueLowClamp() {
            Meal meal = new Meal();
            meal.Cost = -3;
            int expected = 1;
            int actual = meal.Cost;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void CostValueInRange() {
            Meal meal = new Meal();
            meal.Cost = 1;
            int expected = 1;
            int actual = meal.Cost;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void NaughtyValueHighClamp() {
            Meal meal = new Meal();
            meal.Naughtiness = 43;
            int expected = 5;
            int actual = meal.Naughtiness;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void NaughtyValueLowClamp() {
            Meal meal = new Meal();
            meal.Naughtiness = -3;
            int expected = 1;
            int actual = meal.Naughtiness;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void NaughtyValueInRange() {
            Meal meal = new Meal();
            meal.Naughtiness = 1;
            int expected = 1;
            int actual = meal.Naughtiness;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void HeavyValueHighClamp() {
            Meal meal = new Meal();
            meal.Heaviness = 43;
            int expected = 5;
            int actual = meal.Heaviness;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void HeavyValueLowClamp() {
            Meal meal = new Meal();
            meal.Heaviness = -3;
            int expected = 1;
            int actual = meal.Heaviness;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void HeavyValueInRange() {
            Meal meal = new Meal();
            meal.Heaviness = 1;
            int expected = 1;
            int actual = meal.Heaviness;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [Timeout( 2 )]
        public void ConstructorRangeCorrectness() {
            Meal meal = new Meal( "Test meal", "", -3, 43, 19, 0, false );
            int expectedCost = 1;
            int expectedPrep = 5;
            int expectedNaughty = 5;
            int expectedHeavy = 1;
            Assert.AreEqual( expectedCost, meal.Cost );
            Assert.AreEqual( expectedPrep, meal.PreparationTime );
            Assert.AreEqual( expectedNaughty, meal.Naughtiness );
            Assert.AreEqual( expectedHeavy, meal.Heaviness );
        }
    }
}
