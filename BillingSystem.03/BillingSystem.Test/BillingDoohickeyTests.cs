namespace BillingSystem.Test
{
    using Moq;
    using Xunit;

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
}