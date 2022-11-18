using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace _Gallery_.Models
{
    [Table("Зображення")]
    public class Image
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("Зображення")]
        public string Link { get; set; }
    }
}