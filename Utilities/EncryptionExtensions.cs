using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Linq;
using System.Reflection;

namespace Digital_Services_BD.Utilities
{
    /// <summary>
    /// Extension methods for applying encryption to Entity Framework Core models
    /// </summary>
    public static class EncryptionExtensions
    {
        /// <summary>
        /// Applies encryption converters to all properties marked with [Encrypted] attribute
        /// </summary>
        public static void ApplyEncryption(this ModelBuilder modelBuilder, EncryptionHelper encryptionHelper)
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));
            if (encryptionHelper == null) throw new ArgumentNullException(nameof(encryptionHelper));

            var converter = new StringEncryptionConverter(encryptionHelper);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    // Check if the property has the [Encrypted] attribute
                    var propertyInfo = property.PropertyInfo;
                    if (propertyInfo != null && 
                        propertyInfo.PropertyType == typeof(string) &&
                        Attribute.IsDefined(propertyInfo, typeof(EncryptedAttribute)))
                    {
                        property.SetValueConverter(converter);
                    }
                }
            }
        }
    }
}
