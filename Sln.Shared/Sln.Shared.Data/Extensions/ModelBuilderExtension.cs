using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void RegisterAllEntities(this ModelBuilder modelBuilder)
        {
            var assemblyTypes = Assembly.GetCallingAssembly().GetExportedTypes()
                .Where(t => t.IsPublic && !t.IsAbstract && !t.IsInterface);
            var entityTypes = assemblyTypes
                .Where(t => t.IsAssignableTo(typeof(IDataModel)) || t.IsAssignableTo(typeof(IDataModel<>)));

            foreach (var entityType in entityTypes)
            {
                var isAssignDeletionModel = entityType.IsAssignableTo(typeof(IDeletionAuditModel))||  entityType.IsAssignableTo(typeof(IDeletionAuditModel<>));
                
                if (isAssignDeletionModel)
                {
                    modelBuilder.Entity(entityType).HasQueryFilter(QueryFilterLambdaExpression(entityType));
                }
                else
                {
                    modelBuilder.Entity(entityType);
                }
            }
        }

        private static LambdaExpression QueryFilterLambdaExpression(Type type)
        {
            var parameter = Expression.Parameter(type, "e");
            var propertyAccess = Expression.PropertyOrField(parameter, nameof(IDeletionAuditModel.IsDeleted));
            return Expression.Lambda(
                Expression.NotEqual(propertyAccess, Expression.Constant(true)),
                parameter
            );
        }
    }
}