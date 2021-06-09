using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TBlFantasy.Entity;

namespace TBlFantasy.Web
{
    [Route("api/[controller]")]
    public class ApiController : SecureDbController
    {
        private UserManager<TBLUser> _userManager;
        public UserManager<TBLUser> UserManager => _userManager ?? (UserManager<TBLUser>)HttpContext?.RequestServices.GetService(typeof(UserManager<TBLUser>));

        public Guid UserId
        {
            get
            {
                var userId = UserManager.GetUserId(User);
                return Guid.Parse(userId);
            }
        }

        [NonAction]
        public IActionResult Success(string message = default(string), object data = default(object), int code = 200)
        {
            return Ok(
                new TBLReturn()
                {
                    Success = true,
                    Message = message,
                    Data = data,
                    Code = code
                }
            );
        }
        [NonAction]
        public IActionResult Error(string message = default(string), string internalMessage = default(string), object data = default(object), int code = 400, List<TBLReturnError> errorMessages = null)
        {
            var rv = new TBLReturn()
            {

                Success = false,
                Message = message,
                InternalMessage = internalMessage,
                Data = data,
                Code = code
            };
            if (rv.Code == 500)
                return StatusCode(500, rv);
            if (rv.Code == 401)
                return Unauthorized();
            if (rv.Code == 403)
                return Forbid();

            return BadRequest(rv);

        }
    }
}
