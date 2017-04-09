using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSMEntity.Entitys
{
    public class AdminUser
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string SessionKey { get; set; }
    }

}
