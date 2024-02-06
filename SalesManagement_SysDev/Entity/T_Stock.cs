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
    class T_Stock
    {
        [Key]
        public int StID { get; set; }           //在庫ID
        public int PrID { get; set; }           //商品ID
        public int StQuantity { get; set; }     //在庫数
        public int StFlag { get; set; }	        //在庫管理フラグ

        public virtual M_Product M_Product { get; set; }
    }

    class T_StockDsp 
    {
        [DisplayName("在庫ID")]
        public int StID { get; set; }

        [DisplayName("メーカー名")]
        public string MaName { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("在庫数")]
        public int StQuantity { get; set; }

        [DisplayName("安全在庫数")]
        public int PrSafetyStock { get; set; }

        [DisplayName("在庫管理フラグ")]
        public int StFlag { get; set; }
    }
}
