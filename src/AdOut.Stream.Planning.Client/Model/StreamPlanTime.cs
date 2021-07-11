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
    /// StreamPlanTime
    /// </summary>
    [DataContract]
        public partial class StreamPlanTime :  IEquatable<StreamPlanTime>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StreamPlanTime" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="title">title.</param>
        /// <param name="ads">ads.</param>
        /// <param name="schedules">schedules.</param>
        public StreamPlanTime(string id = default(string), string title = default(string), List<AdPlanTime> ads = default(List<AdPlanTime>), List<SchedulePeriod> schedules = default(List<SchedulePeriod>))
        {
            this.Id = id;
            this.Title = title;
            this.Ads = ads;
            this.Schedules = schedules;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="Title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Ads
        /// </summary>
        [DataMember(Name="Ads", EmitDefaultValue=false)]
        public List<AdPlanTime> Ads { get; set; }

        /// <summary>
        /// Gets or Sets Schedules
        /// </summary>
        [DataMember(Name="Schedules", EmitDefaultValue=false)]
        public List<SchedulePeriod> Schedules { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamPlanTime {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Ads: ").Append(Ads).Append("\n");
            sb.Append("  Schedules: ").Append(Schedules).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as StreamPlanTime);
        }

        /// <summary>
        /// Returns true if StreamPlanTime instances are equal
        /// </summary>
        /// <param name="input">Instance of StreamPlanTime to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StreamPlanTime input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Ads == input.Ads ||
                    this.Ads != null &&
                    input.Ads != null &&
                    this.Ads.SequenceEqual(input.Ads)
                ) && 
                (
                    this.Schedules == input.Schedules ||
                    this.Schedules != null &&
                    input.Schedules != null &&
                    this.Schedules.SequenceEqual(input.Schedules)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Ads != null)
                    hashCode = hashCode * 59 + this.Ads.GetHashCode();
                if (this.Schedules != null)
                    hashCode = hashCode * 59 + this.Schedules.GetHashCode();
                return hashCode;
            }
        }
    }
}
