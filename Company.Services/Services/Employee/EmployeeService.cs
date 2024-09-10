using AutoMapper;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Services.Helper;
using Company.Services.Interfaces;
using Company.Services.Interfaces.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            // Employee employee = new Employee()
            //{
            //    Name = employeeDto.Name,
            //    Age= employeeDto.Age,
            //    Address= employeeDto.Address,
            //    Email= employeeDto.Email,
            //    PhoneNumber= employeeDto.PhoneNumber,
            //    HiringDate= employeeDto.HiringDate,
            //    ImageUrl= employeeDto.ImageUrl,
            //    DepartmentId= employeeDto.DepartmentId,


            //};
            employeeDto.ImageUrl = DocumentSetting.UploadFile(employeeDto.Image, "Images");
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee()
            //{
            //    Name = employeeDto.Name,
            //    Age = employeeDto.Age,
            //    Address = employeeDto.Address,
            //    Email = employeeDto.Email,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //    DepartmentId = employeeDto.DepartmentId,


            //};
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {

            var employees=_unitOfWork.EmployeeRepository.GetAll();
            //var mappEmlpyees = employees.Select(x => new EmployeeDto
            //{
            //    Name=x.Name,
            //    Age=x.Age,
            //    Address=x.Address,
            //    Email=x.Email,
            //    PhoneNumber=x.PhoneNumber,
            //    HiringDate=x.HiringDate,
            //    ImageUrl=x.ImageUrl,
            //    DepartmentId=x.DepartmentId,

            //});
          IEnumerable < EmployeeDto> mappEmlpyees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappEmlpyees;
        }

        public EmployeeDto GetById(int? id)
        {

            if (id is null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee is null)
                return null;
            //EmployeeDto employeeDto = new EmployeeDto()
            //{
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Address = employee.Address,
            //    Email = employee.Email,
            //    PhoneNumber = employee.PhoneNumber,
            //    HiringDate = employee.HiringDate,
            //    ImageUrl = employee.ImageUrl,
            //    DepartmentId = employee.DepartmentId,


            //};
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
         var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var mappEmlpyees = employees.Select(x => new EmployeeDto
            //{
            //    Name = x.Name,
            //    Age = x.Age,
            //    Address = x.Address,
            //    Email = x.Email,
            //    PhoneNumber = x.PhoneNumber,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //    DepartmentId = x.DepartmentId,

            //});
            IEnumerable<EmployeeDto> mappEmlpyees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappEmlpyees;
        }
        public void Update(EmployeeDto employee)
        {
          // _unitOfWork.EmployeeRepository.Update(employee);

            _unitOfWork.Complete();
        }
    }
}
