using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Gallery_.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }

        public int Year { get; set; }

        public string Style { get; set; }

        public int Price { get; set; }
    }
}