
using System.Collections.Generic;
using System.Text;

namespace DTO.Configuration
{

    public class AppSettings
    {
        public JWT JWT { get; set; }
        public EmailAccount emailAccount { get; set; }
    }
    public class JWT
    {
        public string Secret { get; set; }
    }
}
