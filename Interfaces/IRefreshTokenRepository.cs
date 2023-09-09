using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        public RefreshToken GenerateRefreshToken(int credentialId);
    }
}
