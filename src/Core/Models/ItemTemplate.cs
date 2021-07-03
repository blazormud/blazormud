using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlazorMUD.Core.Enums;

namespace BlazorMUD.Core.Models
{
    public class ItemTemplate
    {
        [Key]
        public long Id { get; set; }

        // "Sword +1"
        [Required(ErrorMessage = "A name is requried.")]
        public string Name { get; set; } = "Unknown Object";

        // "A long glowing sword with runes carved into the blade."
        [Required(ErrorMessage = "A description is requried.")]
        public string Description { get; set; } = "An undescribed and unknown object.";

        // "sword"
        [Required(ErrorMessage = "A short name is requried.")]
        public string ShortName { get; set; } = "object";

        // "glowing sword"
        [Required(ErrorMessage = "A long name is requried.")]
        public string LongName { get; set; } = "unknown object";

        // "a" or "an"
        [Required(ErrorMessage = "An article is required.")]
        public ArticleType Article { get; set; } = ArticleType.An;
    }
}
