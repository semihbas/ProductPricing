using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Dto.Dtos
{
    public class AppliationUserDto
    {
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool Activated { get; set; }

        public string Url { get; set; }
    }
}