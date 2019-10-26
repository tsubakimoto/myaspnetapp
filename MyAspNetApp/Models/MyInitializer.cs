using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAspNetApp.Models
{
    public class MyInitializer : DropCreateDatabaseIfModelChanges<MyAspNetAppContext>
    {
        protected override void Seed(MyAspNetAppContext context)
        {
            base.Seed(context);

            for (int i = 0; i < 10; i++)
            {
                context.Users.Add(new User
                {
                    Id = i,
                    Name = $"user-{i + 1}",
                    Birthday = DateTime.Today.AddYears(i)
                });
            }
            context.SaveChanges();
        }
    }
}