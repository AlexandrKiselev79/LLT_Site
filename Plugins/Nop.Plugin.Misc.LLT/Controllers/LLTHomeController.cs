using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    public class LLTHomeController : BaseController
    {
        private IRepository<Match> _matchesRepository;
        
        public LLTHomeController(IRepository<Match> matchesRepository)
        {
            _matchesRepository = matchesRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Players()
        {
            var player1 = new Player
            {
                City = "City1",
                DateOfBirth = DateTime.Now.AddYears(-20),
                FirstName = "First",
                Height = 175,
                LastName = "FirstLast",
                MiddleName = "FirstMiddle",
                Weight = 100
            };
            var player2 = new Player
            {
                City = "City2",
                DateOfBirth = DateTime.Now.AddYears(-20),
                FirstName = "Second",
                Height = 180,
                LastName = "SecondLast",
                MiddleName = "SecondMiddle",
                Weight = 90
            };


            _matchesRepository.Insert(new Match
            {
                Player1 = player1,
                Player2 = player2,
                
                StartDateTime = DateTime.Now,
                CourtNumber = 1,
                Club = new TennisClub
                {
                    Address = new Address
                    {
                        Country = "Belarus",
                        City = "Minsk"
                    },
                    Courts = new Dictionary<CourtType, int>
                    {
                        {CourtType.Hard, 6},
                        {CourtType.Clay, 4},
                    },
                    Name = "Club1"
                },
                SetResults = new List<SetResult>
                {
                    new SetResult
                    {
                        Number = 1,
                        Player1Games = 7,
                        Player2Games = 6,
                        Player1TieBreak = 10,
                        Player2TieBreak = 6,
                        Player1 = player1,
                        Player2 = player2
                    },
                    new SetResult
                    {
                        Number = 2,
                        Player1Games = 6,
                        Player2Games = 7,
                        Player1TieBreak = 6,
                        Player2TieBreak = 10,
                        Player1 = player1,
                        Player2 = player2
                    }
                },
                TieBreakResult = new TieBreakResult
                {
                    Player1 = player1,
                    Player2 = player2,
                    Player1TieBreak = 11,
                    Player2TieBreak = 6
                }
            });

            

            return View();
        }
    }
}
