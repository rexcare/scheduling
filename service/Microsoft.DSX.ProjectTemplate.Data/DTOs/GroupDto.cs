namespace Microsoft.DSX.ProjectTemplate.Data.DTOs
{
    public class GroupDto : AuditDto<int>
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                ModelState.AddModelError(nameof(Name), $"{nameof(Name)} cannot be null or empty.");
            }

            return ModelState.IsValid;
        }
    }
}
