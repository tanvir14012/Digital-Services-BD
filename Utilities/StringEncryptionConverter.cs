using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Digital_Services_BD.Utilities
{
    /// <summary>
    /// EF Core 8 Value Converter for automatic string encryption/decryption
    /// </summary>
    public class StringEncryptionConverter : ValueConverter<string, string>
    {
        public StringEncryptionConverter(EncryptionHelper encryptionHelper)
            : base(
                v => encryptionHelper.Encrypt(v),
                v => encryptionHelper.Decrypt(v))
        {
        }
    }
}
