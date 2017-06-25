using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace AuthServer.Services
{
    public class CustomProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subjectId = context.Subject.GetSubjectId();
                //var user = _repository.GetUserById(subjectId);

                var claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Subject, TestConstants.UserId),
                    new Claim("jurisdiction", "mga"),

                    //add as many claims as you want!new Claim(JwtClaimTypes.Email, user.Email),new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
                };

                context.IssuedClaims = claims;
                return Task.FromResult(0);
            }
            catch (Exception x)
            {
                return Task.FromResult(0);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            //var user = _repository.GetUserById(context.Subject.GetSubjectId());
            //context.IsActive = (user != null) && user.Active;

            context.IsActive = true;
            return Task.FromResult(0);
        }
    }
}