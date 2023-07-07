
using PET.Models;

namespace GraduationProject.Iservices;

public interface IEventsService
{ 
    Task<List<Events>> GetEvents();
    Task<Events> AddEvents(Events model);
    Task<Events> EditEvents(Events model);
    Task<bool> DeleteEvents(int id);
    Task<bool> ApproveEvents(int id);
    Task<bool> DeclineEvents(int id);
}
