namespace NND.CA.Common.Model.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class NNDUser
    {

        [DataType(DataType.Text)]
        [Display(Name = "ID")]
        public string ID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Role")]
        public NNDRoles Role { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "isValid")]
        public Nullable<bool> isValid { get; set; }
 
  
        [Display(Name = "LockoutEnabled")]
        public bool LockoutEnabled { get; set; }

    }
}

