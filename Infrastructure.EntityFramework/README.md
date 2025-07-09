About

This package provides essential services, helpers, models and base classes for Entity Framework Core in .NET applications.  
It serves as a foundation for data access layer implementations across projects.

How to Use

//A custom class. Given as an example.
public class EmployeeModel
{
    public Guid Id { get; set; }
    public string Fio { get; set; }
}
 
var employee = new EmployeeModel { Id = Guid.NewGuid(), Fio = "Ivanov Ivan Ivanovich" };

await _dbContext.AddEntityAsync(employee);                              //Create new employee.

IEnumerable<string> updatedProperties = [nameof(EmployeeModel.Fio)];

employee.Fio = "Ivanov Anton Ivanovich";                                //Updated value of the Fio property.

await _dbContext.UpdateEntityAsync(employee, updatedProperties);        //Update fio.

await _dbContext.RemoveEntityAsync(employee);                           //Delete employee.


Main Types

The main types provided by this library are:

    Infrastructure.EntityFramework.DbContexts.DbContextBase
    Infrastructure.EntityFramework.Extensions.QueryableExtensions


Feedback & Contributing

Infrastructure.EntityFramework is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.
