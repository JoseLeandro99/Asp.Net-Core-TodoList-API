using System;
using System.ComponentModel.DataAnnotations;

namespace todolistapi.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is a required field")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is a required field")]
        public string Description { get; set; }

        public bool Done { get; set; }

        [Required(ErrorMessage = "Date is a required field")]
        public DateTime Date { get; set; }
    }
}