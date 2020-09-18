using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold2
{
    public partial class UserLogins
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
    }
}
