using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomVision
{
    public class ServiceGeneralResponse<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
        public string InnerExceptionError { get; set; }
    }
}
