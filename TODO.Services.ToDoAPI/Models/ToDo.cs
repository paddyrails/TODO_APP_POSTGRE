using System;
using System.ComponentModel.DataAnnotations;

namespace TODO.Services.ToDoAPI.Models
{
	public class ToDo
	{
        [Key]
        public int ToDoId { get; set; }
        [Required]
        public string? Task { get; set; }        
        public DateTime DueDate { get; set; }
        public bool Done { get; set; }
    }
}

