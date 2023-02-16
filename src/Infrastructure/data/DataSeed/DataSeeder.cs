using Business.Constant;
using Data.Infrastructure.PasswordHasher;
using Entity;
using Entity.Enum;
using Microsoft.Extensions.Options;
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
                context.Store.Add(new Store()
                {
                    Name = "Store Name",
                    AddressLine1 = "",
                });
            }
            var o = Options.Create(new HashingOptions()
            {
                Iterations = 1000
            }) ;
            if (!context.User.Any())
            {
                context.User.Add(new User()
                {
                    FirstName = "Test",
                    LastName = "Test",
                    Email = "veducation0693@gmail.com",
                    EmailConfirmed = true,
                    Password = new PasswordHasher(o).Hash("12345")
                });
            }
            context.SaveChanges();
           
        }
    }
}
