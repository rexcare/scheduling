using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.DSX.ProjectTemplate.Data.Models
{
    [Owned]
    public class Address
    {
        [MaxLength(512)]
        public string LocationAddressLine1 { get; set; }

        [MaxLength(512)]
        public string LocationAddressLine2 { get; set; }

        [MaxLength(512)]
        public string LocationCity { get; set; }

        [MaxLength(512)]
        public string LocationStateProvince { get; set; }

        [MaxLength(512)]
        public string LocationZipCode { get; set; }

        [MaxLength(512)]
        public string LocationCountry { get; set; }
    }
}
