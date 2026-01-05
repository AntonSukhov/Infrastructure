using Infrastructure.Mapping.Extensions;
using Infrastructure.Mapping.Tests.Entities;
using Infrastructure.Mapping.Tests.Models;
using Infrastructure.Testing.TestCases;
using Infrastructure.Testing.XUnit;

namespace Infrastructure.Mapping.Tests;

public class MapperTests: BaseTest<MapperFixture>
{
    public MapperTests(MapperFixture fixture) : base(fixture) { }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TestCase<(IReadOnlyCollection<EmployeeEntity> EmployeeEntities,
                                IReadOnlyCollection<DepartmentEntity> DepartmentEntities), 
                                IReadOnlyCollection<DepartmentModel>> testCase)
    {
        // Arrange:
  
        // Act:
        var result = _fixture.DepartmentMapper.Map(sources: testCase.InputData.DepartmentEntities, 
                                                   data: testCase.InputData.EmployeeEntities);

        // Assert:
        Assert.Equal(result, testCase.OutputData, _fixture.DepartmentModelComparer);
    }

    public static TheoryData<TestCase<(IReadOnlyCollection<EmployeeEntity> EmployeeEntities,
                                       IReadOnlyCollection<DepartmentEntity> DepartmentEntities), 
                                       IReadOnlyCollection<DepartmentModel>>> TestData =>
    [
        new TestCase<(IReadOnlyCollection<EmployeeEntity> EmployeeEntities,
                      IReadOnlyCollection<DepartmentEntity> DepartmentEntities), 
                       IReadOnlyCollection<DepartmentModel>>
        {
            ScenarioNumber = 1,
            InputData = ([ 
                            new EmployeeEntity { Id = 1, Name = "Employee1", DepartmentId = 1},
                            new EmployeeEntity { Id = 2, Name = "Employee2", DepartmentId = 1},
                            new EmployeeEntity { Id = 3, Name = "Employee3", DepartmentId = 1},
                            new EmployeeEntity { Id = 4, Name = "Employee4", DepartmentId = 2},
                            new EmployeeEntity { Id = 5, Name = "Employee5", DepartmentId = 2},
                        ], 
                        [
                            new DepartmentEntity { Id = 1, Name = "Department1"},
                            new DepartmentEntity { Id = 2, Name = "Department2"}
                        ]),
            OutputData = [ 
                            new DepartmentModel { Id = 1, Name = "Department1",
                                Employees = [ 
                                                new EmployeeModel { Id = 1, Name = "Employee1"},
                                                new EmployeeModel { Id = 2, Name = "Employee2"},
                                                new EmployeeModel { Id = 3, Name = "Employee3"},
                                            ]
                            },
                            new DepartmentModel { Id = 2, Name = "Department2",
                                Employees = [
                                                new EmployeeModel { Id = 4, Name = "Employee4"},
                                                new EmployeeModel { Id = 5, Name = "Employee5"},
                                            ]
                            }
                        ],
            Description = "Получение данных отдела, который присутствует в хранилище."
        }
    ];

}
