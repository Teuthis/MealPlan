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
        [Timeout( 100 )]
        public void RandomMenuSimpleGeneration() {
            var mb = new MenuBuilder( GenerateTestPool( 15 ), 7 );
            int expected = 7;
            Assert.AreEqual( expected, mb.Count );
        }

        [TestMethod]
        [Timeout( 100 )]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsOnEmptyPool() {
            var mb = new MenuBuilder( GenerateTestPool( 0 ) );
            mb.GetNewRandomMenu( 5 );
        }

        [TestMethod]
        [Timeout( 100 )]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsOnNullPool() {
            var mb = new MenuBuilder( null );
        }

        [TestMethod]
        [Timeout( 100 )]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsOnLargerThanPool() {
            var mb = new MenuBuilder( GenerateTestPool( 5 ) );
            mb.GetNewRandomMenu( 7 );
        }

        [TestMethod]
        [Timeout( 100 )]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsOnAddWhenPoolSize() {
            var mb = new MenuBuilder( GenerateTestPool( 5 ) );
            mb.GetNewRandomMenu( 5 );
            mb.AddAnotherMeal();
        }

        [TestMethod]
        [Timeout( 100 )]
        public void PoolMenuSameSize() {
            var mb = new MenuBuilder( GenerateTestPool( 5 ) );
            try {
                mb.GetNewRandomMenu( 5 );
            } catch {
                Assert.Fail();
            }
            Assert.AreEqual( 1, 1 );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void AverageCostOnEmptyMenu() {
            var mb = new MenuBuilder( GenerateTestPool( 8 ) );
            double expected = 0.0;
            Assert.AreEqual( expected, mb.AverageCost );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void AverageNaughtyOnEmptyMenu() {
            var mb = new MenuBuilder( GenerateTestPool( 8 ) );
            double expected = 0.0;
            Assert.AreEqual( expected, mb.AverageNaughtiness );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void AveragePrepOnEmptyMenu() {
            var mb = new MenuBuilder( GenerateTestPool( 8 ) );
            double expected = 0.0;
            Assert.AreEqual( expected, mb.AveragePrepTime );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void AverageHeavyOnEmptyMenu() {
            var mb = new MenuBuilder( GenerateTestPool( 8 ) );
            double expected = 0.0;
            Assert.AreEqual( expected, mb.AverageHeaviness );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void LeftoversOnEmptyMenu() {
            var mb = new MenuBuilder( GenerateTestPool( 8 ) );
            int expected = 0;
            Assert.AreEqual( expected, mb.LeftoversCount );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void AverageCostCalc() {
            List<Meal> pool = new List<Meal>();
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, false ) );
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, false ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, false ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, false ) );
            var mb = new MenuBuilder( pool, 4 );
            double expected = 3.0;
            Assert.AreEqual( expected, mb.AverageCost );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void AveragePrepCalc() {
            List<Meal> pool = new List<Meal>();
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, false ) );
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, false ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, false ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, false ) );
            var mb = new MenuBuilder( pool, 4 );
            double expected = 3.0;
            Assert.AreEqual( expected, mb.AveragePrepTime );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void AverageNaughtyCalc() {
            List<Meal> pool = new List<Meal>();
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, false ) );
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, false ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, false ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, false ) );
            var mb = new MenuBuilder( pool, 4 );
            double expected = 3.0;
            Assert.AreEqual( expected, mb.AverageNaughtiness );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void AverageHeavyCalc() {
            List<Meal> pool = new List<Meal>();
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, false ) );
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, false ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, false ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, false ) );
            var mb = new MenuBuilder( pool, 4 );
            double expected = 3.0;
            Assert.AreEqual( expected, mb.AverageHeaviness );
        }

        [TestMethod]
        [Timeout( 25 )]
        public void LeftoversCalc() {
            List<Meal> pool = new List<Meal>();
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, false ) );
            pool.Add( new Meal( "First", "", 2, 2, 2, 2, true ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, true ) );
            pool.Add( new Meal( "First", "", 4, 4, 4, 4, false ) );
            var mb = new MenuBuilder( pool, 4 );
            int expected = 2;
            Assert.AreEqual( expected, mb.LeftoversCount );
        }

        [TestMethod]
        [Timeout( 100 )]
        public void Pinning() {
            var mb = new MenuBuilder( GenerateTestPool( 50 ), 4 );
            var meal = mb[2];
            mb.TogglePin( 2 );
            mb.ReshuffleMenu();
            Assert.AreEqual( meal, mb[2] );
        }

        [TestMethod]
        [Timeout( 100 )]
        public void Reshuffling() {
            var mb = new MenuBuilder( GenerateTestPool( 50 ), 4 );
            var meal = mb[2];
            mb.ReshuffleMenu();
            Assert.AreNotEqual( meal, mb[2] );
        }
    }
}
