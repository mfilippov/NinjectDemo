using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Cryptography;
using System.Text;

namespace NinjectDemo.Domain
{
	public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
	{
		public string Name { get; set; }


		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			return userIdentity;
		}

		public string GetGravatarHash()
		{
			var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Email));
			var sb = new StringBuilder();

			foreach (var t in hash)
			{
				sb.Append(t.ToString("x2"));
			}
			return sb.ToString();
		}
	}
}

