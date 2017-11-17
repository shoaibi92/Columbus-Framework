namespace NND.CA.Common.Model.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class NNDUser
    {
        [DataType(DataType.Custom)]
        public int ID { get; set; }
        public NNDRoles Role { get; set; }
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Nullable<bool> isValid { get; set; }

    }
}
