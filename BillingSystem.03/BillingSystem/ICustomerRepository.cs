namespace BillingSystem
{
    using System.Collections.Generic;

    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
    }
}
