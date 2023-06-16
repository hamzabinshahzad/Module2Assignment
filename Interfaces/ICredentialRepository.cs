using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface ICredentialRepository : IGenericRepository<Credential>
    {
        public string GenerateToken(Credential credential);
        public Credential CheckCredentials(Credential credential);
        //public int GetCredentialEmpId(int credentialId);
    }
}
