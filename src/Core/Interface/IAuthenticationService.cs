using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IAuthenticationService
    {

        Task<UserInfo> Authenticate(string username, string password);
        void SendVerificationCode(string email);
        bool CheckVerificationCode(string email, string code);
        Task ChangePassword(string userName, string newPasword);
        Task AddRole(string userId, string role);
    }
}
