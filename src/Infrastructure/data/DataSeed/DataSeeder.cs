using Business.Constant;
using Entity;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataSeed
{
    public class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {

            var units = new List<string>() { "Kilogram", "Gram", "Liter", "Square foot", "Square meter", "meter", "foot",
                "Meter","inch","Box","Dozen","Piece" };
            foreach (var unit in units) 
            {
                if (!context.Unit.Any(x => x.Name == unit))
                {
                    context.Unit.Add(new Unit() { Name = unit });
                }
            }

            if (!context.Store.Any())
            {
                context.Store.Add(new Store() { Name = "Store Name" });
            }
            context.SaveChanges();
           
        }
    }
}
