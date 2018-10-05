using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExercise.Models
{
    public class Clinker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLonely { get; set; }
        public List<Service> Services { get; set; }
        public List<Interest> Interests { get; set; }
    }
}
