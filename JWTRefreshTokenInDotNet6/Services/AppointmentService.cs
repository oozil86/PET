

using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Services;

public class AppointmentService : IAppointmentService
{
    private readonly ApplicationDbContext _context;
    public AppointmentService(ApplicationDbContext context) => _context = context;

    public async Task<Appointment> AddAppointment(Appointment model)
    {
        try
        {
            await _context.Appointments.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Appointment> UpdateAppointment(Appointment model)
    {

        try
        {
            
            _context.Appointments.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            throw;
        }
       
    }

    public async Task<bool> DeleteAppointment(int id)
    {
        try
        {
            var q = await _context.Appointments.FindAsync(id);
            if(q is not null)
            {
                _context.Appointments.Remove(q);
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

    public async Task<Appointment> ChangeAppointment(Appointment model)
    {
        try
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<List<Appointment>> GetAppointment()
             => await _context.Appointments.ToListAsync();

    public async Task<Appointment> GetDoctorById(int Id)
    {
        try
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == Id);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Appointment> BookAppointment(Appointment model)
    {
        try
        {
             model.IsReserved = true;
            _context.Appointments.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async  Task<bool> ApproveAppointment(int id)
    {
        try
        {
            var q = await _context.Appointments.FindAsync(id);
            if (q is not null)
            {
                q.IsWorkFlow = 3;
                _context.Appointments.Update(q);
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

    public async Task<bool> DeclineAppointment(int id)
    {
        try
        {
            var q = await _context.Appointments.FindAsync(id);
            if (q is not null)
            {
                _context.Appointments.Remove(q);
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
}
