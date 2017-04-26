using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSMEntity.Entitys
{
    public class Food
    {

        [Key]
        public Guid FoodId { get; set; }
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
        /// 剂量
        /// </summary>
        public int Dose { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int Inventory { get; set; }
        /// <summary>
        /// 最小剂量
        /// </summary>
        public int MinDose { get; set; }
        /// <summary>
        /// 上架
        /// </summary>
        public bool Shelves { get; set; }
        /// <summary>
        /// 进货日期
        /// </summary>
        public DateTime PurchasesDate { get; set; }
        /// <summary>
        /// 插入日期
        /// </summary>
        public DateTime Insertdate { get; set; }

        public List<FoodImages> FoodImages { get; set; }

        [JsonIgnore]
        public List<FoodAndCategory> FoodAndCategorys { get; set; }

        [JsonIgnore]
        public List<CookbookAndFood> CookbookAndFoods { get; set; }

        [JsonIgnore]
        public List<PackageAndFood> PackageAndFoods { get; set; }

    }

    public class FoodAndCategory
    {
        public Guid FoodId { get; set; }
        public Food Food { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class FoodImages:Images
    {
        [Key]
        public int FoodImagesId { get; set; }

        [ForeignKey("Food")]
        public Guid FoodId { get; set; }
        [JsonIgnore]
        public Food Food { get; set; }
    } 
}
