using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManager.Shared.ResponsesDTOs
{
    public class ServiceAllPageDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string Note { get; set; }
        public bool IsDelate { get; set; }
    }
}
