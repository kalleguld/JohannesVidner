using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Resources;
using System.Web;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Resources;

namespace JohannesVidnerProject.Models.Home
{
    //HttpContext.GetGlobalResourceObject(“Resourcefilename”, “resourcekey″).ToString();
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}