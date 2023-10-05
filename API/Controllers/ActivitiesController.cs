using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        [HttpGet] // api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] // api/activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            var result = await Mediator.Send(new Details.Query{Id = id});
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            await Mediator.Send(new Create.Command { Activity = activity });

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Activity activity)
        {
            activity.Id = id;
            await Mediator.Send(new Edit.Command {Activity = activity});
            return Ok();
        }

    }
}