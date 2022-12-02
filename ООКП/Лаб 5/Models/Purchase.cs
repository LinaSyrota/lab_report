using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace _Gallery_.Models
{
    [Table("Продані картини")]
    public class Purchase
    {
        [Column("id")]
        public int PurchaseId { get; set; }

        [Column("Назва картини")]
        public string PicturesName { get; set; }

        [Column("Id Картини")]
        public int PictureId { get; set; }

        [Column("ПІБ покупця")]
        public string Person { get; set; }

        [Column("E-mail")]
        public string Email { get; set; }

        [Column("Адреса")]
        public string Address { get; set; }

        [Column("Телефон")]
        public string Telephon { get; set; }

        [Column("Час оформлення покупки")]
        public DateTime Date { get; set; }
    }
}