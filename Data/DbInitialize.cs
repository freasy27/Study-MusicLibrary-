using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Music.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Data
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();

                
                
                // Add Customers
                var justin = new Customer
                {
                    Name = "Justin Noon"
                };
                var willie = new Customer
                {
                    Name = "Willie Parodi"
                };
                var leoma = new Customer
                {
                    Name = "Leoma Gosse"
                };

                context.Customers.Add(justin);
                context.Customers.Add(willie);
                context.Customers.Add(leoma);
                // Add Author
                var authorDeMarco = new Author
                {
                    Name = "M J DeMarco",
                    Musics = new List<Model.Music>()
                    {
                        new Model.Music { Title = "The Millionare Fastlane" },
                        new Model.Music { Title = "Unscripted" }
                    }
                };

                var authorCardone = new Author
                {
                    Name = "Grand Cardone",
                    Musics = new List<Model.Music>()
                    {
                        new Model.Music { Title = "The 10x Rule "},
                        new Model.Music { Title = "If You're Not First, You're Last" },
                        new Model.Music { Title = "Sell To Survive" }
                    }
                };

                context.Authors.Add(authorCardone);
                context.Authors.Add(authorDeMarco);

                context.SaveChanges();
            }
        }
    }
}
