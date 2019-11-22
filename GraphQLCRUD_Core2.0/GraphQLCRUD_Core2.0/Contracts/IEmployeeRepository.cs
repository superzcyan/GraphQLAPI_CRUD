using GraphQLCRUD_Core2_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD_Core2_0.Contracts
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByID(long id);
        Task<List<Employee>> GetEmployees();
       
        Employee CreateEmployee(Employee employee);
        Employee UpdateEmployee(Employee dbEmployee, Employee employee);
        void DeleteOwner(Employee employee);

    }
}
