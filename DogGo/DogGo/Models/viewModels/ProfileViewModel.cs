using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;





namespace DogGo.Models.viewModels
{
    public class ProfileViewModel
    {
        public Owner Owner { get; set; }
        public List<Walker> Walkers { get; set; }
        public List<Dog> Dogs { get; set; }
    }
}
