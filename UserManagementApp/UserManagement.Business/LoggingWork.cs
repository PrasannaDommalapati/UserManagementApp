using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Business.Helpers;
using UserManagement.Business.Models;
using UserManagement.DataAccess;
using UserManagement.DataAccess.Entity;

namespace UserManagement.Business
{
    public class LoggingWork : ILoggingWork
    {
        private UserDataContext _dataContext { get; }

        public LoggingWork(UserDataContext dataContext)
        {
            _dataContext = dataContext.ValidateNotNull();
        }

        public Task AddOrganisationToUserAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task AddRoleToUserAsync(int userId, UserRole role)
        {
            var user = await _dataContext
                .Users
                .Include("Roles")
                .FirstOrDefaultAsync(a => a.Id == userId)
                .ConfigureAwait(false);

            user.Roles.Add(role);

            await _dataContext
                .Users
                .AddAsync(user)
                .ConfigureAwait(false);

            await _dataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }

        public Task CreateOrganisationAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateUserAsync(UserModel userDto)
        {

            var random = new Random().Next(1000, 9999).ToString();

            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Birthday = userDto.Birthday,
                IsActive = false,
                SecurityCode = GetHash(SHA256.Create(), random),
                CodeExpiry = DateTime.UtcNow.AddMinutes(30),
                DateCreated = DateTime.UtcNow.Date,
                DateModified = DateTime.UtcNow.Date,
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        Role = nameof(UserRoleTypes.User)
                    }
                }
            };

            await _dataContext
                .Users
                .AddAsync(user)
                .ConfigureAwait(false);

            await _dataContext
                .UpdateAsync()
                .ConfigureAwait(false);

            Mailer.Send(userDto.Email, random);
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            var data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public async Task DeleteUserAsync(int userId)
        {
            var user = await _dataContext
                .Users
                .Include(d => d.Roles)
                .Include(d => d.Organisations)
                .FirstOrDefaultAsync(d => d.Id == userId)
                .ConfigureAwait(false);

            _dataContext.Users.Remove(user);

            await _dataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }

        public async Task UpdateUserAsync(UserModel userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Birthday = userDto.Birthday,
                Organisations = userDto.Organisations,
                Roles = userDto.Roles,
                DateCreated = DateTime.UtcNow.Date,
                DateModified = DateTime.UtcNow.Date
            };

            _dataContext
               .Users
               .Update(user);

            await _dataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }

        public async Task UpdateActiveStatus(string userEmail, bool status)
        {
            var user = await _dataContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == userEmail)
                .ConfigureAwait(false);

            user.IsActive = status;

            _dataContext.Users.Attach(user).State = EntityState.Modified;

            await _dataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }
    }
}
