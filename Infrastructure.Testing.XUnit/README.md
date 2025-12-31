About

The Infrastructure.Testing.XUnit package provides a set of utilities, base classes, and helpers 
to simplify and standardize unit testing in .NET applications using the xUnit testing framework. 

How to Use

1. Using the Base Test Class

The BaseTest<TFixture> class serves as a foundation for your test classes when you need 
to share a common fixture across multiple test methods.

Example:

    public class CustomerServiceTests : BaseTest<CustomerServiceFixture>
    {
        public CustomerServiceTests(CustomerServiceFixture fixture) 
            : base(fixture)
        {
        }

        [Fact]
        public void GetCustomer_ShouldReturnValidCustomer()
        {
            // Use _fixture to access shared resources
            var customer = _fixture.CustomerService.GetCustomer(1);
            Assert.NotNull(customer);
            Assert.Equal(1, customer.Id);
        }
    }

2. Using Assertion Helpers

The AssertHelper class provides convenient methods for common assertion patterns 
that are not natively supported by xUnit.

Examples:

a) Ensure an action does not throw any exception

    AssertHelper.DoesNotThrow(() => 
    {
        var service = new CustomerService();
        service.Initialize();
    }, "Initialization should not throw exceptions");

b) Ensure an action does not throw a specific type of exception

    AssertHelper.DoesNotThrow<ArgumentNullException>(() =>
    {
        var service = new CustomerService();
        service.ProcessCustomer(new Customer { Id = 1 });
    }, "Processing valid customer should not throw ArgumentNullException");

c) Ensure an action throws one of two expected exception types

    AssertHelper.ThrowsOneOf<ArgumentException, InvalidOperationException>(() =>
    {
        var service = new CustomerService();
        service.ValidateInput(null);
    }, "Invalid input should throw either ArgumentException or InvalidOperationException");




Main Types  

The main types provided by this library are:

    Infrastructure.Testing.XUnit.BaseTest<TFixture>
    Infrastructure.Testing.XUnit.Helpers.AssertHelper


Feedback & Contributing

Infrastructure.Testing.XUnit is released as open source under the MIT license. Bug reports, feature requests, and contributions are welcome at the GitHub repository.