using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MealPlan;
using System.Collections.Generic;

namespace MealPlan_Tests
{
    [TestClass]
    public class MenuBuilder_Test
    {

        private List<Meal> GenerateTestPool(int poolsize) {
            List<Meal> pool = new List<Meal>(poolsize);

            for (int i = 0; i < poolsize; i++) {
                pool.Add( new Meal(
                    "Test Meal #" + i,
                    "http://somerecipesite.com/" + i,
                    ( i % 5 ) + 1,
                    ( ( 2 * i ) % 5 ) + 1,
                    ( ( 3 * i ) % 5 ) + 1,
                    ( ( 7 * i ) % 5 ) + 1,
                    ( i % 3 ) == 0 ? true : false ) );
            }

            return pool;
        }

        [TestMethod]
        public void RandomMenuSimpleGeneration() {
            var mb = new MenuBuilder( GenerateTestPool( 15 ), 7 );
            int expected = 7;
            Assert.AreEqual( expected, mb.Count );
        }
    }
}
