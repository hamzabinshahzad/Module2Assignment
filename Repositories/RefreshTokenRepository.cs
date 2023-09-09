using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;
using System.Security.Cryptography;

namespace ModuleAssignment.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly EmployeeDbContext Context;
        
        public RefreshTokenRepository(EmployeeDbContext IncomingContext) : base(IncomingContext) 
        { 
            Context = IncomingContext;
        }


        public RefreshToken GenerateRefreshToken(int credentialId)
        {
            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Created = DateTime.Now,
                Expires = DateTime.Now.AddDays(1),
                CredentialId = credentialId
            };
        }


    }
}
