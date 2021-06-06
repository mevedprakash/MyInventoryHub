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
    
    public class CommonService : ICommonService
    {
        private readonly IUnitOfWork unitOfWork;

        public CommonService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Unit>> GetUnits()
        {
            return await unitOfWork.UnitRepository.GetAsync();
        }
    }
}
