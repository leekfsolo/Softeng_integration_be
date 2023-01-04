using Microsoft.EntityFrameworkCore;
using Softeng_integration_be.Models;

namespace Softeng_integration_be.Provider
{
	public class UsersProvider : BaseProvider
	{
		public async Task<List<User>> GetAll()
		{
			return await db.Users.AsNoTracking().ToListAsync();
		}

		public User Authenticate(User userLogin)
		{
			return GetAll().Result.Where(user => userLogin.Email.Equals(user.Email) && userLogin.Password.Equals(user.Password)).FirstOrDefault();
		}
	}
}
