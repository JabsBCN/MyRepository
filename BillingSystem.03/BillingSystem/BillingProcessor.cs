namespace BillingSystem
{
    using System.Linq;

    public class BillingProcessor
    {
        private ICreditCardCharger charger;
        private ICustomerRepository repo;

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
}