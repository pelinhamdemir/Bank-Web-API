using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebAPIproject.Models;
using WebAPIproject.DTOS.Ac;

namespace WebAPIproject.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user );
    }
}