using Shop.Domain.Common;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Order :AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MethodOfPayment MethodOfPayment { get; set; }
    }
}
