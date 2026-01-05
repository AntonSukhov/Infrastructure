using System.Diagnostics.CodeAnalysis;
using Infrastructure.Mapping.Tests.Models;

namespace Infrastructure.Mapping.Tests.Comparers;

public class EmployeeModelComparer : IEqualityComparer<EmployeeModel?>
{
    public bool Equals(EmployeeModel? employee1, EmployeeModel? employee2)
    {
         if (employee1 is null && employee2 is null)
            return true;
        
        if (employee1 is null || employee2 is null)
            return false;
        
        return employee1.Id == employee2.Id &&
               employee1.Name == employee2.Name;
    }

    public int GetHashCode([DisallowNull] EmployeeModel employee)
    {
       if (employee is null)
            return 0;

        return HashCode.Combine(employee.Id, employee.Name);
    }
}
