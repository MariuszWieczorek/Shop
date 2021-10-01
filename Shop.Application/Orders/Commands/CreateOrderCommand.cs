using MediatR;
using Shop.Application.Common.Interfaces;
using Shop.Domain.Entities;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands
{

    public class CreateOrderCommand : IRequest<int> // będziemy zwracać Id dodanego rekordu
    {
        public string Title { get; set; }
        public MethodOfPayment MethodOfPayment { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {

        private readonly IApplicationDbContext _context;

        public CreateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Title = request.Title,
                MethodOfPayment = request.MethodOfPayment
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
            
            return order.Id;

        }
    }
}
