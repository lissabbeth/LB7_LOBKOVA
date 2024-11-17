using System.ComponentModel.DataAnnotations;

namespace LB7_LOBKOVA
{
    public class Division
    {
        [Key] // Первичный ключ
        public int Id { get; set; }

        [Required] // Поле обязательно
        public string Name { get; set; } // Название отдела

        public double? Budget { get; set; } // Бюджет

        public int? Employees { get; set; } // Количество сотрудников

        public string Manager { get; set; } // Менеджер отдела
    }
}
