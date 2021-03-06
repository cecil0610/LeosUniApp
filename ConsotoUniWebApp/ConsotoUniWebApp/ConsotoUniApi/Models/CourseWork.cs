﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ConsotoUniWebApp.Models
{
    public partial class CourseWork
    {
        private int? _courseWorkID;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? CourseWorkID
        {
            get { return this._courseWorkID; }
            set { this._courseWorkID = value; }
        }
        
        private DateTimeOffset? _dueDate;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? DueDate
        {
            get { return this._dueDate; }
            set { this._dueDate = value; }
        }
        
        private int? _grade;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Grade
        {
            get { return this._grade; }
            set { this._grade = value; }
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
        
        private int? _workType;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? WorkType
        {
            get { return this._workType; }
            set { this._workType = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the CourseWork class.
        /// </summary>
        public CourseWork()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken courseWorkIDValue = inputObject["CourseWorkID"];
                if (courseWorkIDValue != null && courseWorkIDValue.Type != JTokenType.Null)
                {
                    this.CourseWorkID = ((int)courseWorkIDValue);
                }
                JToken dueDateValue = inputObject["DueDate"];
                if (dueDateValue != null && dueDateValue.Type != JTokenType.Null)
                {
                    this.DueDate = ((DateTimeOffset)dueDateValue);
                }
                JToken gradeValue = inputObject["Grade"];
                if (gradeValue != null && gradeValue.Type != JTokenType.Null)
                {
                    this.Grade = ((int)gradeValue);
                }
                JToken titleValue = inputObject["Title"];
                if (titleValue != null && titleValue.Type != JTokenType.Null)
                {
                    this.Title = ((string)titleValue);
                }
                JToken workTypeValue = inputObject["WorkType"];
                if (workTypeValue != null && workTypeValue.Type != JTokenType.Null)
                {
                    this.WorkType = ((int)workTypeValue);
                }
            }
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type CourseWork
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.CourseWorkID != null)
            {
                outputObject["CourseWorkID"] = this.CourseWorkID.Value;
            }
            if (this.DueDate != null)
            {
                outputObject["DueDate"] = this.DueDate.Value;
            }
            if (this.Grade != null)
            {
                outputObject["Grade"] = this.Grade.Value;
            }
            if (this.Title != null)
            {
                outputObject["Title"] = this.Title;
            }
            if (this.WorkType != null)
            {
                outputObject["WorkType"] = this.WorkType.Value;
            }
            return outputObject;
        }
    }
}
