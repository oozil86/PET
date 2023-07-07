using PET.Iservices;
using PET.Models;

namespace PET.Services
{
    public class GroomingService : IGroomingService
    {
        private readonly ApplicationDbContext _context;

        public GroomingService(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<Grooming> AddGrooming(Grooming model)
        {
            try
            {
                await _context.Grooming.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async  Task<Grooming> BookGrooming(Grooming model)
        {
            try
            {
                model.IsReserved = true;
                _context.Grooming.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteGrooming(int id)
        {
            try
            {
                var q = await _context.Grooming.FindAsync(id);
                if (q is not null)
                {
                    _context.Grooming.Remove(q);
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

        public async Task<Grooming> EditGrooming(Grooming model)
        {
            try
            {
                _context.Grooming.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Grooming>> GetAllGrooming()
        {
            try
            {
                return await _context.Grooming.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Grooming> GroomingById(int id)
        {
            try
            {
                return await _context.Grooming.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
