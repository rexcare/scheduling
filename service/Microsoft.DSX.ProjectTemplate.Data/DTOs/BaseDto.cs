using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace Microsoft.DSX.ProjectTemplate.Data.DTOs
{
    public abstract class BaseDto<TType>
    {
        public TType Id { get; set; }

        protected ModelStateDictionary ModelState { get; } = new ModelStateDictionary();

        public abstract bool IsValid();

        public virtual string GetValidationErrors()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var error in ModelState)
            {
                sb.AppendLine($"{error.Key} : {error.Value}");
            }

            return sb.ToString();
        }
    }
}
