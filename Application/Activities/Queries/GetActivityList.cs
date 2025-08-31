using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities.Queries
{
    /// <summary>
    /// Retrieves a list of all activities from the database.
    /// </summary>
    public class GetActivityList
    {
        /// <summary>
        /// Query object used to trigger the retrieval of the activity list.
        /// </summary>
        public class Query : IRequest<List<Activity>> { }

        /// <summary>
        /// Handles the Query and returns the list of activities.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public class Handler(AppDbContext context, ILogger<GetActivityList> logger) : IRequestHandler<Query, List<Activity>>
        {
            /// <summary>
            /// Executes the query to fetch all activities from the database.
            /// </summary>
            /// <param name="request">The query request (empty in this case).</param>
            /// <param name="cancellationToken">Cancellation token for async operation.</param>
            /// <returns>List of Activity entities.</returns>
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);

                        logger.LogInformation($"Task {i} has completed.");
                    }
                }
                catch (System.Exception)
                {
                    logger.LogError("Task was cancelled");
                }
                return await context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}