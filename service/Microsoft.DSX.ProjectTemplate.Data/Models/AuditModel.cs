using System;

namespace Microsoft.DSX.ProjectTemplate.Data.Models
{
    public abstract class AuditModel<TType> : BaseModel<TType>
    {
        /// <summary>
        /// Tracks when this entity was first persisted to the database.
        /// </summary>
        /// <remarks>Managed at the Entity Framework-level. Do not manually set.</remarks>
        public DateTime CreatedDate { get; internal set; }

        /// <summary>
        /// Tracks when this entity was last updated.
        /// </summary>
        /// <remarks>Managed at the Entity Framework-level. Do not manually set.</remarks>
        public DateTime UpdatedDate { get; internal set; }
    }
}
