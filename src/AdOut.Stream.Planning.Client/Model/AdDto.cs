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
    /// AdDto
    /// </summary>
    [DataContract]
        public partial class AdDto :  IEquatable<AdDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdDto" /> class.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <param name="title">title.</param>
        /// <param name="contentType">contentType.</param>
        /// <param name="status">status.</param>
        /// <param name="path">path.</param>
        /// <param name="addedDate">addedDate.</param>
        /// <param name="confirmationDate">confirmationDate.</param>
        /// <param name="plans">plans.</param>
        public AdDto(string userId = default(string), string title = default(string), ContentType contentType = default(ContentType), AdStatus status = default(AdStatus), string path = default(string), DateTime? addedDate = default(DateTime?), DateTime? confirmationDate = default(DateTime?), List<AdPlanDto> plans = default(List<AdPlanDto>))
        {
            this.UserId = userId;
            this.Title = title;
            this.ContentType = contentType;
            this.Status = status;
            this.Path = path;
            this.AddedDate = addedDate;
            this.ConfirmationDate = confirmationDate;
            this.Plans = plans;
        }
        
        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name="userId", EmitDefaultValue=false)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets ContentType
        /// </summary>
        [DataMember(Name="contentType", EmitDefaultValue=false)]
        public ContentType ContentType { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public AdStatus Status { get; set; }

        /// <summary>
        /// Gets or Sets Path
        /// </summary>
        [DataMember(Name="path", EmitDefaultValue=false)]
        public string Path { get; set; }

        /// <summary>
        /// Gets or Sets AddedDate
        /// </summary>
        [DataMember(Name="addedDate", EmitDefaultValue=false)]
        public DateTime? AddedDate { get; set; }

        /// <summary>
        /// Gets or Sets ConfirmationDate
        /// </summary>
        [DataMember(Name="confirmationDate", EmitDefaultValue=false)]
        public DateTime? ConfirmationDate { get; set; }

        /// <summary>
        /// Gets or Sets Plans
        /// </summary>
        [DataMember(Name="plans", EmitDefaultValue=false)]
        public List<AdPlanDto> Plans { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AdDto {\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  ContentType: ").Append(ContentType).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  AddedDate: ").Append(AddedDate).Append("\n");
            sb.Append("  ConfirmationDate: ").Append(ConfirmationDate).Append("\n");
            sb.Append("  Plans: ").Append(Plans).Append("\n");
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
            return this.Equals(input as AdDto);
        }

        /// <summary>
        /// Returns true if AdDto instances are equal
        /// </summary>
        /// <param name="input">Instance of AdDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AdDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.ContentType == input.ContentType ||
                    (this.ContentType != null &&
                    this.ContentType.Equals(input.ContentType))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.Path == input.Path ||
                    (this.Path != null &&
                    this.Path.Equals(input.Path))
                ) && 
                (
                    this.AddedDate == input.AddedDate ||
                    (this.AddedDate != null &&
                    this.AddedDate.Equals(input.AddedDate))
                ) && 
                (
                    this.ConfirmationDate == input.ConfirmationDate ||
                    (this.ConfirmationDate != null &&
                    this.ConfirmationDate.Equals(input.ConfirmationDate))
                ) && 
                (
                    this.Plans == input.Plans ||
                    this.Plans != null &&
                    input.Plans != null &&
                    this.Plans.SequenceEqual(input.Plans)
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
                if (this.UserId != null)
                    hashCode = hashCode * 59 + this.UserId.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.ContentType != null)
                    hashCode = hashCode * 59 + this.ContentType.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Path != null)
                    hashCode = hashCode * 59 + this.Path.GetHashCode();
                if (this.AddedDate != null)
                    hashCode = hashCode * 59 + this.AddedDate.GetHashCode();
                if (this.ConfirmationDate != null)
                    hashCode = hashCode * 59 + this.ConfirmationDate.GetHashCode();
                if (this.Plans != null)
                    hashCode = hashCode * 59 + this.Plans.GetHashCode();
                return hashCode;
            }
        }
    }
}