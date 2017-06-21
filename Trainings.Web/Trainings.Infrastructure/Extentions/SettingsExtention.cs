﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trainings.Infrastructure.Extentions
{
    public static class SettingsExtention
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty);
            var configurationValue = new T();

            configuration.GetSection(section).Bind(configurationValue);

            return configurationValue;
        }
    }
}
