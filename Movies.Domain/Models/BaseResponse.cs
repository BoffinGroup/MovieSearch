using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Models
{
    public class BaseResponse
    {
        public string code { get; set; }
        public string description { get; set;    }
        public object data { get; set;   }
    }
}
