using System;
using System.Collections.Generic;
using System.Text;

namespace Kampus
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
    }
}
