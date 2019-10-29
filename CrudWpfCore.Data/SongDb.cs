using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrudWpfCore.Data
{
    public class SongDb
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Album { get; set; }
        [Required]
        public string Genre { get; set; }

        //public override string ToString() => $"{Title} - {Artist}";
        



    }
}
