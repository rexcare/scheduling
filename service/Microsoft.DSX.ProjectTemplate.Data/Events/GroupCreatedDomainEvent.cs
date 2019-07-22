using MediatR;
using Microsoft.DSX.ProjectTemplate.Data.Models;

namespace Microsoft.DSX.ProjectTemplate.Data.Events
{
    public class GroupCreatedDomainEvent : INotification
    {
        public GroupCreatedDomainEvent(Group group)
        {
            Group = group;
        }

        public Group Group { get; }
    }
}
