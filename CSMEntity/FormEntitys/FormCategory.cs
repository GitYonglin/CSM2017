using CSMEntity.Entitys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSMEntity.FormEntitys
{
    public class FormCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string url { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile File { get; set; }
    }
}
