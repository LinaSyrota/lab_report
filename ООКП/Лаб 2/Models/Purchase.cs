using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Gallery_.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public string Person { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Telephon { get; set; }

        public int PictureId { get; set; }

        public DateTime Date { get; set; }
    }
}