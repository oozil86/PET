using PET.Models;

namespace PET.Iservices
{
    public interface IClinicService
    {
        Task<Clinic> AddClinic(Clinic model);
        Task<Clinic> EditClinic(Clinic model);
        Task<bool> DeleteClinic(int id);
        Task<List<Clinic>> GetAllClinic();
    }
}
