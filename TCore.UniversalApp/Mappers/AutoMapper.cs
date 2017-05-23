using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TCore.UniversalApp.Mappers
{
    /// <summary>
    /// Helps mapping automatically
    /// </summary>
    public static class AutoMapper
    {
        /// <summary>
        /// Copies all property value to the new entity
        /// </summary>
        /// <param name="oldEntity">The base entity will update the new entity</param>
        /// <param name="newEntity">The new entity will be updated by old entity</param>
        public static void CopyAndShallowPropertiesTo(this object oldEntity, object newEntity)
        {
            if (oldEntity is IList)
            {
                MapCollection(oldEntity, newEntity);
            }
            else
            {
                MapSingleObject(oldEntity, newEntity);
            }
        }

        private static void MapCollection(object oldEntity, object newEntity)
        {
            if(oldEntity as IList == null)
            {
                return;
            }

            int indexOfCurrentItem = 0;
            foreach (var oldItem in (oldEntity as IList))
            {
                var newItemType = GetListType((newEntity as IEnumerable));

                if (newItemType == null)
                {
                    (newEntity as IList)[indexOfCurrentItem] = oldItem;
                    indexOfCurrentItem++;
                }
                else
                {
                    var newItem = Activator.CreateInstance(newItemType);
                    MapSingleObject(oldItem, newItem);
                    (newEntity as IList).Add(newItem);
                }
            }
        }

        private static void MapSingleObject(object oldEntity, object newEntity)
        {
            var oldPropertyList = oldEntity.GetType().GetProperties();
            var propertyList = newEntity.GetType().GetProperties();

            foreach (var newProperty in propertyList)
            {
                if (oldPropertyList.Any(op => op.Name.Equals(newProperty.Name)))
                {
                    var oldproperty = oldPropertyList.First(op => op.Name.Equals(newProperty.Name));
                    if (oldproperty.PropertyType.Name.Equals(newProperty.PropertyType.Name))
                    {
                        if (newProperty.CanWrite)
                        {
                            if (typeof(IList).IsAssignableFrom(newProperty.PropertyType))
                            {
                                if(newEntity.GetType().GetProperty(newProperty.Name).GetValue(newEntity) == null)
                                {
                                    if (newProperty.PropertyType.Name.Contains("[]"))
                                    {
                                        var oldPropertyContent = oldEntity.GetType().GetProperty(oldproperty.Name).GetValue(oldEntity);

                                        if (oldPropertyContent != null)
                                        {
                                            var count = (oldPropertyContent as Array).Length;

                                            newEntity.GetType().GetProperty(newProperty.Name).SetValue(newEntity, Activator.CreateInstance(newProperty.PropertyType, count));
                                        }
                                    }
                                    else
                                    {
                                        newEntity.GetType().GetProperty(newProperty.Name).SetValue(newEntity, Activator.CreateInstance(newProperty.PropertyType));
                                    }
                                }

                                MapCollection(oldEntity.GetType().GetProperty(oldproperty.Name).GetValue(oldEntity), newEntity.GetType().GetProperty(newProperty.Name).GetValue(newEntity));
                            }
                            else
                            {
                                if (oldproperty.PropertyType == newProperty.PropertyType)
                                {
                                    newProperty.SetValue(newEntity, GetPropValue(oldEntity, newProperty), null);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static object GetPropValue(object newEntity, System.Reflection.PropertyInfo newProperty)
        {
            var val = newEntity.GetType().GetProperty(newProperty.Name).GetValue(newEntity, null);
            return val;
        }

        private static Type GetListType(IEnumerable list)
        {
            try
            {
                var type = list.GetType();
                var enumerableType = type
                    .GetInterfaces()
                    .Where(x => x.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    .First();
                return enumerableType.GetGenericArguments()[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
