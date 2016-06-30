using System;
using System.Collections.Generic;
using Nop.Core;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class Tournament : BaseEntity
    {
        public Tournament()
        {
            Deleted = false;
            Clubs = new List<TournamentClub>();
        }
        // Имя
        public string Name { get; set; }
        // Дата начала
        public DateTime StartDate { get; set; }
        // Дата окончания
        public DateTime EndDate { get; set; }
        // Тип
        public TournamentType Type { get; set; }
        // Места проведения
        public List<TournamentClub> Clubs { get; set; }
        // Рейтинги за занятые места
        public Dictionary<int, int> Rates { get; set; }

        public string RatesAsJSON
        {
            get { return string.Empty; }
            set { Rates = new Dictionary<int, int>(); }
        }
        // Удален
        public bool Deleted { get; set; }

        internal void CopyFrom(Tournament tournament)
        {
            Name = tournament.Name;
            StartDate = tournament.StartDate;
            EndDate = tournament.EndDate;
            Type = tournament.Type;
            Clubs = tournament.Clubs;
            Rates = tournament.Rates;
            Deleted = tournament.Deleted;
        }
    }
}
