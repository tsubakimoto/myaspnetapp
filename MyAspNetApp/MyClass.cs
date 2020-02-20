using System;

namespace MyAspNetApp
{
    public class MyClass
    {
        private MyAspNetApp.Models.MyAspNetAppContext context;

        public void Greet(MyAspNetApp.Models.MyAspNetAppContext context)
        {
            this.context = context;
        }

        public void Method1()
        {
            var dt = DateTime.Parse("2020/02/01 12:34:56");
            Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}