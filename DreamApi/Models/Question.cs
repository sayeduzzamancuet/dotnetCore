using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DreamApi.Models
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string AskedQuestion { get; set; }
        public string Answer { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Stack { get; set; }

    }
}
