namespace BillingSystem.Test
{
    using Moq;
    using BillingSystem;

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
}
