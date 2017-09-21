using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeListTest.DAL.Repositories;
using EmployeeListTest.Main.Models;
using AutoMapper;
using EmployeeListTest.DomainModel;

namespace EmployeeListTest.Main.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository employeeRepository;
        private IJobRepository jobRepository;
        private IMapper mapper;

        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository, IJobRepository jobRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.jobRepository = jobRepository;
        }

        [HttpGet("")]
        public IEnumerable<EmployeeListModel> GetAll()
        {
            return mapper.Map<IEnumerable<EmployeeListModel>>(employeeRepository.GetAll());
        }

        [HttpPost("")]
        public void Post([FromBody] CreateEmployeeModel employee)
        {
            Employee entity = mapper.Map<Employee>(employee);
            employeeRepository.Add(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }

        [HttpGet("[action]")]
        public IEnumerable<JobModel> GetAllJobs()
        {
            return mapper.Map<IEnumerable<JobModel>>(jobRepository.GetAll());
        }
    }
}