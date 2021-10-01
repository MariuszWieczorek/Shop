using MediatR;
using Shop.Application.Common.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit>  Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = new Order { Id = request.Id };
            _context.Orders.Remove(orderToDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
