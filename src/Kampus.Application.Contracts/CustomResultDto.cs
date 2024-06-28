using System;
using System.Collections.Generic;
using System.Text;

namespace Kampus
{
    public class CustomResultDto
    {
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
