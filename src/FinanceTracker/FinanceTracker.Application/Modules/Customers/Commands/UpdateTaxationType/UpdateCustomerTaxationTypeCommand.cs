using MediatR;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Customers.Commands.UpdateTaxationType;

public class UpdateCustomerTaxationTypeCommand : IRequest
{
    public Guid Id { get; set; }

    public TaxationTypes TaxationType { get; set; }
}
