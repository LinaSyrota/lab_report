using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace _Gallery_.Models
{
    [Table("Картини")]
    public class Picture
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("Назва картини")]
        public string Name { get; set; }

        [Column("Художник")]
        public string Artist { get; set; }

        [Column("Жанр")]
        public string Genre { get; set; }

        [Column("Стиль")]
        public string Style { get; set; }

        [Column("Матеріали")]
        public string Materials { get; set; }

        [Column("Ціна")]
        public decimal Price { get; set; }

        [Column("Зображення")]
        public string Link { get; set; }
    }
}