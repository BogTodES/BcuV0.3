using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold2
{
    public partial class UserClaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
