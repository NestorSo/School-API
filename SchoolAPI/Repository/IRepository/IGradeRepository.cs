using SchoolAPI.Models;

namespace SchoolAPI.Repository.IRepository
{
    public interface IGradeRepository: IRepository<Grade>
    {
        Task<Grade> Update(Grade entity);
    }
}
