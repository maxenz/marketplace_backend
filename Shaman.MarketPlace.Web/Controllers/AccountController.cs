﻿using Microsoft.AspNet.Identity;
using Ninject;
using Shaman.MarketPlace.Data;
using Shaman.MarketPlace.Domain.DTOS;
using Shaman.MarketPlace.Web.CORS;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shaman.MarketPlace.Web.Controllers
{
    [RoutePrefix("api/Account")]
    [CustomCORS]
    public class AccountController : ApiController
    {
        [Inject]
        public UnitOfWork _uow { get; set; }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(ApplicationUser userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _uow.UserRepository.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.UserRepository.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
