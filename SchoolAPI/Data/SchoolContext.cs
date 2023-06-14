﻿using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;
using SchoolAPI.ModelsUser;

namespace SchoolAPI.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Grade>().HasData(
                new Grade()
                {
                    Id = 1,
                    GradeName = "Primero",
                    Section= 'A'
                },
                 new Grade()
                 {
                     Id = 2,
                     GradeName = "Primero",
                     Section = 'B'
                 }        
                );
           
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    StudentId = 1,
                    StudentName = "José González",
                    DateOfBirth = new DateTime(2018,5,6),
                    GradeId = 1

                },
                new Student()
                {
                    StudentId = 2,
                    StudentName = "María José Ramírez",
                    DateOfBirth = new DateTime(2017, 4, 12),
                    GradeId = 2
                },
                new Student()
                {
                    StudentId = 3,
                    StudentName = "Carlos Fonseca",
                     DateOfBirth = new DateTime(2019, 1, 28),
                    GradeId = 2
                });
            modelBuilder.Entity<User>().HasData(
               new User()
               {
                   Name = "Rebecca Auxiliadora Fajardo",
                   Password = "2345"
               },
                new User()
                {
                    Name = "User2",
                    Password = "123"
                });

        }
    }
}
