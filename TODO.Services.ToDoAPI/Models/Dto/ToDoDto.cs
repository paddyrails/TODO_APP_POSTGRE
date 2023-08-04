using System;
using System.ComponentModel.DataAnnotations;

namespace TODO.Services.ToDoAPI.Models.Dto
{
	public class ToDoDto
	{		
        public int ToDoId { get; set; }        
        public string? Task { get; set; }        
        public bool Done { get; set; }    
	}
}

