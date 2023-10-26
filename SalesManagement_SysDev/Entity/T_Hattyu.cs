using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class T_Hattyu
    {
        public T_Hattyu()
        {
            T_HattyuDetail = new HashSet<T_HattyuDetail>();
            T_Warehousing = new HashSet<T_Warehousing>();
        }

        [Key]
        public int HaID { get; set; }                   //発注ID	
        public int MaID { get; set; }                   //メーカID	
        public int EmID { get; set; }                   //社員ID
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime HaDate { get; set; }            //発注年月日	
        public int WaWarehouseFlag { get; set; }	    //入庫済フラグ（倉庫）
        public int HaFlag { get; set; }	                //発注管理フラグ
        public string HaHidden { get; set; }            //非表示理由	

        public virtual M_Employee M_Employee { get; set; }
        public virtual M_Maker M_Maker { get; set; }
        public virtual ICollection<T_HattyuDetail> T_HattyuDetail { get; set; }
        public virtual ICollection<T_Warehousing> T_Warehousing { get; set; }
    }
}
