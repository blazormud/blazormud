using System.ComponentModel.DataAnnotations;
namespace BlazorMUD.Core.Models
{
    public class LinkInstance
    {
        [Key]
        public long Id { get; set; }

        public LinkTemplate Template { get; set; }
    }
}
