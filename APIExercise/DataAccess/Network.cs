using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExercise.Models
{
    public class Network
    {
        // need to initialize the list to an empty list
        // otherwise the ClinkerNetwork property will be null
        public List<Clinker> ClinkerNetwork { get; set; } = new List<Clinker>();

        public void JoinNetwork(Clinker clinker)
        {
            clinker.Id = ClinkerNetwork.Any() ? ClinkerNetwork.Max(record => record.Id) + 1 : 1;
            ClinkerNetwork.Add(clinker);
        }
    }
}
