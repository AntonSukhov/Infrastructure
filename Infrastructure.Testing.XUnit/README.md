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

Ensure an action does not throw any exception

    AssertHelper.DoesNotThrow(() => 
    {
        var service = new CustomerService();
        service.Initialize();
    }, 
    "Initialization should not throw exceptions");

Ensure an action does not throw a specific type of exception

    AssertHelper.DoesNotThrow<ArgumentNullException>(() =>
    {
        var service = new CustomerService();
        service.ProcessCustomer(new Customer { Id = 1 });
    }, 
    "Processing valid customer should not throw ArgumentNullException");

Ensure an action throws one of two expected exception types

    AssertHelper.ThrowsOneOf<ArgumentException, InvalidOperationException>(() =>
    {
        var service = new CustomerService();
        service.ValidateInput(null);
    }, 
    "Invalid input should throw either ArgumentException or InvalidOperationException");

Check that collections are equal (using a custom comparer):

    var actual = new List<WorkUnitModel> { /* ... */ };
    var expected = new List<WorkUnitModel> { /* ... */ };

    var comparer = new WorkUnitModelEqualityComparer();

    AssertHelper.CollectionEqual(
    (
        actual,
        expected,
        comparer,
        "GetAllAsync returned incorrect list of work units"
    );
Note: CollectionEqual verifies that:

    a) Both collections are either null (considered equal) or non‑null.
    b) If one is null and the other isn’t — fails with a clear message.
    c) If both are non‑null, checks element‑wise equality using the provided comparer.
    d) On mismatch, reports the error with your custom message (or a default one).

Main Types  

The main types provided by this library are:

    Infrastructure.Testing.XUnit.BaseTest<TFixture>
    Infrastructure.Testing.XUnit.Helpers.AssertHelper


Feedback & Contributing

Infrastructure.Testing.XUnit is released as open source under the MIT license. Bug reports, feature requests, and contributions are welcome at the GitHub repository.