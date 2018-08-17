using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbEg2.Models
{
    public class Schedule
    {
        //[BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public string Date { get; set; }
        public int Hours { get; set; }
        public string TopicsTaken { get; set; }
        public string Remarks { get; set; }
    }
}