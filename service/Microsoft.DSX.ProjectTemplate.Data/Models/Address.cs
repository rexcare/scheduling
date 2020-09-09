using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.DSX.ProjectTemplate.Data.Models
{
    [Owned]
    public class Address
    {
        [MaxLength(Constants.MaximumLengths.StringColumn)]
        public string AddressLine1 { get; set; }

        [MaxLength(Constants.MaximumLengths.StringColumn)]
        public string AddressLine2 { get; set; }

        [MaxLength(Constants.MaximumLengths.StringColumn)]
        public string City { get; set; }

        [MaxLength(Constants.MaximumLengths.StringColumn)]
        public string StateProvince { get; set; }

        [MaxLength(Constants.MaximumLengths.StringColumn)]
        public string ZipCode { get; set; }

        [MaxLength(Constants.MaximumLengths.StringColumn)]
        public string Country { get; set; }
    }
}
