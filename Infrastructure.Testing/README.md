About

The package contains services, helpers, models, etc. used for testing .NET of applications.

How to Use

var testCaseData = new TestCaseData<int, Customer>
{
    SerialNumber = 1,
    InputData = 5,
    OutputData = new Customer { Id = 5, Name = "Customer 5" },
    Description = "Getting the customer by his ID, which is in the database."
};


Main Types  

The main types provided by this library are:

    Infrastructure.Testing.TestCaseData<TIn, TOut>


Feedback & Contributing

Infrastructure.Testing is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.