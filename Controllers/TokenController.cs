using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OSDataAccessLibrary.DataServices;
using OSDataAccessLibrary.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OSBookReviewWepApi.Controllers
{
    // add routing
    [Route("[controller]")]

    public class TokenController : ControllerBase
    {
        private readonly ILoginData _loginData;

        public TokenController(ILoginData loginData)
        {
            _loginData = loginData;
        }
        // post request for new login, checks if user creditenal are valid and if so then verifies device is registerd and if returns a valid login to mobile device
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> GetLogin(string username, string password, string registereddevicecode)
        {
            Login login = new()
            {
                UserName = username,
                UserPword = password,
                RegisteredDeviceCode = registereddevicecode
            };

            var res = new ObjectResult(await IsValidLogin(login));
            return res;
        }
        private async Task<List<Login>> IsValidLogin(Login login)
        {
            List<Login> templist = new();
            List<Login> finalList = new();
            // verify login credientals
            templist = await _loginData.VerifyLogin(username: login.UserName, password: login.UserPword);
            // set user details from first check
            if (templist.Count > 0)
            {
                foreach (Login l in templist)
                {
                    login.Userid = l.Userid;
                    login.Uaid = l.Uaid;
                    login.AccessLevel = l.AccessLevel;
                    login.ValidUser = true;
                }
            }
            // if creditentals valid then get user data
            if (!login.Userid.Equals(0))
            {
                // check if the users device is registered on the system if so genereate bearer token           
                if (await _loginData.RegisteredDevice(login.RegisteredDeviceCode, login.Userid))
                {
                    login.DeviceRegistered = true;
                    login.AccessToken = GenerateToken(login.UserName);
                }
                else
                {
                    login.DeviceRegistered = false;
                }
            }

            finalList.Add(login);

            return finalList;
        }
        // generates the users jwt token.
        private static string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OSPProject2022MTUBrianRDanielC")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}