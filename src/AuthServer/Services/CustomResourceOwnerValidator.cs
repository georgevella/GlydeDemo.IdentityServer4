using System.Threading.Tasks;
using IdentityServer4.Validation;

namespace AuthServer.Services
{
    public class CustomResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //if (_userValidator.ValidatePassword(context.UserName, context.Password))
            //{
            //    context.Result = new GrantValidationResult(_rep.GetUserByUsername(context.UserName).Id, "password", null, "local", null);
            //    return Task.FromResult(context.Result);
            //}
            //context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
            //return Task.FromResult(context.Result);            

            context.Result = new GrantValidationResult("65388F8A-30F3-4ECC-9780-977CF5C37938", "password");
            return Task.FromResult(context.Result);
        }
    }
}