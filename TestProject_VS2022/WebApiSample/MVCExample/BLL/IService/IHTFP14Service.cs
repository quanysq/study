using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.BLL.IService
{
    public interface IHTFP14Service
    {
        ResponseResult ValidateLogin(HTFP14 hTFP14);
    }
}
