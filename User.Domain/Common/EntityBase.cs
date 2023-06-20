using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace User.Domain.Common
{
    public abstract class EntityBase 
    {
        [BsonId]
        public ObjectId Id { get; set; }

    }
}
