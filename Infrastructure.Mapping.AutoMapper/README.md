About

The Infrastructure.Mapping.AutoMapper package provides essential services, helpers, models and base classes for mapping using package Automapper in .NET applications. It serves as a foundation for mapping  in across projects.

How to Use

1. Define Entities and Models

Entities (in DAL):

    public class DepartmentEntity
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

Models (in BLL):

    public class DepartmentModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

2. Create repository

Repository interface:

    public interface IDepartmentRepository
    {
        public DepartmentEntity GetDepartmentById(int departmentId);
    }

Interface implementation:

    public class DepartmentRepository : IDepartmentRepository
    {
        public DepartmentEntity GetDepartmentById(int departmentId)
        {
            return new DepartmentEntity
            {
                Id = departmentId,
                Name = $"Department {departmentId}"
            };
        }
    }

3. Create service

Service interface:

    public interface IDepartmentService
    {
        public DepartmentModel GetDepartmentById(int departmentId);
    }

Interface implementation:

    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper<DepartmentEntity, DepartmentModel> _departmentMapper;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(
            IMapper<DepartmentEntity, DepartmentModel> departmentMapper, 
            IDepartmentRepository departmentRepository)
        {
            ArgumentNullException.ThrowIfNull(departmentMapper, nameof(departmentMapper));
            ArgumentNullException.ThrowIfNull(departmentRepository, nameof(DepartmentRepository));

            _departmentRepository = departmentRepository;
            _departmentMapper = departmentMapper;
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            var departmentEntity = _departmentRepository.GetDepartmentById(departmentId);

            var result = _departmentMapper.Map(departmentEntity);

            return result;
        }
    }

4. Create mapper profile

    public class DepartmentMappingProfile: Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<DepartmentEntity, DepartmentModel>();
        }
    }

5. Register mappers and mapper profile in the DI container

In Startup.ConfigureServices or Program.cs:

    services.AddSingleton(typeof(IMapper<,>), typeof(Mapper<,>));

    services.AddAutoMapper(config => {}, typeof(DepartmentMappingProfile));


Main Types  

The main types provided by this library are:

    Infrastructure.Mapping.AutoMapper.Mapper<TSource, TDestination>
        *(Defines implementation a contract for mapping objects from one type to another. 
            Supports simple one‑to‑one transformations)*


Feedback & Contributing

Infrastructure.Mapping.AutoMapper is released as open source under the MIT license. 
Bug reports and contributions are welcome at the GitHub repository.