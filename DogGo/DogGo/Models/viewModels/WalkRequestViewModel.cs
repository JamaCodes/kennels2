using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models.viewModels
{
    public class WalkRequestViewModel
    {
        public Owner OwnerId { get; }
        public Walker WalkerId { get; }

        public string Message { get; }

        public DateTimeOffset RequestDateTime { get; }

        public DateTimeOffset Created { get; }

        public WalkRequestViewModel(string message, DateTimeOffset requestedDateTime)
        {
            Message = message;
            Created = DateTimeOffset.UtcNow;
            RequestDateTime = requestedDateTime;
    }
    }
}
