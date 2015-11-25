﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ConsotoUniWebApp.Models
{
    public partial class Course
    {
        private int? _completionStatus;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? CompletionStatus
        {
            get { return this._completionStatus; }
            set { this._completionStatus = value; }
        }
        
        private int? _courseID;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? CourseID
        {
            get { return this._courseID; }
            set { this._courseID = value; }
        }
        
        private int? _coursePercentage;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? CoursePercentage
        {
            get { return this._coursePercentage; }
            set { this._coursePercentage = value; }
        }
        
        private int? _credits;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Credits
        {
            get { return this._credits; }
            set { this._credits = value; }
        }
        
        private int? _finalGrade;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? FinalGrade
        {
            get { return this._finalGrade; }
            set { this._finalGrade = value; }
        }
        
        private string _title;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Course class.
        /// </summary>
        public Course()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken completionStatusValue = inputObject["CompletionStatus"];
                if (completionStatusValue != null && completionStatusValue.Type != JTokenType.Null)
                {
                    this.CompletionStatus = ((int)completionStatusValue);
                }
                JToken courseIDValue = inputObject["CourseID"];
                if (courseIDValue != null && courseIDValue.Type != JTokenType.Null)
                {
                    this.CourseID = ((int)courseIDValue);
                }
                JToken coursePercentageValue = inputObject["CoursePercentage"];
                if (coursePercentageValue != null && coursePercentageValue.Type != JTokenType.Null)
                {
                    this.CoursePercentage = ((int)coursePercentageValue);
                }
                JToken creditsValue = inputObject["Credits"];
                if (creditsValue != null && creditsValue.Type != JTokenType.Null)
                {
                    this.Credits = ((int)creditsValue);
                }
                JToken finalGradeValue = inputObject["FinalGrade"];
                if (finalGradeValue != null && finalGradeValue.Type != JTokenType.Null)
                {
                    this.FinalGrade = ((int)finalGradeValue);
                }
                JToken titleValue = inputObject["Title"];
                if (titleValue != null && titleValue.Type != JTokenType.Null)
                {
                    this.Title = ((string)titleValue);
                }
            }
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type Course
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.CompletionStatus != null)
            {
                outputObject["CompletionStatus"] = this.CompletionStatus.Value;
            }
            if (this.CourseID != null)
            {
                outputObject["CourseID"] = this.CourseID.Value;
            }
            if (this.CoursePercentage != null)
            {
                outputObject["CoursePercentage"] = this.CoursePercentage.Value;
            }
            if (this.Credits != null)
            {
                outputObject["Credits"] = this.Credits.Value;
            }
            if (this.FinalGrade != null)
            {
                outputObject["FinalGrade"] = this.FinalGrade.Value;
            }
            if (this.Title != null)
            {
                outputObject["Title"] = this.Title;
            }
            return outputObject;
        }
    }
}