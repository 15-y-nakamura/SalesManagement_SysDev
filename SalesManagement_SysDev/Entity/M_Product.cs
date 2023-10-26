    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class M_Product
    {
        public M_Product()
        {
            T_ArrivalDetail = new HashSet<T_ArrivalDetail>();
            T_ChumonDetail = new HashSet<T_ChumonDetail>();
            T_HattyuDetail = new HashSet<T_HattyuDetail>();
            T_OrderDetail = new HashSet<T_OrderDetail>();
            T_SaleDetail = new HashSet<T_SaleDetail>();
            T_ShipmentDetail = new HashSet<T_ShipmentDetail>();
            T_Stock = new HashSet<T_Stock>();
            T_SyukkoDetail = new HashSet<T_SyukkoDetail>();
            T_WarehousingDetail = new HashSet<T_WarehousingDetail>();
        }

        [Key]
        public int PrID { get; set; }               //商品ID		
        public int MaID { get; set; }               //メーカID	
        [MaxLength(50)]
        [Required]
        public string PrName { get; set; }          //商品名		
        public decimal Price { get; set; }          //価格	
        [MaxLength(13)]
        public string PrJCode { get; set; }         //JANコード		
        public int PrSafetyStock { get; set; }      //安全在庫数		
        public int ScID { get; set; }               //小分類ID	                                                
        [MaxLength(20)]
        [Required]
        public string PrModelNumber { get; set; }   //型番
        [MaxLength(20)]
        [Required]
        public string PrColor { get; set; }         //色		
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PrReleaseDate { get; set; } //発売日		
        public int PrFlag { get; set; }             //商品管理フラグ
        public string PrHidden { get; set; }	    //非表示理由		

        public virtual M_Maker M_Maker { get; set; }
        public virtual M_SmallClassification M_SmallClassification { get; set; }
        public virtual ICollection<T_ArrivalDetail> T_ArrivalDetail { get; set; }
        public virtual ICollection<T_ChumonDetail> T_ChumonDetail { get; set; }
        public virtual ICollection<T_HattyuDetail> T_HattyuDetail { get; set; }
        public virtual ICollection<T_OrderDetail> T_OrderDetail { get; set; }
        public virtual ICollection<T_SaleDetail> T_SaleDetail { get; set; }
        public virtual ICollection<T_ShipmentDetail> T_ShipmentDetail { get; set; }
        public virtual ICollection<T_Stock> T_Stock { get; set; }
        public virtual ICollection<T_SyukkoDetail> T_SyukkoDetail { get; set; }
        public virtual ICollection<T_WarehousingDetail> T_WarehousingDetail { get; set; }
    }
}
