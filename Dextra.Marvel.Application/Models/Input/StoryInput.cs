using Dextra.Marvel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Input
{
    /// <summary>
	/// Represents a set of filter properties for story search
	/// </summary>
    public class StoryInput
    {
        /// <summary>
        /// Return only stories which have been modified since the specified date.
        /// </summary>
        public DateTime? ModifiedSince { get; set; }

        /// <summary>
        /// Return only stories contained in the specified (accepts a comma-separated list of ids).
        /// </summary>
        public string Comics { get; set; }

        /// <summary>
        /// Return only stories contained the specified series (accepts a comma-separated list of ids).
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Return only stories which take place during the specified events (accepts a comma-separated list of ids).
        /// </summary>
        public string Events { get; set; }

        /// <summary>
        /// Return only stories which feature work by the specified creators (accepts a comma-separated list of ids).
        /// </summary>
        public string Creators { get; set; }
        
        /// <summary>
        /// Order the result set by a field or fields. Add a "-" to the value sort in descending order. Multiple values are given priority in the order in which they are passed.
        /// </summary>
        public StoryOrderByEnum OrderBy { get; set; }

        /// <summary>
        /// Limit the result set to the specified number of resources.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Skip the specified number of resources in the result set.
        /// </summary>
        public int? Offset { get; set; }
    }
}
