using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingroomAdminWebApp.Models.Account
{
    public class User
    {
        [Required(ErrorMessage = "Please enter username.")]
        public String iUsername { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        public String iPassword { get; set; }
    }
}