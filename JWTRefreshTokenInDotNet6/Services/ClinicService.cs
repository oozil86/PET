using PET.Iservices;
using PET.Models;

namespace PET.Services
{
    public class ClinicService: IClinicService
    {
        private readonly ApplicationDbContext _context;
        public ClinicService(ApplicationDbContext context) => _context = context;

        public async Task<Clinic> AddClinic(Clinic model)
        {
            try
            {
                await _context.Clinic.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteClinic(int id)
        {
            try
            {
                var q = await _context.Clinic.FindAsync(id);
                if (q is not null)
                {
                    _context.Clinic.Remove(q);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Clinic> EditClinic(Clinic model)
        {
            try
            {
                _context.Clinic.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Clinic>> GetAllClinic()
        {
            try
            {
                return await _context.Clinic.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
