﻿using System.ComponentModel.DataAnnotations;

namespace Hudalibraryproject.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        public DateTime CreatedON { get; set; }= DateTime.Now;
        public DateTime UpdatedOn {  get; set; }= DateTime.Now;

        

    }
}