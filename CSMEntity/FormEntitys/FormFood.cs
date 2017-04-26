using System;
using System.Collections.Generic;
using System.Text;

namespace CSMEntity.FormEntitys
{
    public class FormFood
    {
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
        public string Shelves { get; set; }
        /// <summary>
        /// 进货日期
        /// </summary>
        public string PurchasesDate { get; set; }
        /// <summary>
        /// 插入日期
        /// </summary>
        public string Insertdate { get; set; }
    }

    public class FormFoods: FormFood
    {
        public List<int> categorys { get; set; }
        public List<FormImages> Imgs { get; set; }
    }
}
