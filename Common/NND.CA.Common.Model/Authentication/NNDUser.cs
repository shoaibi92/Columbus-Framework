namespace NND.CA.Common.Model.Authentication
{
    using System;
    using System.Collections.Generic;

    public partial class NNDUser
    {
        public int ID { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> isValid { get; set; }
    }
}
