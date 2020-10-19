using Dextra.Marvel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Input
{
    /// <summary>
	/// Represents a set of filter properties for comic search
	/// </summary>
    public class ComicInput
    {
        /// <summary>
        /// Filter by the issue format (e.g. comic, digital comic, hardcover).
        /// </summary>
        public ComicFormatEnum Format { get; set; }

        /// <summary>
        /// Filter by the issue format type (comic or collection).
        /// </summary>
        public ComicFormatTypeEnum FormatType { get; set; }

        /// <summary>
        /// Exclude variant comics from the result set.
        /// </summary>
        public NoVariantEnum NoVariants { get; set; }

        /// <summary>
        /// Return comics within a predefined date range.
        /// </summary>
        public DateDescriptiorEnum dateDescriptior { get; set; }

        /// <summary>
        /// Return comics within a predefined date range. Dates must be specified as date1,date2 (e.g. 2013-01-01,2013-01-02). Dates are preferably formatted as YYYY-MM-DD but may be sent as any common date format.
        /// </summary>
        public DateTime? DateRange { get; set; }

        /// <summary>
        /// Return only issues in series whose title matches the input.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Return only issues in series whose title starts with the input.
        /// </summary>
        public string TitleStartsWith { get; set; }

        /// <summary>
        /// Return only issues in series whose start year matches the input.
        /// </summary>
        public int? StartYear { get; set; }

        /// <summary>
        /// Return only issues in series whose issue number matches the input.
        /// </summary>
        public int? IssueNumber { get; set; }

        /// <summary>
        /// Filter by diamond code.
        /// </summary>
        public string DiamondCode { get; set; }

        /// <summary>
        /// Filter by digital comic id.
        /// </summary>
        public int? DigitalId { get; set; }

        /// <summary>
        /// Filter by UPC.
        /// </summary>
        public string Upc { get; set; }

        /// <summary>
        /// Filter by ISBN.
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// Filter by EAN.
        /// </summary>
        public string Ean { get; set; }

        /// <summary>
        /// Filter by ISSN.
        /// </summary>
        public string Issn { get; set; }

        /// <summary>
        /// Include only results which are available digitally.
        /// </summary>
        public HasDigitalIssueEnum HasDigitalIssue { get; set; }

        /// <summary>
        /// Return only comics which have been modified since the specified date.
        /// </summary>
        public DateTime? ModifiedSince { get; set; }

        /// <summary>
        /// Return only comics which appear in the specified creators (accepts a comma-separated list of ids).
        /// </summary>
        public string Creators { get; set; }

        /// <summary>
        /// Return only comics which appear the specified series (accepts a comma-separated list of ids).
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Return only comics which appear in the specified events (accepts a comma-separated list of ids).
        /// </summary>
        public string Events { get; set; }

        /// <summary>
        /// Return only comics which appear in the specified stories (accepts a comma-separated list of ids).
        /// </summary>
        public string Stories { get; set; }

        /// <summary>
        /// Return only comics in which the specified characters appear together (for example in which BOTH Spider-Man and Wolverine appear).
        /// </summary>
        public string SharedAppearances { get; set; }

        /// <summary>
        /// Return only comics in which the specified creators worked together (for example in which BOTH Stan Lee and Jack Kirby did work).
        /// </summary>
        public string Collaborators { get; set; }

        /// <summary>
        /// Order the result set by a field or fields. Add a "-" to the value sort in descending order. Multiple values are given priority in the order in which they are passed.
        /// </summary>
        public ComicOrderByEnum OrderBy { get; set; }

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
