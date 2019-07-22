using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.DSX.ProjectTemplate.Data.Models
{
    public class User : AuditModel<int>
    {
        [MaxLength(512)]
        public string DisplayName { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}
