using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;

namespace BillingSystem.Test
{
    using Xunit;
    using Moq;

    public class BillingDoohickeyTests01
    {
        [Fact]
        public void CustomerWhoNotHaveSubscriptionDoesNotGetCharged()
        {
            var customer = new Customer();
            var processor = TestableBillingProcesor.Create(customer);

            processor.ProcesMonth(2011, 8);

            processor.Charger.Verify(c => c.ChargerCustomer(customer), Times.Never);
        }

        [Fact]
        public void CustomerWithSubscriptionThatIsExpiredGetsCharged()
        {
            var customer = new Customer() {Subscribed = true};
            var processor = TestableBillingProcesor.Create(customer);

            processor.ProcesMonth(2011, 8);

            processor.Charger.Verify(c => c.ChargerCustomer(customer), Times.Once);
        }
    }

    public class BillingProcessor
    {
        ICreditCardCharger charger;
        ICustomerRepository repo;

        public BillingProcessor(ICustomerRepository repo, ICreditCardCharger charger)
        {
            this.repo = repo;
            this.charger = charger;
        }


        public void ProcesMonth(int year, int month)
        {
            var customer = repo.Customers.Single();

            if(customer.Subscribed)
                charger.ChargerCustomer(customer);
        }
    }

    public class TestableBillingProcesor : BillingProcessor
    {
        public Mock<ICreditCardCharger> Charger;
        public Mock<ICustomerRepository> Repository;

        public TestableBillingProcesor(Mock<ICustomerRepository> repository, 
                                       Mock<ICreditCardCharger> charger) 
            : base(repository.Object, charger.Object)
        {
            Charger = charger;
            Repository = repository;
        }

        public static TestableBillingProcesor Create(params Customer[] customers)
        {
            Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();
            repository.Setup(r => r.Customers)
                .Returns(customers);

            return new TestableBillingProcesor(repository, new Mock<ICreditCardCharger>());
        }
    }


    public class Customer
    {
        public bool Subscribed { get; set; }
    }

    public interface ICreditCardCharger
    {
        void ChargerCustomer(Customer customer);
    }


    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
    }
}
