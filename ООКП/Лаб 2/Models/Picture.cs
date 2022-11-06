using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Gallery_.Models
{
    public class Picture
    {
        // ID
        public int Id { get; set; }

        // назва картини
        public string Name { get; set; }

        // художник
        public string Artist { get; set; }

        // рік написання 
        public int Year { get; set; }

        // стиль написання
        public string Style { get; set; }

        // ціна
        public int Price { get; set; }
    }
}