using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Normas.API.Messages
{
    public class SubscribeToNormasCommand
    {
        public string Norma { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
    }
}
