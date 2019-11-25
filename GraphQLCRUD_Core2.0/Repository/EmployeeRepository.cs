using GraphQLCRUD_Core2_0.Contracts;
using GraphQLCRUD_Core2_0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD_Core2_0.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly GraphQLMutationDBContext _context;
        public EmployeeRepository(GraphQLMutationDBContext context)
        {
            _context = context;
        }
        public Task<List<Employee>> GetEmployees()
        {
            return _context.Employee.ToListAsync();
        }

        public Employee GetEmployeeByID(Int64 id)
        => _context.Employee.SingleOrDefault(o => o.Id.Equals(id));

        public Employee CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();
        }

        public Employee UpdateEmployee(Employee dbEmployee, Employee employee)
        {
            dbEmployee.Name = employee.Name;
            dbEmployee.Email = employee.Email;
            dbEmployee.Mobile = employee.Mobile;
            dbEmployee.Company = employee.Company;
            dbEmployee.Address = employee.Address;
            dbEmployee.ShortDescription = employee.ShortDescription;
            dbEmployee.LongDescription = employee.LongDescription;

            _context.SaveChanges();
            return dbEmployee;
        }
    }
}
