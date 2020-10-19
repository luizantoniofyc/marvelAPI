using Dextra.Marvel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Input
{
    /// <summary>
	/// Represents a set of filter properties for event search
	/// </summary>
    public class EventInput
    {
        /// <summary>
        /// Filter the event list by name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Return events with names that begin with the specified string (e.g. Sp).
        /// </summary>
        public string NameStartsWith { get; set; }

        /// <summary>
        /// Return only events which have been modified since the specified date.
        /// </summary>
        public DateTime? ModifiedSince { get; set; }

        /// <summary>
        /// Return only events which feature work by the specified creators (accepts a comma-separated list of ids).
        /// </summary>
        public string Creators { get; set; }

        /// <summary>
        /// Return only characters which appear the specified series (accepts a comma-separated list of ids).
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Return only events which appear in the specified comics (accepts a comma-separated list of ids).
        /// </summary>
        public string Comics { get; set; }

        /// <summary>
        /// Return only events which appear the specified stories (accepts a comma-separated list of ids).
        /// </summary>
        public string Stories { get; set; }
        
        /// <summary>
        /// Order the result set by a field or fields. Add a "-" to the value sort in descending order. Multiple values are given priority in the order in which they are passed.
        /// </summary>
        public EventOrderByEnum OrderBy { get; set; }

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
