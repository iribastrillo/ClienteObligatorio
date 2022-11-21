using Cliente.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Cliente.Models.VMs
{
    public class AdminViewModel
    {
        [Display(Name = "Local")]
        public int HomeId { get; set; }
        [Display(Name = "Visitante")]
        public int AwayId { get; set; }
        [Display(Name = "Mes")]
        public int Month { get; set; }
        [Display(Name = "Día")]
        public int Day { get; set; }
        [Display(Name = "Hora")]
        public int Hour { get; set; }
        [Display(Name = "Grupo")]
        public string Group { get; set; }
        [Display(Name = "País")]
        public int CountryId { get; set; }
        [Display(Name = "Nombre del contacto")]
        public string Name { get; set; }
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        [Display(Name = "Apostadores")]
        public int Bettors { get; set; }

    }
}
