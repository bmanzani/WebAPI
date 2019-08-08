using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebAPI.Entity;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI
{
    public class UsersDAO
    {
        private readonly IConfiguration _configuration;
        private readonly SSIS_TESTEContext _context;

        public UsersDAO(IConfiguration configuration, SSIS_TESTEContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public Users Find(string userID)
        {
            var user = _context.Users.Where(x => x.UserID == userID).FirstOrDefault();

            return user;
        }
    }
}
