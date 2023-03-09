using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svalbard.Configuration
{
    public static class ConfigurationExtensions
    {
        public static T? GetAs<T>(this IConfiguration configuration, string? name = default) where T : class => 
            configuration.GetSection(name ?? nameof(T))?.Get<T>();

        public static T GetRequiredAs<T>(this IConfiguration configuration, string? name = default) where T : class
        {
            var retVal = configuration.GetAs<T>(name);
            if (retVal == null) throw new ArgumentException($"Configuration section named '{name ?? nameof(T)}' not found");
            return retVal;
        }

    }

}
