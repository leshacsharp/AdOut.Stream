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
    /// UpdateScheduleModel
    /// </summary>
    [DataContract]
        public partial class UpdateScheduleModel :  IEquatable<UpdateScheduleModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateScheduleModel" /> class.
        /// </summary>
        /// <param name="scheduleId">scheduleId.</param>
        /// <param name="planId">planId.</param>
        /// <param name="startTime">startTime.</param>
        /// <param name="endTime">endTime.</param>
        /// <param name="breakTime">breakTime.</param>
        /// <param name="playTime">playTime.</param>
        /// <param name="dayOfWeek">dayOfWeek.</param>
        /// <param name="date">date.</param>
        public UpdateScheduleModel(string scheduleId = default(string), string planId = default(string), string startTime = default(string), string endTime = default(string), string breakTime = default(string), string playTime = default(string), DayOfWeek dayOfWeek = default(DayOfWeek), DateTime? date = default(DateTime?))
        {
            this.ScheduleId = scheduleId;
            this.PlanId = planId;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.BreakTime = breakTime;
            this.PlayTime = playTime;
            this.DayOfWeek = dayOfWeek;
            this.Date = date;
        }
        
        /// <summary>
        /// Gets or Sets ScheduleId
        /// </summary>
        [DataMember(Name="scheduleId", EmitDefaultValue=false)]
        public string ScheduleId { get; set; }

        /// <summary>
        /// Gets or Sets PlanId
        /// </summary>
        [DataMember(Name="planId", EmitDefaultValue=false)]
        public string PlanId { get; set; }

        /// <summary>
        /// Gets or Sets StartTime
        /// </summary>
        [DataMember(Name="startTime", EmitDefaultValue=false)]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or Sets EndTime
        /// </summary>
        [DataMember(Name="endTime", EmitDefaultValue=false)]
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or Sets BreakTime
        /// </summary>
        [DataMember(Name="breakTime", EmitDefaultValue=false)]
        public string BreakTime { get; set; }

        /// <summary>
        /// Gets or Sets PlayTime
        /// </summary>
        [DataMember(Name="playTime", EmitDefaultValue=false)]
        public string PlayTime { get; set; }

        /// <summary>
        /// Gets or Sets DayOfWeek
        /// </summary>
        [DataMember(Name="dayOfWeek", EmitDefaultValue=false)]
        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name="date", EmitDefaultValue=false)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateScheduleModel {\n");
            sb.Append("  ScheduleId: ").Append(ScheduleId).Append("\n");
            sb.Append("  PlanId: ").Append(PlanId).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  BreakTime: ").Append(BreakTime).Append("\n");
            sb.Append("  PlayTime: ").Append(PlayTime).Append("\n");
            sb.Append("  DayOfWeek: ").Append(DayOfWeek).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
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
            return this.Equals(input as UpdateScheduleModel);
        }

        /// <summary>
        /// Returns true if UpdateScheduleModel instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateScheduleModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateScheduleModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ScheduleId == input.ScheduleId ||
                    (this.ScheduleId != null &&
                    this.ScheduleId.Equals(input.ScheduleId))
                ) && 
                (
                    this.PlanId == input.PlanId ||
                    (this.PlanId != null &&
                    this.PlanId.Equals(input.PlanId))
                ) && 
                (
                    this.StartTime == input.StartTime ||
                    (this.StartTime != null &&
                    this.StartTime.Equals(input.StartTime))
                ) && 
                (
                    this.EndTime == input.EndTime ||
                    (this.EndTime != null &&
                    this.EndTime.Equals(input.EndTime))
                ) && 
                (
                    this.BreakTime == input.BreakTime ||
                    (this.BreakTime != null &&
                    this.BreakTime.Equals(input.BreakTime))
                ) && 
                (
                    this.PlayTime == input.PlayTime ||
                    (this.PlayTime != null &&
                    this.PlayTime.Equals(input.PlayTime))
                ) && 
                (
                    this.DayOfWeek == input.DayOfWeek ||
                    (this.DayOfWeek != null &&
                    this.DayOfWeek.Equals(input.DayOfWeek))
                ) && 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
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
                if (this.ScheduleId != null)
                    hashCode = hashCode * 59 + this.ScheduleId.GetHashCode();
                if (this.PlanId != null)
                    hashCode = hashCode * 59 + this.PlanId.GetHashCode();
                if (this.StartTime != null)
                    hashCode = hashCode * 59 + this.StartTime.GetHashCode();
                if (this.EndTime != null)
                    hashCode = hashCode * 59 + this.EndTime.GetHashCode();
                if (this.BreakTime != null)
                    hashCode = hashCode * 59 + this.BreakTime.GetHashCode();
                if (this.PlayTime != null)
                    hashCode = hashCode * 59 + this.PlayTime.GetHashCode();
                if (this.DayOfWeek != null)
                    hashCode = hashCode * 59 + this.DayOfWeek.GetHashCode();
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                return hashCode;
            }
        }
    }
}
