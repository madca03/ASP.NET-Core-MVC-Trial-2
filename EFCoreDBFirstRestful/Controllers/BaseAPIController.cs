using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreDBFirstRestful.Constants;
using EFCoreDBFirstRestful.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDBFirstRestful.Controllers
{
    public abstract class BaseAPIController : Controller
    {
        protected readonly EmployeeContext db;

        public BaseAPIController(EmployeeContext context)
        {
            db = context;
        }

        protected EmployeeContext GetDBContext()
        {
            return db;
        }

        protected IActionResult SendSuccessStatus(dynamic payload = null)
        {
            if (payload == null) return Ok(new { status = APIResponseStatusCodes.SUCCESS });

            return Ok(new
            {
                status = APIResponseStatusCodes.SUCCESS,
                result = payload
            });
        }

        protected IActionResult SendIDNotFoundStatus()
        {
            return Ok(new { status = APIResponseStatusCodes.ID_NOT_FOUND });
        }

        protected IActionResult SendResourceExists(string message)
        {
            return Ok(new
            {
                status = APIResponseStatusCodes.RESOURCE_EXISTS,
                message = message
            });
        }
    }
}