
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

    
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork unitOfWork;

        public StoreService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Store GetStore(int id)
        {
            return unitOfWork.StoreRepository.GetOne(x=>x.Id!=0);
        }

        public void UpdareStore(Store store)
        {
            unitOfWork.SaveChanges();
        }
    }
}
