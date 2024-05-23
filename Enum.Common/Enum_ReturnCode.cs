using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum.Common
{
    public enum Enum_ReturnCode
    {
        Success = 1,
        DataInValid = -1,
        DataIsNull = -2,
        Duplicate = -3,
        NotFound = -4,
        Error = -5,
    }
    
}
