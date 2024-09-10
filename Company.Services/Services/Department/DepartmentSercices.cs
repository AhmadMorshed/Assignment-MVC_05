using AutoMapper;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Services.Interfaces;
using Company.Services.Interfaces.Department.Dto;

namespace Company.Services.Services
{
    public class DepartmentServices : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork =unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAt = DateTime.Now

            //};
            var mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Delete(mappedDepartment);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {

            var departments= _unitOfWork.DepartmentRepository.GetAll();
            var mappedDepartments=_mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return mappedDepartments;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);

            if (department is null)
                return null;
            var mappedDepartments = _mapper.Map<DepartmentDto>(department);


            return mappedDepartments;

        }

        public void Update(DepartmentDto department)
        {
            //var dept = GetById(department.Id);

            //if (dept.Name != department.Name)
            //{
            //    if (GetAll().Any(x => x.Name == department.Name)) ;
            //    throw new Exception("DuplicateDepartmentName");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;

            //_unitOfWork.DepartmentRepository.Update(department);
            //_unitOfWork.Complete();
        }
        
      


    }
}
