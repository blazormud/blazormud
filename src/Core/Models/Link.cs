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

        [Required]
        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public Region Region { get; set; }
    }

    public class LinkInstance
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Template")]
        public long TemplateId { get; set; }
        public LinkTemplate Template { get; set; }

        [Required]
        [ForeignKey(nameof(Source))]
        public long SourceId { get; set; }
        [JsonIgnore]
        public AreaInstance Source { get; set; }
    }
}