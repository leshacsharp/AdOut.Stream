/* 
 * AdOut.Planning API
 *
 * Access to Apps API
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SwaggerDateConverter = AdOut.Stream.Planning.Client.Client.SwaggerDateConverter;

namespace AdOut.Stream.Planning.Client.Model
{
    /// <summary>
    /// Defines DayOfWeek
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
        public enum DayOfWeek
    {
        /// <summary>
        /// Enum _0 for value: 0
        /// </summary>
        [EnumMember(Value = "0")]
        _0 = 0,
        /// <summary>
        /// Enum _1 for value: 1
        /// </summary>
        [EnumMember(Value = "1")]
        _1 = 1,
        /// <summary>
        /// Enum _2 for value: 2
        /// </summary>
        [EnumMember(Value = "2")]
        _2 = 2,
        /// <summary>
        /// Enum _3 for value: 3
        /// </summary>
        [EnumMember(Value = "3")]
        _3 = 3,
        /// <summary>
        /// Enum _4 for value: 4
        /// </summary>
        [EnumMember(Value = "4")]
        _4 = 4,
        /// <summary>
        /// Enum _5 for value: 5
        /// </summary>
        [EnumMember(Value = "5")]
        _5 = 5,
        /// <summary>
        /// Enum _6 for value: 6
        /// </summary>
        [EnumMember(Value = "6")]
        _6 = 6    }
}