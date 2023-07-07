

using PET.Dtos;

namespace Alzheimer.Iservices;

public interface IAppointmentService
{
    Task<Appointment> AddAppointment(Appointment model);
    Task<Appointment> ChangeAppointment(Appointment model);
    Task<Appointment> BookAppointment(Appointment model);
    Task<Appointment> UpdateAppointment(Appointment model);
    Task<bool> DeleteAppointment(int id);
    Task<bool> ApproveAppointment(int id);
    Task<bool> DeclineAppointment(int id);
    Task<List<AppointmentDto>> GetAppointment();
    Task<Appointment> GetDoctorById(int Id);
}
