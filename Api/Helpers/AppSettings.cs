using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class AppSettings
    {
        public string JwtSecret { get; set; }
        public string ConnectionString { get; set; }
    }
}
