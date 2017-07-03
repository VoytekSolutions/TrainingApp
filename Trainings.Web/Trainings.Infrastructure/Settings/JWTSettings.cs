using System;
using System.Collections.Generic;
using System.Text;

namespace Trainings.Infrastructure.Settings
{
    public class JWTSettings
    {
        public string Key { get; set; }
        public int ExpiringMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
