using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    /// <summary>
    /// Controller for handling activity-related endpoints.
    /// </summary>
    /// <param name="context"></param>
    public class ActivitiesController(AppDbContext context, IMediator mediator) : BaseApiController
    {
        #region Properties
        private readonly AppDbContext context = context;
        #endregion

        #region Endpoints
        /// <summary>
        /// Retrieves the list of all activities.
        /// </summary>
        /// <returns>List of activities.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await mediator.Send(new GetActivityList.Query());
        }

        /// <summary>
        /// Retrieves details of a specific activity by ID.
        /// </summary>
        /// <param name="id">The ID of the activity.</param>
        /// <returns>The activity details or NotFound if not present.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            var activity = await context.Activities.FindAsync(id);

            if(activity == null) return NotFound();

            return activity;
        }
        #endregion
    }
}