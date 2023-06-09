﻿using SchoolAPI.Data;
using SchoolAPI.Models;
using SchoolAPI.Repository.IRepository;

namespace SchoolAPI.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly SchoolContext _db;
        public StudentRepository(SchoolContext db) : base(db)
        {
            _db = db;
        }
        
        public async Task<Student> Update(Student enity)
        {
            _db.Students.Add(enity);
            await _db.SaveChangesAsync();
            return enity;
        }
    }
}
