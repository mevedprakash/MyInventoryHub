
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

    
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public User GetUserById(string id)
        {
            return unitOfWork.UserRespository.GetById(id);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            // return await userManager.FindByEmailAsync(email);
            throw new Exception();
        }
        
        public List<User> GetUsers()
        {
            return unitOfWork.UserRespository.Get().ToList();
        }

        public async Task<User> RegisterUser(User user,string password, string role)
        {
            //var result= await userManager.CreateAsync(user, password);
            //if (result.Succeeded)
            //{
            //    result=await userManager.AddToRoleAsync(user, role);
            //}
            //return result;
            throw new Exception();
        }
       

        public void UpdareUser(User user)
        {
            unitOfWork.SaveChanges();
        }

       
    }
}
