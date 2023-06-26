using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        // Get all events 
        public Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();

        //Get all joined events
        public Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId);


        //Get events with ids
        public Task<DetailsEventViewModel> GetEventByIdAsync(int id);
        public Task<AddEventViewModel> GetEventByIdForEditAsync(int id);


        //Add event and edit
        public Task AddEventAsync(AddEventViewModel model, string userId);
        public Task EditEventAsync(AddEventViewModel model);


        //Join and leave
        public Task<string> JoinEventAsync(int id, string userId);
        public Task LeaveEventAsync(int id, string userId);


        //Generator for AddEventViewModel
        public Task <AddEventViewModel> GetNewAddEventModelAsync();
    }
}
