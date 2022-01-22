using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
    public enum Volume
    {
        [Display(Name = "Litre")] Litre,
        [Display(Name = "Barrel")] Barrel,
        [Display(Name = "Hogs Head")] HogsHead,
        [Display(Name = "Barn-Megaparsec")] Barn_Megaparsec
    }
}
