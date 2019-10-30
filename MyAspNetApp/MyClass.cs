namespace MyAspNetApp
{
    public class MyClass
    {
        private MyAspNetApp.Models.MyAspNetAppContext context;

        public void Greet(MyAspNetApp.Models.MyAspNetAppContext context)
        {
            this.context = context;
        }
    }
}