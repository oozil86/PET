using PET.Models;

namespace PET.Iservices
{
    public interface IGroomingService
    {
        Task<Grooming> AddGrooming(Grooming model);
        Task<Grooming> EditGrooming(Grooming model);
        Task<Grooming> BookGrooming(Grooming model);
        Task<bool> DeleteGrooming(int id);
        Task<Grooming> GroomingById(int id);

        Task<List<Grooming>> GetAllGrooming();
    }
}
