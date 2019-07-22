using System.ComponentModel.DataAnnotations;

namespace Microsoft.DSX.ProjectTemplate.Data.Models
{
    public abstract class BaseModel<TType>
    {
        [Key]
        public TType Id { get; set; }
    }
}
