using System.Linq;

namespace TCore.Mappers
{
    public static class AutoMapper
    {
        /// <summary>
        /// Copies all property value to the new entity
        /// </summary>
        /// <param name="oldEntity">The base entity will update the new entity</param>
        /// <param name="newEntity">The new entity will be updated by old entity</param>
        public static void CopyAndShallowPropertiesTo(this object oldEntity, object newEntity)
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
                            newProperty.SetValue(newEntity, GetPropValue(oldEntity, newProperty), null);
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
    }
}
