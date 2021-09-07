using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YourDressing.Models.Enums
{
    public enum EmployeeSituation
    {
        [Description("Ativo(a)")]
        [Display(Name = "Ativo(a)")]
        Active,

        [Description("Demitido(a)")]
        [Display(Name = "Demitido(a)")]
        Fired
    }
}
