namespace Domain
{
    /// <summary>
    /// Represents an activity or event with location, category, and status details.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Unique identifier for the activity.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Title or name of the activity.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Scheduled date and time of the activity.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Description of the activity.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Category of the activity (e.g., music, travel).
        /// </summary>
        public required string Category { get; set; }

        /// <summary>
        /// Indicates whether the activity is cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }

        // Location properties

        /// <summary>
        /// City where the activity is held.
        /// </summary>
        public required string City { get; set; }

        /// <summary>
        /// Venue or address of the activity.
        /// </summary>
        public required string Venue { get; set; }

        /// <summary>
        /// Latitude coordinate of the venue.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude coordinate of the venue.
        /// </summary>
        public double Longitude { get; set; }
    }
}