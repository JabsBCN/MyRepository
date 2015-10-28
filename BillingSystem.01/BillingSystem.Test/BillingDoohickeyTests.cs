using System.Linq;

namespace BillingSystem.Test
{
    using Xunit;
    using Moq;

    public class BillingDoohickeyTests01
    {
        [Fact]
        public void CustomerWhoNotHaveSubscriptionDoesNotGetCharged()
        {
            var repo = new Mock<ICustomerRepository>();
            var charger = new Mock<ICreditCardCharger>();
            var customer = new Customer() { Subscribed = false };
            repo.Setup(r => r.Customers).Returns(new Customer[] { customer });
            var processor = new BillingDoohickey(repo.Object, charger.Object);

            processor.ProcesMonth(2011, 8);

            charger.Verify(c => c.ChargerCustomer(customer), Times.Never);
        }
        
        [Fact]
        public void CustomerWithSubscriptionThatIsExpiredGetsCharged()
        {
            var repo = new Mock<ICustomerRepository>();
            var charger = new Mock<ICreditCardCharger>();
            var customer = new Customer() {Subscribed = true};
            repo.Setup(r => r.Customers).Returns(new Customer[] { customer });
            var processor = new BillingDoohickey(repo.Object, charger.Object);

            processor.ProcesMonth(2011, 8);

            charger.Verify(c => c.ChargerCustomer(customer), Times.Once);
        }
    }

    public class BillingDoohickey
    {
        private ICreditCardCharger charger;
        private ICustomerRepository repo;

        public BillingDoohickey(ICustomerRepository repo, ICreditCardCharger charger)
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
        Customer[] Customers { get; set; }
    }
}
