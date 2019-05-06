using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace jwtDemo
{
    public class LoginModule
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}