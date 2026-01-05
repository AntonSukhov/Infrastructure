About

The Infrastructure.Mapping package provides a flexible object mapping mechanism for transforming data between application layers (e.g., database entities to API models), supporting:

    a) Simple TSource → TDestination transformations;
    b) Mapping with additional data (TData);
    c) Collection processing.

How to Use

1. Define Entities and Models

Entities (from DB):

    public class DepartmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }


Models (for API):

    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IReadOnlyCollection<EmployeeModel> Employees { get; set; } = [];
    }

    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

2. Create Mappers

Employee mapper (simple mapping):

    public class EmployeeMapper : IMapper<EmployeeEntity, EmployeeModel>
    {
        public EmployeeModel Map(EmployeeEntity source)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            return new EmployeeModel
            {
                Id = source.Id,
                Name = source.Name
            };
        }
    }

Department mapper (mapping with employee data):

    public class DepartmentMapper : IDataMapper<DepartmentEntity, DepartmentModel, EmployeeEntity>
    {
        private readonly IMapper<EmployeeEntity, EmployeeModel> _employeeMapper;

        public DepartmentMapper(IMapper<EmployeeEntity, EmployeeModel> employeeMapper)
        {
            _employeeMapper = employeeMapper;
        }

        public DepartmentModel Map(DepartmentEntity departmentEntity, 
            IEnumerable<EmployeeEntity> employeeEntities)
        {
            var employees = _employeeMapper.Map(
                employeeEntities.Where(e => e.DepartmentId == departmentEntity.Id)
            );

            return new DepartmentModel
            {
                Id = departmentEntity.Id,
                Name = departmentEntity.Name,
                Employees = employees
            };
        }
    }

3. Apply Mapping

Simple code:

        // Source data
        var employees = new List<EmployeeEntity>
        {
            new EmployeeEntity { Id = 1, Name = "Employee1", DepartmentId = 1 },
            new EmployeeEntity { Id = 2, Name = "Employee2", DepartmentId = 1 },
        };

        var departments = new List<DepartmentEntity>
        {
            new DepartmentEntity { Id = 1, Name = "Department1" },
            new DepartmentEntity { Id = 2, Name = "Department2" }
        };

        // Create mappers
        var employeeMapper = new EmployeeMapper();
        var departmentMapper = new DepartmentMapper(employeeMapper);

        // Map collections
        var departmentModels = departmentMapper.Map(departments, employees);

Result:

The departmentModels collection contains DepartmentModel objects, where each department includes its employees.


Main Types  

The main types provided by this library are:

    Infrastructure.Mapping.Interfaces.IMapper<TSource, TDestination>
        *(Defines a contract for mapping objects from one type to another. 
            Supports simple one‑to‑one transformations)*
    Infrastructure.Mapping.Interfaces.IDataMapper<TSource, TDestination, TData>
        *(Extends basic mapping with support for additional data (TData). 
            Useful when transformation logic depends on external context or related entities.)*
    Infrastructure.Mapping.Extensions.CollectionMappingExtensions
        *(Static class providing extension methods for IMapper and IDataMapper. 
            Enables bulk mapping of collections to IReadOnlyCollection<TDestination>.)*


Feedback & Contributing

Infrastructure.Mapping is released as open source under the MIT license. 
Bug reports and contributions are welcome at the GitHub repository.