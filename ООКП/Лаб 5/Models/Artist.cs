using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace _Gallery_.Models
{
    [Table("Художники")]
    public class Artist
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("Ім'я художника")]
        public string ArtistsName { get; set; }

        [Column("Інформація")]
        public string Info { get; set; }

        [Column("Зображення")]
        public string Photo { get; set; }
    }
}