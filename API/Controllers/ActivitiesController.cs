using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controller for handling activity-related endpoints.
    /// </summary>
    /// <param name="context"></param>
    public class ActivitiesController : BaseApiController
    {
        #region Properties
        #endregion

        #region Endpoints
        /// <summary>
        /// Retrieves the list of all activities.
        /// </summary>
        /// <returns>List of activities.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetActivityList.Query(), cancellationToken);
        }

        /// <summary>
        /// Retrieves details of a specific activity by ID.
        /// </summary>
        /// <param name="id">The ID of the activity.</param>
        /// <returns>The activity details or NotFound if not present.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            return await Mediator.Send(new GetActivityDetails.Query { Id = id });
        }

        /// <summary>
        /// Creates a new activity.
        /// </summary>
        /// <param name="activity">The activity object to be created.</param>
        /// <returns>The ID of the newly created activity.</returns>
        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity activity)
        {
            return await Mediator.Send(new CreateActivity.Command { Activity = activity });
        }

        /// <summary>
        /// Updates an activity with new details.
        /// </summary>
        /// <param name="activity">Updated activity data.</param>
        /// <returns>204 NoContent on success.</returns>
        [HttpPut]
        public async Task<ActionResult> EditActivity(Activity activity)
        {
            await Mediator.Send(new EditActivity.Command { Activity = activity });

            return NoContent();
        }

        /// <summary>
        /// Deletes an activity by ID.
        /// </summary>
        /// <param name="id">ID of the activity to delete.</param>
        /// <returns>204 NoContent on success.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(string id)
        {
            await Mediator.Send(new DeleteActivity.Command { Id = id });

            return Ok();
        }
        #endregion
    }
}