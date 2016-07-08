using System;
using System.Globalization;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Infrastructure;

namespace Nop.Plugin.Misc.LLT.Models.Player
{
    public class PlayerModel
    {
        public PlayerModel()
        {
            Ranking = new RankingModel();
            Gender = GenderType.Man;
            ForehandRight = true;
            DateOfBirth = Constants.MinimalSqlDate;
            PlayFrom = Constants.MinimalSqlDate;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", LastName, FirstName); }
        }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string DateOfBirthString
        {
            get
            {
                var ci = new CultureInfo("ru-RU");
                return DateOfBirth.ToString("dd MMMM yyyy", ci);
            }
        }

        public string Age
        {
            get
            {
                string age = "";

                if (this.DateOfBirth > Constants.MinimalSqlDate)
                {
                    age = ((int)((DateTime.Now - this.DateOfBirth).Days / 365)).ToString();
                }
                return age;
            }
        }

        public Country Country { get; set; }

        public string CountryString
        {
            get
            {
                if (this.Country == Country.None)
                    return string.Empty;

                return Enum.GetName(typeof(Country), this.Country);
            }
        }

        public string City { get; set; }

        public string CityString
        {
            get
            {
                if (string.IsNullOrEmpty(City))
                    return string.Empty;

                return City;
            }
        }

        public string LivingPlace
        {
            get
            {
                var country = this.CountryString;
                var city = this.CityString;

                var livingPlace = country != string.Empty && city != string.Empty ?
                        string.Format("{0}, {1}", country, city) :
                        country != string.Empty ?
                        country : city;
                return livingPlace;
            }
        }

        public bool ForehandRight { get; set; }

        public string ForehandRightString
        {
            get { return ForehandRight ? "Правша" : "Левша"; }
        }

        public GenderType Gender { get; set; }

        public decimal Height { get; set; }

        public string HeightString
        {
            get { return Height.ToString("#.##"); }
        }

        public decimal Weight { get; set; }

        public string WeightString
        {
            get { return Weight.ToString("#.##"); }
        }

        public DateTime PlayFrom { get; set; }

        public string PlayFromString
        {
            get
            {
                var ci = new CultureInfo("ru-RU");
                return PlayFrom.ToString("dd MMMM yyyy", ci);
            }
        }

        public PlayerLevel Level { get; set; }

        public string LevelString
        {
            get
            {
                return Enum.GetName(typeof(PlayerLevel), Level);
            }
        }

        public RankingModel Ranking { get; set; }
    }
}