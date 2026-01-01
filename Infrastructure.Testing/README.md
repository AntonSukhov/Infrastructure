About

The Infrastructure.Testing package provides a foundational set of types and abstractions to standardize test development in .NET applications. It serves as a core layer for testing utilities (including Infrastructure.Testing.XUnit) and offers:

    a) structured models for test scenarios;
    b) mechanisms for working with stubs (test doubles);
    c) common contracts for test fixtures.

How to Use

1. Defining a Test Scenario

Use TestCase<TIn, TOut> or TestCaseWithStubs<TIn, TOut> to structure input/output data and stub configurations.

Simple scenario (no stubs):

    var testCase = new TestCase<int, string>
    {
        ScenarioNumber = 1,
        InputData = 42,
        OutputData = "Result for 42",
        Description = "Verify basic int-to-string conversion"
    };

Scenario with stubs:

    var testCase = new TestCaseWithStubs<int, DepartmentModel>
    {
        ScenarioNumber = 1,
        InputData = 15,
        OutputData = new DepartmentModel { Id = 15, Name = "Dept 15" },
        Description = "Retrieve existing department",
        StubOutputs = new Dictionary<(string, int), StubOutput>
        {
            {
                (RepositoryMethodNames.DepartmentRepository.GetDepartmentById, 1),
                new StubOutput 
                {
                    OutputData = new DepartmentEntity { Id = 15, Name = "Dept 15" }
                }
            }
        }
    };

2. Working with Stubs

The StubOutput class enables:

    a) storing output data for mocks;
    b) safe type casting via GetOutputData<T>().

Usage example:

    var stub = new StubOutput { OutputData = new Customer { Id = 1 } };
    var customer = stub.GetOutputData<Customer>(); // Safe type casting
    
Note: GetOutputData<T> throws InvalidCastException if OutputData type doesn’t match T.

3. Inheriting Test Classes

For fixture reuse, inherit from BaseTest<TFixture> (implemented in Infrastructure.Testing.XUnit).

Example:

    public class DepartmentServiceTests : BaseTest<DepartmentServiceFixture>
    {
        public DepartmentServiceTests(DepartmentServiceFixture fixture)
            : base(fixture) { }


        [Theory]
        [MemberData(nameof(TestCases))]
        public void GetDepartment_ShouldReturnValidResult(
            TestCaseWithStubs<int, DepartmentModel> testCase)
        {
            // Arrange
            _fixture.SetupRepositoryStub(testCase.StubOutputs);

            // Act
            var result = _fixture.Service.GetDepartment(testCase.InputData);

            // Assert
            Assert.Equal(testCase.OutputData, result, _fixture.DepartmentModelComparer);
        }
    }



Main Types  

The main types provided by this library are:

    Infrastructure.Testing.Common.StubOutput
    Infrastructure.Testing.Common.TestCaseInput<TIn>
    Infrastructure.Testing.TestCases.TestCase<TIn, TOut>
    Infrastructure.Testing.TestCases.TestCaseInputWithStubs<TIn>
    Infrastructure.Testing.TestCases.TestCaseWithStubs<TIn, TOut>


Feedback & Contributing

Infrastructure.Testingis released as open source under the MIT license. 
Bug reports and contributions are welcome at the GitHub repository.