using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlan
{
    public class MealFile
    {
        string path;


        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                //TODO Add argument validation
                path = value;
            }
        }

        public void Write(List<Meal> data) {
            //TODO implement
            throw new NotImplementedException();
        }

        public List<Meal> Read() {
            XmlDocument doc = new XmlDocument();
            using (var stream = new FileStream( path, FileMode.Open, FileAccess.Read )) {
                try {
                    doc.Load( stream );
                }
                catch (System.IO.FileNotFoundException) {
                    doc.LoadXml(
                        "<?xml version=\"1.0\"?>\n" +
                        "<meals>\n" +
                        "  <meal name=\"Arroz con Pollo\">\n" +
                        "    <link>https://www.epicurious.com/recipes/food/views/arroz-con-pollo-51190840</link>\n" +
                        "    <prep>4</prep>\n" +
                        "    <naughty>4</naughty>\n" +
                        "    <cost>3</cost>\n" +
                        "    <heavy>3</heavy>\n" +
                        "    <leftovers>true</leftovers>\n" +
                        "  </meal>\n" +
                        "</meals>" );
                }
            }
            var mealnodes = doc.GetElementsByTagName( "meal" );
            List<Meal> mealPool = new List<Meal>( mealnodes.Count );
            foreach (XmlNode m in mealnodes) {
                Meal meal = new Meal( m.Attributes["name"].ToString() );
                foreach (XmlNode child in m.ChildNodes) {
                    if (child.Name == "link") {
                        meal.RecipeLink = child.InnerText;
                    }
                    else if (child.Name == "prep") {
                        if (int.TryParse( child.InnerText, out int val )) {
                            meal.PreparationTime = val;
                        }
                        else {
                            meal.PreparationTime = 3;
                        }
                    }
                    else if (child.Name == "naughty") {
                        if (int.TryParse( child.InnerText, out int val )) {
                            meal.Naughtiness = val;
                        }
                        else {
                            meal.Naughtiness = 3;
                        }
                    }
                    else if (child.Name == "cost") {
                        if (int.TryParse( child.InnerText, out int val )) {
                            meal.Cost = val;
                        }
                        else {
                            meal.Cost = 3;
                        }
                    }
                    else if (child.Name == "heavy") {
                        if (int.TryParse( child.InnerText, out int val )) {
                            meal.Heaviness = val;
                        }
                        else {
                            meal.Heaviness = 3;
                        }
                    }
                    else if (child.Name == "leftovers") {
                        if (child.InnerText == "true") {
                            meal.ProducesLeftovers = true;
                        }
                        else {
                            meal.ProducesLeftovers = false;
                        }
                    }
                    mealPool.Add( meal );
                }
            }
            return mealPool;
        }
    }
}
