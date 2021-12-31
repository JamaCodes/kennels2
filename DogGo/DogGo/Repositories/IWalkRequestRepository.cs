using DogGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Repositories
{
    public interface IWalkRequestRepository
    {
       void MakeRequest(WalkRequest walkRequest);
    }
}
