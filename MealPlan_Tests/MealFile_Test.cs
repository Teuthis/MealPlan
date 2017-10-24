using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MealPlan;

namespace MealPlan_Tests
{
    [TestClass]
    public class MealFile_Test
    {
        [TestMethod]
        public void LoadNoFile() {
            MealFile file = new MealFile();
            file.Path = "C:\\notafile.xml";
            var pool = file.Read();
            Assert.AreEqual( 1, pool.Count );
            Assert.AreEqual( "Arroz con Pollo", pool[0].Name );
            Assert.AreEqual( 
                "https://www.epicurious.com/recipes/food/views/arroz-con-pollo-51190840", 
                pool[0].RecipeLink );
            Assert.AreEqual( 4, pool[0].PreparationTime );
            Assert.AreEqual( 4, pool[0].Naughtiness );
            Assert.AreEqual( 3, pool[0].Cost );
            Assert.AreEqual( 3, pool[0].Heaviness );
            Assert.AreEqual( true, pool[0].ProducesLeftovers );
        }
    }
}
