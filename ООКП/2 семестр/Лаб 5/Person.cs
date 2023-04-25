using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab_5.Models
{
    public class Person
    {
        public string name { get; set; }
        public string profession { get; set; }

        public Person(string _name, string _profession)
        {
            name = _name;
            profession = _profession;
        }
    }
}