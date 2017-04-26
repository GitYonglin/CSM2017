using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSMEntity.Entitys
{

    public class Package
    {
        [Key]
        public Guid PackageId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int Inventory { get; set; }
        /// <summary>
        /// 菜谱
        /// </summary>
        [JsonIgnore]
        public List<PackageAndCookbook> PackageAndCookbooks { get; set; }
        /// <summary>
        /// 食材
        /// </summary>
        [JsonIgnore]
        public List<PackageAndFood> PackageAndFoods { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        [JsonIgnore]
        public List<PackageAndCategory> PackageAndCategorys { get; set; }
    }
    /// <summary>
    /// 菜谱
    /// </summary>
    public class PackageAndCookbook
    {
        public Guid CookbookId { get; set; }
        public Cookbook Cookbook { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }
        /// <summary>
        /// 使用量
        /// </summary>
        public int Dose { get; set; }
    }
    /// <summary>
    /// 食材
    /// </summary>
    public class PackageAndFood
    {
        public Guid FoodId { get; set; }
        public Food Food { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }
        /// <summary>
        /// 使用量
        /// </summary>
        public int Dose { get; set; }
    }
    /// <summary>
    /// 分类
    /// </summary>
    public class PackageAndCategory
    {
        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    public class PackageImages : Images
    {
        [Key]
        public int PackageImagesId { get; set; }

        [ForeignKey("Package")]
        public Guid PackageId { get; set; }
        [JsonIgnore]
        public Package Package { get; set; }
    }
}
