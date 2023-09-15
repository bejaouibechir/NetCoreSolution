using System;
using System.Collections.Generic;
using System.Linq;

namespace InjectionServiceApp
{
    internal class Program
    {
       
        
        static void Main(string[] args)
        {
            List<Color> colors = new List<Color>()
            {
                new Color{Id=1,Name="Red" },
                 new Color{Id=2,Name="Green" },
                  new Color{Id=3,Name="Blue" },
                   new Color{Id=4,Name="Yellow" },
                    new Color{Id=5,Name="Orange" },
            };

          

            Color current = colors.Where(c=>c.Name=="Orange").SingleOrDefault();
     
        }

        private static bool methode(Color color)
        {
            throw new NotImplementedException();
        }
    }

    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
 



}


