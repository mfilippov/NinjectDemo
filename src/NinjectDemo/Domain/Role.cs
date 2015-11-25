using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NinjectDemo.Domain
{
	public class Role : IdentityRole<int, UserRole> {}
}

