using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;
        public EventService(HomiesDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            return await dbContext.Events.Select(x => new AllEventViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Start = x.Start.ToString("yyyy-MM-dd H:mm"),
                Type = x.Type.Name,
                Organiser = x.Organiser.UserName
            }).ToListAsync();
        }
        
        public async Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await dbContext.EventsParticipants.Where(x => x.HelperId == userId).Select(x => new AllEventViewModel
            {
                Id = x.Event.Id,
                Name = x.Event.Name,
                Start = x.Event.Start.ToString("yyyy-MM-dd H:mm"),
                Type = x.Event.Type.Name,
                Organiser = x.Event.Organiser.UserName
            }).ToListAsync();
        }


        public async Task<DetailsEventViewModel?> GetEventByIdAsync(int id)
        {
            return await dbContext.Events.Where(x => x.Id == id).Select(x => new DetailsEventViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Start = x.Start,
                End = x.End,
                Organiser = x.Organiser.UserName,
                CreatedOn = x.CreatedOn,
                Type = x.Type.Name,
            }).FirstOrDefaultAsync();
        }

        public async Task<AddEventViewModel?> GetEventByIdForEditAsync(int id)
        {
            var types = await dbContext.Types.Select(x => new TypeViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return await dbContext.Events.Where(x => x.Id == id).Select(x => new AddEventViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Start = x.Start,
                End = x.End,
                TypeId = x.TypeId,
                Types = types,
                OrganiserId = x.OrganiserId
            }).FirstOrDefaultAsync();
        }


        public async Task AddEventAsync(AddEventViewModel model,string userId)
        {
            var eventToAdd = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = userId,
                CreatedOn = DateTime.UtcNow,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId
            };
            await dbContext.Events.AddAsync(eventToAdd);
            await dbContext.SaveChangesAsync();
            await JoinEventAsync(eventToAdd.Id, userId);
        }

        public async Task EditEventAsync(AddEventViewModel model)
        {
            var currentEvent = await dbContext.Events.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (currentEvent == null)
            {
                return;
            }
            currentEvent.Name = model.Name;
            currentEvent.Description = model.Description;
            currentEvent.Start = model.Start;
            currentEvent.End = model.End;
            currentEvent.TypeId = model.TypeId;
            await dbContext.SaveChangesAsync();
        }



        public async Task<string> JoinEventAsync(int id, string userId)
        {
            bool alreadyAdded = await dbContext.EventsParticipants.AnyAsync(x => x.HelperId == userId && x.EventId == id);
            if (!alreadyAdded)
            {
                var eventParticipant = new EventParticipant()
                {
                    HelperId = userId,
                    EventId = id
                };
                await dbContext.EventsParticipants.AddAsync(eventParticipant);
                await dbContext.SaveChangesAsync();
                return "Done";
            }
            return "already Added";
        }

        public async Task LeaveEventAsync(int id, string userId)
        {
            bool isHere = await dbContext.EventsParticipants.AnyAsync(x => x.HelperId == userId && x.EventId == id);
            if (isHere)
            {
                var eventParticipant = new EventParticipant()
                {
                    HelperId = userId,
                    EventId = id
                };
                dbContext.EventsParticipants.Remove(eventParticipant);
                await dbContext.SaveChangesAsync();
            }
        }

        //Generator
        public async Task<AddEventViewModel> GetNewAddEventModelAsync()
        {
            var types = await dbContext.Types.Select(x => new TypeViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            var model = new AddEventViewModel()
            {
                Types = types
            };
            return model;
        }
    }
}
