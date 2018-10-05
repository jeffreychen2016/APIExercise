﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIExercise.DataAccess;
using APIExercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        private Prison _prison;
        private Network _network;

        public ClinkerController()
        {
            _prison = new Prison();
            _network = new Network();
        }

        [HttpGet("AllClinkers")]
        public ActionResult<IEnumerable<Clinker>> GetAllClinkers()
        {
            return _prison.ClinkerPrison;
        }

        [HttpPost("AddToPrison")]
        public void AddClinkerToPrison(Clinker clinker)
        {
            _prison.Add(clinker);
        }

        [HttpPost("JoinNetwork")]
        // {"name": "Joe","isLonely": true}
        public IActionResult JoinClickerNewwork(Clinker clinker)
        {
            if (clinker.IsLonely)
            {
                _network.JoinNetwork(clinker);
                return Content("A new clinker join the network");
            }
            else
            {
                return Content("You are not lonely,so...FUCK OFF!");
            }
        }

        [HttpGet("FindClinkerByInterest/{interest}")]
        // https:///localhost:44334/api/Clinker/FindClinkerByInterest/Reading
        public ActionResult<IEnumerable<Clinker>> FindClinkerByInterest(Interest interest)
        {
            var clinkers = from clinker in _network.ClinkerNetwork
                           where clinker.Interests.Contains(interest)
                           select clinker;
            return clinkers.ToList();
        }

        [HttpGet("ListMyServices/{myId}")]
        // https:///localhost:44334/api/Clinker/ListMyServices/1
        public ActionResult<IEnumerable<Service>> ListMyServices(int myId)
        {
            var myService = from clinker in _network.ClinkerNetwork
                            where clinker.Id == myId
                            select clinker.Services;
            return Ok(myService);
        }

        [HttpPut("{myId}/AddFriend/{friendId}")]
        //https:///localhost:44334/api/Clinker/1/AddFriend/2
        public IActionResult AddFriend(int myId, int friendId)
        {
            var me = _network.GetById(myId);
            var friend = _network.GetById(friendId);

            me.FriendList.Add(friend);
            return Ok();
        }

        [HttpPut("{myId}/AddEnemy/{enemyId}")]
        public IActionResult AddEnemy(int myId, int EnemyId)
        {
            var me = _network.GetById(myId);
            var enemy = _network.GetById(EnemyId);

            me.EnemyList.Add(enemy);
            return Ok();
        }

        [HttpPut("{myId}/PotentialCrew/{friendId}")]
        public ActionResult<IEnumerable<Clinker>> ListFriendsFriend(int myId, int friendId)
        {
            var me = _network.GetById(myId);
            var friend = _network.GetById(friendId);

            var myFriends = from clinker in _network.ClinkerNetwork
                                where clinker.Id == myId
                                select clinker.FriendList;
            return Ok(myFriends);
            // friendsfriend.Select(cl)
        }
    }
}