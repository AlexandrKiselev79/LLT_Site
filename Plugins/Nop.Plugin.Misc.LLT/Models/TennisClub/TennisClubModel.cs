using System;
using System.Collections.Generic;
using System.Text;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Service;

namespace Nop.Plugin.Misc.LLT.Models.TennisClub
{
    public class TennisClubModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public Address Address { get; set; }

        //public string ShortAddressString
        //{
        //    get { return string.Format("{0}, {1}", Address.Country, Address.City); }
        //}

        public string Email { get; set; }

        public string Description { get; set; }

        public Dictionary<CourtType, int> Courts { get; set; }

        public string CourtsString
        {
            get
            {
                var result = new StringBuilder();

                foreach (var court in Courts)
                {
                    result.Append(string.Format("{0}: {1}{2}", EnumService.CourtTypeString(court.Key), court.Value,
                        Environment.NewLine));
                }

                return result.ToString();
            }
        }
    }
}
