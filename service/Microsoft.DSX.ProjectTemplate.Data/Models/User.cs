using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.DSX.ProjectTemplate.Data.Models
{
    public class User : AuditModel<int>
    {
        [MaxLength(Constants.MaximumLengths.StringColumn)]
        public string DisplayName { get; set; }

        public IDictionary<string, string> Metadata { get; set; }
    }
}
