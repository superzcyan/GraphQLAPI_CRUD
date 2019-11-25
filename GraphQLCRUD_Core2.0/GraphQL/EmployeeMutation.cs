using GraphQL;
using GraphQL.Types;
using GraphQLCRUD_Core2_0.Contracts;
using GraphQLCRUD_Core2_0.GraphQL.InputTypes;
using GraphQLCRUD_Core2_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD_Core2_0.GraphQL
{
    public class EmployeeMutation : ObjectGraphType
    {
        public EmployeeMutation(IEmployeeRepository repository)
        {

            Field<EmployeeType>(
                "createEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee" }),
                resolve: context =>
                {
                    var employee = context.GetArgument<Employee>("employee");
                    return repository.CreateEmployee(employee);
                }
            );

            Field<EmployeeType>(
                "updateEmployee",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var employee = context.GetArgument<Employee>("employee");
                    var id = context.GetArgument<long>("id");

                    var dbEmployee = repository.GetEmployeeByID(id);
                    if (dbEmployee == null)
                    {
                        context.Errors.Add(new ExecutionError("Employee don't exist"));
                        return null;
                    }
                    return repository.UpdateEmployee(dbEmployee, employee);
                });

            Field<StringGraphType>(
                "deleteEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<long>("id");
                    var employee = repository.GetEmployeeByID(id);
                    if (employee == null)
                    {
                        context.Errors.Add(new ExecutionError("Employee don't exist"));
                        return null;
                    }
                    repository.DeleteEmployee(employee);
                    return $"Employee {id} has been successfully deleted.";
                });

        }
    }
}
