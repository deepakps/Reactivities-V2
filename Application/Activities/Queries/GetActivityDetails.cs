using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Queries
{
    /// <summary>
    /// Retrieves details of a specific activity by its ID.
    /// </summary>
    public class GetActivityDetails
    {
        /// <summary>
        /// Query object containing the ID of the activity to retrieve.
        /// </summary>
        public class Query : IRequest<Activity>
        {
            /// <summary>
            /// The unique identifier of the activity.
            /// </summary>
            public required string Id { get; set; }
        }

        /// <summary>
        /// Handles the Query and returns the details of a specific activity.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
        {
            /// <summary>
            /// Fetches the activity by ID or throws an exception if not found.
            /// </summary>
            /// <param name="request">The query request containing the activity ID.</param>
            /// <param name="cancellationToken">Cancellation token for async operation.</param>
            /// <returns>The requested Activity entity.</returns>
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync([request.Id], cancellationToken) ?? throw new Exception("Activity not found");
                return activity;
            }
        }
    }
}