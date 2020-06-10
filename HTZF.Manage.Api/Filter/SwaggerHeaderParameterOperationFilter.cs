﻿using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;
using Swashbuckle.Swagger;

namespace HTZF.Manage.Api.Filter
{
    public class SwaggerHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
            var isAuthorized = filterPipeline
                                             .Select(filterInfo => filterInfo.Instance)
                                             .Any(filter => filter is IAuthorizationFilter);

            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

            if (isAuthorized && !allowAnonymous)
            {
                operation.parameters?.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "Bearer access token",
                    required = true,
                    type = "string"
                });
            }
        }
    }
}