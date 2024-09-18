using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        [ForeignKey("SamuraiId")]
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}
