using Dextra.Marvel.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Input
{
    /// <summary>
	/// Represents a set of filter properties for character search
	/// </summary>
    public class CharacterInput
    {
        /// <summary>
        /// Return only characters matching the specified full character name (e.g. Spider-Man).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Return characters with names that begin with the specified string (e.g. Sp).
        /// </summary>
        public string NameStartsWith { get; set; }

        /// <summary>
        /// Return only characters which have been modified since the specified date.
        /// </summary>
        public DateTime? ModifiedSince { get; set; }

        /// <summary>
        /// Return only characters which appear in the specified comics (accepts a comma-separated list of ids).
        /// </summary>
        public string Comics { get; set; }

        /// <summary>
        /// Return only characters which appear the specified series (accepts a comma-separated list of ids).
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Return only characters which appear in the specified events (accepts a comma-separated list of ids).
        /// </summary>
        public string Events { get; set; }

        /// <summary>
        /// Return only characters which appear the specified stories (accepts a comma-separated list of ids).
        /// </summary>
        public string Stories { get; set; }

        /// <summary>
        /// Order the result set by a field or fields. Add a "-" to the value sort in descending order. Multiple values are given priority in the order in which they are passed.
        /// </summary>
        public CharacterOrderByEnum OrderBy { get; set; }

        /// <summary>
        /// Limit the result set to the specified number of resources.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Skip the specified number of resources in the result set.
        /// </summary>
        public int? Offset { get; set; }
        
        [BindNeverAttribute]
        public int? CharacterId { get; set; }
    }
}
