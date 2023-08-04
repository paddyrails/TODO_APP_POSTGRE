using System;
using TODO.Services.ToDoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TODO.Services.ToDoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDo>().HasData(new ToDo
            {
                ToDoId = 1,
                Task = "Get Groceries",
                
                Done = false
            });
            modelBuilder.Entity<ToDo>().HasData(new ToDo
            {
                ToDoId = 2,
                Task = "Pay rent",
                
                Done = false
            });
            modelBuilder.Entity<ToDo>().HasData(new ToDo
            {
                ToDoId = 3,
                Task = "Organize garage",
                
                Done = false
            });
            modelBuilder.Entity<ToDo>().HasData(new ToDo
            {
                ToDoId = 4,
                Task = "Buy furniture",
                
                Done = false
            });

        }
    }
}