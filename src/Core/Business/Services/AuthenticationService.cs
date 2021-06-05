using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interface;
using DTO;
using DTO.CustomModel;
using Entity;
using Microsoft.Extensions.Options;
using Entity.Enum;
using DTO.Configuration;


namespace Business.DataServices
{

    public class AuthenticationService : IAuthenticationService
    {

        private readonly JWT _appSettings;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHasher passwordHasher;
        private readonly IEmailQueueService emailQueueService;
        private readonly IRandomUtility randomUtility;
        private readonly IMapper mapper;

        public AuthenticationService(IOptions<JWT> appSettings,
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IEmailQueueService emailQueueService,
            IRandomUtility randomUtility,
            IMapper mapper
            )
        {
            _appSettings = appSettings.Value;
            this.unitOfWork = unitOfWork;
            this.passwordHasher = passwordHasher;
            this.emailQueueService = emailQueueService;
            this.randomUtility = randomUtility;
            this.mapper = mapper;
        }
        public async Task<UserInfo> Authenticate(string username, string password)
        {
            User user = unitOfWork.UserRespository.Table.Where(x => x.Email == username).FirstOrDefault();
            if (user == null)
                throw new Exception("Emai or password is not correct");
            if (!user.EmailConfirmed)
                throw new Exception("Email is not verified");
            var isVerified = passwordHasher.Check(user.Password, password);
            if (!isVerified.Verified)
                throw new Exception("Emai or password is nor correct");
            var userInfo = new UserInfo()
            {
                Email = user.Email,
                Id = user.Id,
                Roles = new List<string>(),
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return userInfo;
        }
        public void SendVerificationCode(string email)
        {
            var code = randomUtility.GenerateRandomString(6);
            unitOfWork.VerificationCodeRespository.Add(new VerificationCode()
            {
                Entity = email,
                Code = code,
                GeneratedAt = DateTime.UtcNow

            });
            unitOfWork.SaveChanges();
            var emailQueue = new EmailQueue()
            {
                ToEmail = email,
                Subject = "Verification code",
                Body = $"Your verification code for registration on  is {code}",
                CreatedAt = DateTime.UtcNow
            };
            emailQueueService.AddEmailQueue(emailQueue);
        }
        public bool CheckVerificationCode(string email, string code)
        {
            var verification = unitOfWork.VerificationCodeRespository.Table.Where(x => x.Entity == email && x.Code == code).FirstOrDefault();
            if (verification != null)
            {
                unitOfWork.VerificationCodeRespository.DeleteMany(x => x.Entity == email);
                unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task ChangePassword(string userName, string newPasword)
        {
            var user = await unitOfWork.UserRespository.GetOneAsync(x => x.Email == userName);
            var hashedPassword = "";
            //user.PasswordHash = hashedPassword;
            await unitOfWork.SaveChangesAsync();
        }
        public async Task AddRole(string userId, string role)
        {

        }
    }
}
