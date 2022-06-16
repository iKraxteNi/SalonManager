using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManager.Shared.ResponsesDTOs
{
    public class CustomerGetDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string FullNameCastomer { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public bool IsDelate { get; set; } 
    }
}
