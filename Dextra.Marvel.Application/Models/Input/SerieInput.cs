using Dextra.Marvel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Input
{
    /// <summary>
	/// Represents a set of filter properties for event search
	/// </summary>
    public class SerieInput
    {
        /// <summary>
        /// Filter by series title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Return series with titles that begin with the specified string (e.g. Sp).
        /// </summary>
        public string TitleStartsWith { get; set; }

        /// <summary>
        /// Return only series matching the specified start year.
        /// </summary>
        public int? StartYear { get; set; }

        /// <summary>
        /// Return only series which have been modified since the specified date.
        /// </summary>
        public DateTime? ModifiedSince { get; set; }

        /// <summary>
        /// Return only series which contain the specified comics (accepts a comma-separated list of ids).
        /// </summary>
        public string Comics { get; set; }

        /// <summary>
        /// Return only series which contain the specified stories (accepts a comma-separated list of ids).
        /// </summary>
        public string Stories { get; set; }

        /// <summary>
        /// Return only series which have comics that take place during the specified events (accepts a comma-separated list of ids).
        /// </summary>
        public string Events { get; set; }

        /// <summary>
        /// Return only series which feature work by the specified creators (accepts a comma-separated list of ids).
        /// </summary>
        public string Creators { get; set; }

        /// <summary>
        /// Filter the series by publication frequency type.
        /// </summary>
        public SerieTypeEnum SeriesType { get; set; }

        /// <summary>
        /// Return only series containing one or more comics with the specified format.
        /// </summary>
        public ComicFormatEnum Contains { get; set; }

        /// <summary>
        /// Order the result set by a field or fields. Add a "-" to the value sort in descending order. Multiple values are given priority in the order in which they are passed.
        /// </summary>
        public SerieOrderByEnum OrderBy { get; set; }

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