﻿using System.ComponentModel.DataAnnotations;

namespace SamuraiApp.Domain
{
    public class Samurai
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; } = new List<Quote>();
        public List<Battle> Battles { get; set; } = new List<Battle>();
        public Horse Horse { get; set; }
    }
}
