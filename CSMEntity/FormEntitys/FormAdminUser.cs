using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSMEntity.FormEntitys
{
    public class FormAdminUser
    {
        [Required(ErrorMessage ="用户名不能为空！")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="密码不能为空！")]
        public string Password { get; set; }
    }
}
