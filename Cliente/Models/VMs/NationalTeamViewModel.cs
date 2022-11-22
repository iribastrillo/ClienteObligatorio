using System.ComponentModel.DataAnnotations;

namespace Cliente.Models.VMs
{
    public class NationalTeamViewModel
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Nombre del contacto")]
        public string name { get; set; }
        [Display(Name = "Teléfono del contacto")]
        public string phone { get; set; }
        [Display(Name = "Correo electrónico")]
        public string email { get; set; }
        [Display(Name = "Cantidad de apostadores")]
        public int bettors { get; set; }
        [Display(Name = "ID del país")]
        public int idCountry { get; set; }
    }
}
