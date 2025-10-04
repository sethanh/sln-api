using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Sln.Shared.Common.Enums.Entity;
using Sln.Shared.Common.Values;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Sln.Shared.Common.Attributes;

namespace Sln.Shared.Common.Helpers
{
    public class EntityHelper
    {
        public static Guid? GetEntityIdentifier(EntityEntry entity)
        {
            var properties = entity.OriginalValues.Properties;
            
            var identifyProperty = properties.FirstOrDefault(p => p.Name == EntityEnums.Id.ToString());

            if (identifyProperty == null) return null;

            var currentValue = entity.CurrentValues[identifyProperty];

            return (Guid?)currentValue;
        }

        public static Guid? GetParentId(EntityEntry entity)
        {
            var properties = entity.OriginalValues.Properties;
            var parentIdProperty = properties.FirstOrDefault(p => p?.PropertyInfo?.GetCustomAttribute<ParentRecordLog>() != null);

            if (parentIdProperty == null) return null;

            var currentValue = entity.CurrentValues[parentIdProperty];

            return (Guid?)currentValue;
        }

        public static object RemoveDataReferent(object propertyValues)
        {
            var cloneMethod = propertyValues.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
            var newPropertyValues = cloneMethod?.Invoke(propertyValues, null);

            foreach (var property in newPropertyValues!.GetType().GetProperties())
            {
                var isReference = property.PropertyType.IsClass && property.PropertyType != typeof(string);
                var isILazyLoader = property.PropertyType.Name == "ILazyLoader";
                var isCollection = property.PropertyType.Name.Contains("ICollection");

                if (isReference || isILazyLoader || isCollection)
                {
                    property.SetValue(newPropertyValues, null);
                }
            }

            return newPropertyValues;
        }

        public static string GetEntityAction(EntityEntry entity)
        {
            var entityState = entity.State;

            if (entityState == EntityState.Added || entityState == EntityState.Deleted)
            {
                return entityState.ToString();
            }

            var properties = entity.OriginalValues.Properties;

            var deletedProperty = properties.FirstOrDefault(p => p.Name == EntityEnums.DeleterId.ToString());

            if (deletedProperty == null) return entityState.ToString();

            var currentValue = entity.CurrentValues[deletedProperty];

            if (currentValue == null) { return EntityEnums.Updated.ToString(); };

            return EntityEnums.Deleted.ToString();
        }

        public static string GetEntityName(EntityEntry entity)
        {
            var entityName = entity.Entity.GetType().Name.Replace(EntityEnums.Proxy.ToString(),string.Empty);
            return entityName;
        }

        public static List<AuditDataChange> GetAuditDataChanges(
            EntityEntry entity, 
            string entityAction
            )
        {
            var deletedProperty = entity.CurrentValues.Properties.FirstOrDefault(p => p.Name == EntityEnums.DeleterId.ToString());
            var deleteId = deletedProperty != null ? entity.CurrentValues[deletedProperty] : null;

            if (entity.State == EntityState.Deleted || deleteId != null)
            {
                return GetRemoveRangeData(entity);
            }

            var originalValues = entity.GetDatabaseValues();

            var changes = new List<AuditDataChange>();
            foreach (var property in entity.OriginalValues.Properties)
            {
                var originalValue = originalValues?[property];
                var currentValue = entity.CurrentValues[property];

                if (entityAction == EntityEnums.Added.ToString())
                {
                    changes.Add(new AuditDataChange
                    {
                        Field = property.Name,
                        OriginValue = null,
                        ChangedValue = currentValue
                    });
                    continue;
                }

                if (Equals(originalValue, currentValue)) continue;

                changes.Add(new AuditDataChange
                {
                    Field = property.Name,
                    OriginValue = originalValue,
                    ChangedValue = currentValue
                });
            }

            return changes;
        }

        private static List<AuditDataChange> GetRemoveRangeData(EntityEntry entity)
        {
            var changes = new List<AuditDataChange>();

            foreach (var property in entity.OriginalValues.Properties)
            {
                var originalValue = entity.OriginalValues[property];
                var currentValue = entity.CurrentValues[property];

                changes.Add(new AuditDataChange
                {
                    Field = property.Name,
                    OriginValue = originalValue,
                    ChangedValue = currentValue
                });
            }

            return changes;
        }

        public static List<AuditDataChange> GetDataChanges(EntityEntry entity)
        {
            var changes = new List<AuditDataChange>();

            var originalValues = entity.GetDatabaseValues();

            foreach (var property in entity.OriginalValues.Properties)
            {
                var originalValue = originalValues?[property];
                var currentValue = entity.CurrentValues[property];

                changes.Add(new AuditDataChange
                {
                    Field = property.Name,
                    OriginValue = originalValue,
                    ChangedValue = currentValue
                });
            }

            return changes;
        }
    }
}