using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD_Core2_0.GraphQL
{
    public class EmployeeSchema : Schema
    {
        public EmployeeSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<EmployeeQuery>();
            Mutation = resolver.Resolve<EmployeeMutation>();
        }
    }
}
