using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model {
    public class UserTwoFactorAuthenticationModel {
        [Required]
        public string TwoFactorCode { get; set; }
        public bool RememberMe { get; set; }
    }
}
