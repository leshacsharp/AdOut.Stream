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
    /// Defines AdStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
        public enum AdStatus
    {
        /// <summary>
        /// Enum OnModeration for value: OnModeration
        /// </summary>
        [EnumMember(Value = "OnModeration")]
        OnModeration = 0,
        /// <summary>
        /// Enum Rejected for value: Rejected
        /// </summary>
        [EnumMember(Value = "Rejected")]
        Rejected = 1,
        /// <summary>
        /// Enum Accepted for value: Accepted
        /// </summary>
        [EnumMember(Value = "Accepted")]
        Accepted = 2    }
}