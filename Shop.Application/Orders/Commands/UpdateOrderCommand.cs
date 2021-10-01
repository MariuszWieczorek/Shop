using MediatR;
using Shop.Application.Common.Exceptions;
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

    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MethodOfPayment MethodOfPayment { get; set; }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {

        private readonly IApplicationDbContext _context;

        public UpdateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = _context.Orders.Single(x => x.Id == request.Id);

            if (orderToUpdate == null)
            {
                throw new NotFoundException(nameof(Order),request.Id);
            }
            orderToUpdate.Title = request.Title;
            orderToUpdate.MethodOfPayment = request.MethodOfPayment;
        
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
            
            
        }
    }
}
