using System;

namespace Digital_Services_BD.Utilities
{
    /// <summary>
    /// Marks a property for automatic encryption/decryption in Entity Framework Core
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EncryptedAttribute : Attribute
    {
    }
}
