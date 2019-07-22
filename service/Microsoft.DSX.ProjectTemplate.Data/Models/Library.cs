using System.ComponentModel.DataAnnotations;

namespace Microsoft.DSX.ProjectTemplate.Data.Models
{
    public class Library : AuditModel<int>
    {
        [MaxLength(512)]
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
