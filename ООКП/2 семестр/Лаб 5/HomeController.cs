using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab_5.Models;

namespace lab_5.Controllers
{
    public class HomeController : Controller
    {
        public List<Person> translate(List<Person> people)
        {
            foreach (Person p in people)
            {
                if (p.profession == "advocate")
                    p.profession = "адвокат";
                else if (p.profession == "notary")
                    p.profession = "нотаріус";
                else if (p.profession == "investigator")
                    p.profession = "слідчий";
            }

            return people;
        }

        public ActionResult Index(string A, string B, string C)
        {
            // advocate
            // notary
            // investigator
            List<Person> people = new List<Person>();
            people.Add(new Person("A", A));
            people.Add(new Person("B", B));
            people.Add(new Person("C", C));

            string answer = "Спробуйте ще раз! На жаль, дана комбінація виявилась помилковою:";
            bool correct = true;

            if (people[0].profession == "" || people[1].profession == "" || people[2].profession == "")
                answer = "Заповніть всі поля";
            else if (people[0].profession == people[1].profession || people[0].profession == people[2].profession || people[1].profession == people[2].profession)
                answer = "A, B і C повинні мати різні професії";
            else 
            {
                if (people[2].profession == "notary")
                    if (people[1].profession != "investigator")
                        correct = false;

                if (people[2].profession != "investigator")
                    if (people[1].profession == "notary")
                        correct = false;

                if (people[1].profession != "advocate")
                    if (people[2].profession == "advocate")
                        correct = false;

                if (people[0].profession == "advocate")
                    if (people[2].profession != "investigator")
                        correct = false;

                if (people[0].profession == "notary")
                    if (people[2].profession == "investigator")
                        correct = false;


                if (correct)
                    answer = "Саме так!";
            }

            ViewBag.People = translate(people);
            ViewBag.Answer = answer;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}