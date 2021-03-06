﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using ConsotoUniWebApp.Models;
using Newtonsoft.Json.Linq;

namespace ConsotoUniWebApp.Models
{
    public static partial class StudentCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<Student> DeserializeJson(JToken inputObject)
        {
            IList<Student> deserializedObject = new List<Student>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                Student student = new Student();
                student.DeserializeJson(iListValue);
                deserializedObject.Add(student);
            }
            return deserializedObject;
        }
    }
}
