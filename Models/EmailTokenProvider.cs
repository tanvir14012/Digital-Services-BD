using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Digital_Services_BD.Models
{
    public class EmailTokenProvider<TUser>: DataProtectorTokenProvider<TUser> where TUser: class
    {
        public EmailTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<EmailTokenProviderOptions> options,
            ILogger<DataProtectorTokenProvider<TUser>> logger) :base(dataProtectionProvider, options, logger)
        {

        }
    }
    public class EmailTokenProviderOptions: DataProtectionTokenProviderOptions
    {

    }
}