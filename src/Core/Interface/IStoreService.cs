using DTO;
using DTO.CustomModel;
using Entity;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IStoreService
    {
        Store GetStore(int id);     
        void UpdareStore(Store store);

    }
}
