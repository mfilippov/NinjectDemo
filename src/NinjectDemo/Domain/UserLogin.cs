using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Cryptography;
using System.Text;

namespace NinjectDemo.Domain
{
	public class UserLogin : IdentityUserLogin<int> {}
}

