using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MethodOfPayment MethodOfPayment { get; set; }
    }
}
