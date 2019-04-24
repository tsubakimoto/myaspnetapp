using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyAspNetApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public void Foo()
        {
            var text = File.ReadAllText("...");
        }
    }
}