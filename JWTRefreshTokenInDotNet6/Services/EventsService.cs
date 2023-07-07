

namespace GraduationProject.Services;

public class EventsService : IEventsService
{

    private readonly ApplicationDbContext _context;
    public EventsService(ApplicationDbContext context) => _context = context;

    public async Task<Events> AddEvents(Events model)
    {
        try
        {
            await _context.Events.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> ApproveEvents(int id)
    {
        try
        {
            var q = await _context.Events.FindAsync(id);
            if (q is not null)
            {
                q.IsWorkFlow = 3;
                _context.Events.Update(q);
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

    public async Task<bool> DeclineEvents(int id)
    {
        try
        {
            var q = await _context.Events.FindAsync(id);
            if (q is not null)
            {
                _context.Events.Remove(q);
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

    public async Task<bool> DeleteEvents(int id)
    {
        try
        {
            var q = await _context.Events.FindAsync(id);
            if (q is not null)
            {
                _context.Events.Remove(q);
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

    public async Task<Events> EditEvents(Events model)
    {
        try
        {
            _context.Events.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<Events>> GetEvents()
    {
        try
        {
            return await _context.Events.ToListAsync();

        }
        catch (Exception)
        {

            throw;
        }
    }
}
