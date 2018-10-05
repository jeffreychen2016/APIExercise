using APIExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExercise.DataAccess
{
    public class Network
    {

        public List<Clinker> ClinkerNetwork { get; set; }

        public Network()
        {
            ClinkerNetwork = new List<Clinker>
            {
                new Clinker
                {
                    Id = 1, Name = "Joe",
                    IsLonely = true,
                    Interests = { Interest.BoardGame, Interest.Reading } ,
                    Services = { new Service { Name = "Barber", Description = "Cut your hair" } },
                    FriendList = { new Clinker { Name = "John"} }
                },
                new Clinker
                {
                    Id = 2, Name = "Bob",
                    IsLonely = true,
                    Interests = { Interest.Reading },
                    Services = { new Service { Name = "Message", Description = "Full body message"} },
                    FriendList = { new Clinker { Name = "Pope"} }
                },
                new Clinker
                {
                    Id = 3, Name = "Kee",
                    IsLonely = true,
                    Interests = { Interest.Reading },
                    Services = { new Service { Name = "Story Reader", Description = "One stroy before you sleep" } },
                    FriendList = { new Clinker { Name = "Jason"} }
                },
            };
        }

        public void JoinNetwork(Clinker clinker)
        {
            clinker.Id = ClinkerNetwork.Any() ? ClinkerNetwork.Max(record => record.Id) + 1 : 1;
            ClinkerNetwork.Add(clinker);
        }

        public Clinker GetById(int id)
        {
            return ClinkerNetwork.FirstOrDefault(clinker => clinker.Id == id);
        }
    }
}
