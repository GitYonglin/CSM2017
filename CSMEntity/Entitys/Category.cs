using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSMEntity.Entitys
{

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public string ImgUrl { get; set; }

        [ForeignKey("CategoryOne")]
        public int CategoryOneId { get; set; }
        //在返回json数据时避免循环问题
        [JsonIgnore]
        public CategoryOne CategoryOne { get; set; }
        /// <summary>
        /// 食材
        /// </summary>
        [JsonIgnore]
        public List<FoodAndCategory> FoodAndCategorys { get; set; }
        /// <summary>
        /// 菜谱
        /// </summary>
        [JsonIgnore]
        public List<CookbookAndCategory> CookbookAndCategorys { get; set; }
        /// <summary>
        /// 套餐
        /// </summary>
        [JsonIgnore]
        public List<PackageAndCategory> PackageAndCategorys { get; set; }
    }
    public class CategoryOne
    {
        [Key]
        public int CategoryOneId { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public string ImgUrl { get; set; }
        public List<Category> SubCategory { get; set; }
    }
}
