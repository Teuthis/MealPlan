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
        [Timeout( 30 )]
        public void RandomMenuSimpleGeneration() {
            var mb = new MenuBuilder( GenerateTestPool( 15 ), 7 );
            int expected = 7;
            Assert.AreEqual( expected, mb.Count );
        }

        [TestMethod]
        [Timeout( 30 )]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsOnEmptyPool() {
            var mb = new MenuBuilder( GenerateTestPool( 0 ) );
            mb.GetNewRandomMenu( 5 );
        }

        [TestMethod]
        [Timeout( 30 )]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsOnNullPool() {
            var mb = new MenuBuilder( null );
        }

        [TestMethod]
        [Timeout( 30 )]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsOnLargerThanPool() {
            var mb = new MenuBuilder( GenerateTestPool( 5 ) );
            mb.GetNewRandomMenu( 7 );
        }

        [TestMethod]
        [Timeout( 30 )]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsOnAddWhenPoolSize() {
            var mb = new MenuBuilder( GenerateTestPool( 5 ) );
            mb.GetNewRandomMenu( 5 );
            mb.AddAnotherMeal();
        }

        [TestMethod]
        [Timeout( 30 )]
        public void PoolMenuSameSize() {
            var mb = new MenuBuilder( GenerateTestPool( 5 ) );
            try {
                mb.GetNewRandomMenu( 5 );
            } catch {
                Assert.Fail();
            }
            Assert.AreEqual( 1, 1 );
        }
    }
}
