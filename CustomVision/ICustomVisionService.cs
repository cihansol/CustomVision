using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


using CustomVision.Models;

namespace CustomVision
{
    public interface ICustomVision
    {
        Task<ServiceGeneralResponse<Result>> ProcessImage(byte[] imageData, string projectName = "");
    }
}
