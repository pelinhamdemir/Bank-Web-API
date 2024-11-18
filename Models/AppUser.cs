using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace WebAPIproject.Models
{
    public class AppUser: IdentityUser
    {
        public int Risk{get; set;}   
    }
}