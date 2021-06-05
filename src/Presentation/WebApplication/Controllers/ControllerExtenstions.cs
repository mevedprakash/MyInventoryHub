using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.ViewModel;

namespace WebApplication.Controllers
{
    public static class ControllerExtenstions
    {
        public static AppUser GetAppUser(this ControllerBase controller)
        {
            return new AppUser()
            {
               Id= controller.User.FindFirst(ClaimTypes.NameIdentifier).Value
             };           
        }
    }
}
