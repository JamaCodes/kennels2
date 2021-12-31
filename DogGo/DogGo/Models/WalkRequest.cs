using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class WalkRequest
    {
        public int Id { get; set; }
        public Owner Owner { get; set; }
        public Walker Walker { get; set; }
        public Dog Dog { get; set; }
        public int DogId { get; set; }
        public int OwnerId { get; set; }
        public int WalkerId { get; set; }

        public string Message { get; set; }

        public bool Request { get; set; }

        public DateTimeOffset RequestDateTime { get; set; }

        public DateTimeOffset Created { get; set; }

       

       
    }
}
