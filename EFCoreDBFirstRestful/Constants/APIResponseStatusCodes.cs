using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreDBFirstRestful.Constants
{
    public static class APIResponseStatusCodes
    {
        public static int SUCCESS = 0;
        public static int ID_NOT_FOUND = 400;
        public static int RESOURCE_EXISTS = 401;
    }
}
