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
        public List<Service> Services { get; set; } = new List<Service>();
        // *** need to initialize the list, otherwise when set the property in clinker, will get null exeception
        public List<Interest> Interests { get; set; } = new List<Interest>();
        public List<Clinker> FriendList { get; set; } = new List<Clinker>();
        public List<Clinker> EnemyList { get; set; } = new List<Clinker>();
    }
}
