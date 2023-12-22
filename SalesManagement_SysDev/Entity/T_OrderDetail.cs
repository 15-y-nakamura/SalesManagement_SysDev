using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class T_OrderDetail
    {
        [Key]
        public int OrDetailID { get; set; }         //受注詳細ID
        public int OrID { get; set; }               //受注ID
        public int PrID { get; set; }               //商品ID
        public int OrQuantity { get; set; }	        //数量
        public decimal OrTotalPrice { get; set; }   //合計金額

        public virtual M_Product M_Product { get; set; }
        public virtual T_Order T_Order { get; set; }
    }

    //データグリッド表示用
    class T_OrderDetailDsp
    {
        [DisplayName("受注詳細ID")]
        public int OrDetailID { get; set; }

        [DisplayName("受注ID")]
        public int OrID { get; set; }

        [DisplayName("商品ID")]
        public int PrID { get; set; }

        [DisplayName("数量")]
        public int OrQuantity { get; set; }

        [DisplayName("合計金額")]
        public decimal OrTotalPrice { get; set; }
    }
}
