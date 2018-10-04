using APIExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExercise.DataAccess
{
    public class Prison
    {
        public List<Clinker> ClinkerPrison { get; set; }


        public Prison()
        {
            ClinkerPrison = new List<Clinker>
            {
                new Clinker { Id = 1, Name = "Joe", IsLonely = true},
                new Clinker { Id = 2, Name = "Bob", IsLonely = true},
                new Clinker { Id = 3, Name = "Kee", IsLonely = true},
            };
        }

        public void Add(Clinker clinker)
        {
            clinker.Id = ClinkerPrison.Any() ? ClinkerPrison.Max(record => record.Id) + 1 : 1;
            ClinkerPrison.Add(clinker);
        }
    }
}
