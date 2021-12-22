using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class WalkRequest
    {
        public int Id { get; set; }
        public Owner OwnerId { get; set; }
        public Walker WalkerId { get; set; }
        public Dog DogId { get; set; }

        public string Message { get; set; }

        public DateTimeOffset RequestDateTime { get; set; }

        public DateTimeOffset Created { get; set; }

        public WalkRequest(string message, DateTimeOffset requestedDateTime, Owner ownerId, Dog dogId)
        {
            OwnerId = ownerId;
            DogId = dogId;
            Message = message;
            Created = DateTimeOffset.UtcNow;
            RequestDateTime = requestedDateTime;
        }
    }
}
