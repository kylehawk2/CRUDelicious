using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Meal
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        [MinLength(2)]
        public string Name {get;set;}
        [Required]
        [MinLength(2)]
        public string Chef {get;set;}
        [Required]
        public int Tastiness {get;set;}
        [Required]
        [Range(5,5000)]
        public int Calories {get;set;}
        [Required]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}