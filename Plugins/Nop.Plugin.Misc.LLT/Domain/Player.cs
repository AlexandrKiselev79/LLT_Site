using System;
using Nop.Core;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class Player: BaseEntity
    {
        public Player()
        {
            ForehandRight = true;
            Deleted = false;
            Gender = GenderType.Man;
        }
        // Имя
        public string FirstName { get; set; }
        // Фамилия
        public string LastName { get; set; }
        // Отчество
        public string MiddleName { get; set; }
        // Дата рождения
        public DateTime DateOfBirth { get; set; }
        // Город
        public string City { get; set; }
        // Правша-Левша
        public bool ForehandRight { get; set; }
        // Пол
        public GenderType Gender { get; set; }
        // Рост
        public decimal Height { get; set; }
        // Вес
        public decimal Weight { get; set; }
        // Играет с ...
        public DateTime PlayFrom { get; set; }
        // Уровень игрока
        public PlayerLevel Level { get; set; }
        // Неактивен
        public bool Deleted { get; set; }
    }
}
