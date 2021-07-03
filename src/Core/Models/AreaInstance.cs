using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorMUD.Core.Models
{
    public class AreaInstance
    {
        [Key]
        public long Id { get; set; }

        public AreaTemplate Template { get; set; }

        public IEnumerable<LinkInstance> Links { get; set; }
    }
}
