using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
    public enum Time
    {
        [Display(Name = "Hour")] Hour,
        [Display(Name = "Shake")] Shake//defined as 10 nanoseconds
    }
}
