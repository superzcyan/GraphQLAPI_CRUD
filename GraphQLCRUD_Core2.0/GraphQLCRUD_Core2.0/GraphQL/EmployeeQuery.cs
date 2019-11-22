using GraphQL.Types;
using GraphQLCRUD_Core2_0.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD_Core2_0.GraphQL
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeRepository employeeRepository)
        {
            Field<ListGraphType<EmployeeType>>(
                "employees",
                resolve: context => employeeRepository.GetEmployees()
                );

            Field<EmployeeType>(
                "employee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return employeeRepository.GetEmployeeByID(id);
                });

          
        }
    }
}
