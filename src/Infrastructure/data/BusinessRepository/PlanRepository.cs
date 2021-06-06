
using Entity;
using Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Data
{
    public class PlanRepository :Repository<User>
    {      
        public PlanRepository(AppDbContext dbContext):base(dbContext)
        {
           
        }

    }
}
