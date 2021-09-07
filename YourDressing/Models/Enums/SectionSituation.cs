using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YourDressing.Models.Enums
{
    public enum SectionSituation
    {
        [Description("Ativa")]
        [Display(Name = "Ativa")]
        Active,

        [Description("Inoperante")]
        [Display(Name = "Inoperante")]
        Disabled
    }
}
