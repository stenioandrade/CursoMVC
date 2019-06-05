//using System.Web.Configuration;
//using Microsoft.Owin.Security.DataHandler.Encoder;
//using Microsoft.Owin.Security.Jwt;
//using Owin;
//using AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode;

//namespace EP.CursoMvc.Services.REST.ClienteAPI
//{
//    public class Startup
//    {
//        public void ConfigureOAuth(IAppBuilder app)
//        {
//            var issuer = "http://jwtauthzsrv.azurewebsites.net";
//            var audience = "099153c2625149bc8ecb3e85e03f0022";
//            var secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");

//            // Api controllers with an [Authorize] attribute will be validated with JWT
//            app.UseJwtBearerAuthentication(
//                new JwtBearerAuthenticationOptions
//                {
//                    AuthenticationMode = (AuthenticationMode) System.Web.Configuration.AuthenticationMode.None,
//                    AllowedAudiences = new[] { audience },
//                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
//                    {
//                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
//                    }
//                });

//        }
//    }
//}