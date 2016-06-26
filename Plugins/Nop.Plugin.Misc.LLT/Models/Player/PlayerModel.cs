using System;
using System.Globalization;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Models.Player
{
    public class PlayerModel
    {
        public PlayerModel()
        {
            Gender = GenderType.Man;
            ForehandRight = true;
            DateOfBirth = new DateTime(1900, 1, 1);
            PlayFrom = new DateTime(1900, 1, 1);
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

        public string Country { get; set; }

        public string CountryString
        {
            get
            {
                if (string.IsNullOrEmpty(Country))
                    return string.Empty;

                return Country;
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
    }
}