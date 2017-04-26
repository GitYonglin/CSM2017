using CSMEntity.Entitys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSMEntity.FormEntitys
{
    public class FormImages:Images
    {
        public IFormFile file { get; set; }
    }
}
