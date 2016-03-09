using System;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Models.Player
{
    public class PlayerModel
    {
        public PlayerModel()
        {
            Gender = GenderType.Man;
            ForehandRight = true;
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
            get { return DateOfBirth.ToShortDateString(); }
        }

        public string City { get; set; }

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

        public PlayerLevel Level { get; set; }
    }
}
