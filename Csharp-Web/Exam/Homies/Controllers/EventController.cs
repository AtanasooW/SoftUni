using Homies.Contracts;
using Homies.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;
        public EventController(IEventService _eventService)
        {
            this.eventService = _eventService;
        }
        
        //Get all Events
        public async Task<IActionResult> All()
        {
            var models = await eventService.GetAllEventsAsync();
            return View(models);
        }
        public async Task<IActionResult> Joined()
        {
            var models = await eventService.GetJoinedEventsAsync(GetUserID());
            return View(models);
        }


        //ADD event
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await eventService.GetNewAddEventModelAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = GetUserID();
            await eventService.AddEventAsync(model, userId);
            return RedirectToAction("All");
        }


        //EDIT event 
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await eventService.GetEventByIdForEditAsync(id);

            if(model == null || model.OrganiserId != GetUserID())
            {
                return RedirectToAction("All");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddEventViewModel model)
        {

            await eventService.EditEventAsync(model);
            return RedirectToAction("All");
        }


        public async Task<IActionResult> Details(int id)
        {
            var mdoel = await eventService.GetEventByIdAsync(id);

            if (mdoel == null)
            {
                return RedirectToAction("All");
            }

            return View(mdoel);
        }
        

        //Actions without views
        public async Task<IActionResult> Join(int id)
        {
            var currentEvent = await eventService.GetEventByIdAsync(id);

            if (currentEvent == null)
            {
                return RedirectToAction("All");
            }

            var userId = GetUserID();
            var value = await eventService.JoinEventAsync(id, userId);
            if (value == "Done")
            {
                return RedirectToAction("Joined");
            }
            return RedirectToAction("All");

        }
        public async Task<IActionResult> Leave(int id)
        {
            var currentEvent = await eventService.GetEventByIdAsync(id);

            if (currentEvent == null)
            {
                return RedirectToAction("All");
            }

            var userId = GetUserID();
            await eventService.LeaveEventAsync(id, userId);
            return RedirectToAction("All");
        }
    }
}
