using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCMDotNetCore.WinFormsApp.Models
{
    internal enum EnumFormControlType
    {
        None = 0,
        Edit = 1,
        Delete = 2,
        Create,
        Confirm,
    }
}
