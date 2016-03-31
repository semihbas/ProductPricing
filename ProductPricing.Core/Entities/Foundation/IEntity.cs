using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Core.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime DateCreated { get; set; }
    }
}