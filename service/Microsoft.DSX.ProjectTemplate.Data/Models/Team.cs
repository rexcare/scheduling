using System.ComponentModel.DataAnnotations;

namespace Microsoft.DSX.ProjectTemplate.Data.Models
{
    public class Team : AuditModel<int>
    {
        [MaxLength(512)]
        public string Name { get; set; }

        public virtual Group Group { get; set; }

        public int GroupId { get; set; }
    }
}
