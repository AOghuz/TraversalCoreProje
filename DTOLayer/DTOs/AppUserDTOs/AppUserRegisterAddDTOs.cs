using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserRegisterDTOs
{
    public class AppUserRegisterAddDTOs
    {
       
        public string? Name { get; set; }
      
        public string? SurName { get; set; }
        
        public string? Username { get; set; }
        
        public string? Mail { get; set; }
       
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
