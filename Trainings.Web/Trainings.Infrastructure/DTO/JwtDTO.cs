using System;
using System.Collections.Generic;
using System.Text;

namespace Trainings.Infrastructure.DTO
{
    public class JwtDTO
    {
        public string Token { get; set; }
        public long Expiriation { get; set; }
    }
}
