using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.AzureAppServices.Internal;

namespace mentorient.Services
{
    public class AuthMessageSenderOptions
    {
        

        public string SendGridUser { get; set; }

        public string SendGridKey { get; set; }
    }
}
