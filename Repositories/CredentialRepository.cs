﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ModuleAssignment.Repositories
{
    public class CredentialRepository : GenericRepository<Credential>, ICredentialRepository
    {
        private readonly EmployeeDbContext Context;
        private readonly IConfiguration _Config;

        public CredentialRepository(EmployeeDbContext IncomingContext, IConfiguration config) : base(IncomingContext) 
        {
            Context = IncomingContext;
            _Config = config;
        }


        public string GenerateToken(Credential credential)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var Claims = new List<Claim>
            {
                new Claim("id", credential.Id.ToString()),
                new Claim("empid", credential.EmployeeId.ToString()),
                new Claim("role", credential.Role)
            };

            var NewToken = new JwtSecurityToken(
                issuer: _Config["JwtSettings:Issuer"],
                audience: _Config["JwtSettings:Audience"],
                claims: Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(NewToken);
        }


        public Credential CheckCredentials(Credential credential)
        {
            Credential? ReqCred = Context.Credentials.FirstOrDefault(cred => cred.Username == credential.Username && cred.Password == credential.Password);
            if (ReqCred != null) return ReqCred;
            else return null;
        }


        public bool ReplacePassword(int id, string newPassword)
        {
            Credential? Cred = Context.Credentials.FirstOrDefault(cred => cred.Id == id);
            if (Cred != null)
            {
                Cred.Password = newPassword;
                return true;
            }
            else return false;
        }


        public bool UsernameExists(string username)
        {
            if (Context.Credentials.FirstOrDefaultAsync(cred => cred.Username == username) != null) return true;
            else return false;
        }


    }
}
