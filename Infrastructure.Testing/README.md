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

Scenario without input (only output and no stubs):

    var testCase = new TestCaseResult<IEnumerable<DepartmentModel>>
    {
        ScenarioNumber = 2,
        OutputData = new List<DepartmentModel>
        {
            new DepartmentModel { Id = 1, Name = "HR" },
            new DepartmentModel { Id = 2, Name = "IT" }
        },
        Description = "GetAll returns all departments"
    };

Scenario without input (only output and with stubs):

    var testCase = new TestCaseResultWithStubs<IEnumerable<DepartmentModel>>
    {
        ScenarioNumber = 3,
        OutputData = new List<DepartmentModel> { /* ... */ },
        Description = "GetAll with mocked repository",
        StubOutputs = new Dictionary<(string, int), StubOutput>
        {
            {
                (RepositoryMethodNames.DepartmentRepository.GetAll, 1),
                new StubOutput
                {
                    OutputData = new List<DepartmentEntity> { /* ... */ }
                }
            }
        }
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

    var testCase = new TestCaseWithStubs<int, DepartmentModel>
    {
        ScenarioNumber = 1,
        InputData = 15,
        OutputData = new DepartmentModel 
        {
            Id = 15,
            Name = "Department 15"
        },
        Description = "Retrieving department data that is present in the database.",
        StubOutputs = new Dictionary<(string, int), StubOutput>
        {
            {
                (RepositoryMethodNames.DepartmentRepository.GetDepartmentById, 1),
                new StubOutput
                {
                    OutputData = new DepartmentEntity
                    {
                        Id = 15,
                        Name = "Department 15"
                    }
                }
            }
        }
    }

    var stubOutput = testCase.StubOutputs[
            (MethodName: RepositoryMethodNames.DepartmentRepository.GetDepartmentById,
             SequenceNumber: 1)];
    var outputData = stubOutput.GetOutputData<DepartmentEntity>();  // Safe type casting
    
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
            var stubOutput = testCase.StubOutputs[
                (MethodName: RepositoryMethodNames.DepartmentRepository.GetDepartmentById,
                SequenceNumber: 1)];

            _fixture.DepartmentRepositoryMock
                .Setup(s => s.GetDepartmentById(It.IsAny<int>()))
                .Returns(() => stubOutput.GetOutputData<DepartmentEntity>());

            // Act:
            var result = _fixture.DepartmentService.GetDepartmentById(testCase.InputData);

            // Assert:
            Assert.Equal(testCase.OutputData, result, _fixture.DepartmentModelComparer);
        }
    }



Main Types  

The main types provided by this library are:

    Infrastructure.Testing.Common.StubOutput
        *(Encapsulates stub output data with safe type casting)*
    Infrastructure.Testing.Common.TestCaseBase
        *(Base class for all test scenarios; contains ScenarioNumber and Description)*
    Infrastructure.Testing.TestCases.TestCaseInput<TIn>
        *(Scenario with input data only)*
    Infrastructure.Testing.TestCases.TestCase<TIn, TOut>
        *(Scenario with both input and output data)*
    Infrastructure.Testing.TestCases.TestCaseInputWithStubs<TIn>
        *(Scenario with input data and stubs)*
    Infrastructure.Testing.TestCases.TestCaseWithStubs<TIn, TOut>
        *(Scenario with input, output, and stubs)*
    Infrastructure.Testing.TestCases.TestCaseResult<TOut>
        *(Scenario for parameterless methods; contains only output data)*
    Infrastructure.Testing.TestCases.TestCaseResultWithStubs<TOut>
        *(Scenario for parameterless methods with stubs)*



Feedback & Contributing

Infrastructure.Testing is released as open source under the MIT license. 
Bug reports and contributions are welcome at the GitHub repository.