using SchoolAPI.Data;
using SchoolAPI.Models;
using SchoolAPI.Repository.IRepository;

namespace SchoolAPI.Repository
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        
            private readonly SchoolContext _db;
            public GradeRepository(SchoolContext db) : base(db)
            {
                _db = db;
            }

            public async Task<Grade> Update(Grade entity)
            {
                _db.Grades.Add(entity);
                await _db.SaveChangesAsync();
                return entity;
            }

       
    }
}
