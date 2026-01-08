using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1
{
    internal class userService
    {
        public static bool CreateUser(
            string username,
            string password,
            string fullName,
            string role)
            {
                var hasher = new PasswordHasher<object>();
                string hashedPassword = hasher.HashPassword(null, password);

                string qry = @"INSERT INTO users (username, pass, fullName, uRole)
                           VALUES (@Username, @Password, @FullName, @Role)";

                Hashtable ht = new Hashtable
                {
                    { "@Username", username },
                    { "@Password", hashedPassword },
                    { "@FullName", fullName },
                    { "@Role", role }
                };

            return MainClass.SQL(qry, ht) > 0;
        }
    }
}
