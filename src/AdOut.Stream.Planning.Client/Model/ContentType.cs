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
    /// Defines ContentType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
        public enum ContentType
    {
        /// <summary>
        /// Enum _0 for value: 0
        /// </summary>
        [EnumMember(Value = "0")]
        _0 = 1,
        /// <summary>
        /// Enum _1 for value: 1
        /// </summary>
        [EnumMember(Value = "1")]
        _1 = 2    }
}
