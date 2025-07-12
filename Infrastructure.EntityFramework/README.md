About

This package provides essential services, helpers, models and base classes for Entity Framework Core in .NET applications.  
It serves as a foundation for data access layer implementations across projects.

How to Use

//First custom model class. Given as an example.
public class WorkTypeModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public byte? WorkUnitId { get; set; }
    public WorkUnitModel? WorkUnit { get; set; }
}

//Second custom model class. Given as an example.
public class WorkUnitModel
{
    public byte Id { get; set; }
    public required string Name { get; set; }
}
 
//Custom dbContext class. Given as an example.
public class ContractGpdDbContextBase(DbContextOptions options) : DbContextBase(options)
{
    public DbSet<WorkUnitModel> WorkUnits { get; set; }
    public DbSet<WorkTypeModel> WorkTypes { get; set; }
}

var employee = new EmployeeModel { Id = Guid.NewGuid(), Fio = "Ivanov Ivan Ivanovich" };

await _dbContext.AddEntityAsync(employee);                              //Create new employee.

IEnumerable<string> updatedProperties = [nameof(EmployeeModel.Fio)];

employee.Fio = "Ivanov Anton Ivanovich";                                //Updated value of the Fio property.

await _dbContext.UpdateEntityAsync(employee, updatedProperties);        //Update fio.

await _dbContext.RemoveEntityAsync(employee);                           //Delete employee.

//Example of using the Left join method
var optionsBuilderPostgreSql = new DbContextOptionsBuilder<ContractGpdDbContextBase>();
optionsBuilderPostgreSql.UseNpgsql("host=localhost;port=5432;database=DbContracts;user id=postgres;password=*****");

using var dbContext = new ContractGpdDbContextBase(optionsBuilderPostgreSql.Options);
var workTypes = await dbContext.WorkTypes.AsNoTracking()
                                        .LeftJoin(dbContext.WorkUnits.AsNoTracking(),
                                                    wt => wt.WorkUnitId,
                                                    wu => wu.Id,
                                                    (wt, wu) => new WorkTypeModel
                                                    {
                                                        Id = wt.Id,
                                                        Name = wt.Name,
                                                        WorkUnit = wu,
                                                        WorkUnitId = wt.WorkUnitId
                                                    })
                                        .OrderBy(p => p.Id)
                                        .ToListAsync();


Main Types

The main types provided by this library are:

    Infrastructure.EntityFramework.DbContexts.DbContextBase
    Infrastructure.EntityFramework.Extensions.QueryableExtensions


Feedback & Contributing

Infrastructure.EntityFramework is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.
