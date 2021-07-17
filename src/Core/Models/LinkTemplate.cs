using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlazorMUD.Core.Models
{
    public class LinkTemplate
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey(nameof(Source))]
        public long SourceId { get; set; }
        [JsonIgnore]
        public AreaTemplate Source { get; set; }

        [Required]
        [ForeignKey(nameof(Destination))]
        public long DestinationId { get; set; }
        [JsonIgnore]
        public AreaTemplate Destination { get; set; }
    }
}
