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
    class T_Chumon
    {
        public T_Chumon()
        {
            T_ChumonDetail = new HashSet<T_ChumonDetail>();
            T_Sale = new HashSet<T_Sale>();
        }

        [Key]
        public int ChID { get; set; }               //注文ID	
        public int SoID { get; set; }               //営業所ID	
        public int? EmID { get; set; }              //社員ID	
        public int ClID { get; set; }               //顧客ID	
        public int OrID { get; set; }               //受注ID
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ChDate { get; set; }        //注文年月日
        public int ChStateFlag { get; set; }        //注文状態フラグ
        public int ChFlag { get; set; }	            //注文管理フラグ
        public string ChHidden { get; set; }	    //非表示理由	

        public virtual M_Client M_Client { get; set; }
        public virtual M_Employee M_Employee { get; set; }
        public virtual M_SalesOffice M_SalesOffice { get; set; }
        public virtual T_Order T_Order { get; set; }
        public virtual ICollection<T_ChumonDetail> T_ChumonDetail { get; set; }
        public virtual ICollection<T_Sale> T_Sale { get; set; }
    }

    class T_ChumonDsp
    {
        [DisplayName("注文ID")]
        public int ChID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("社員名")]
        public string EmName { get; set; }

        [DisplayName("顧客名")]
        public string ClName { get; set; }

        [DisplayName("受注ID")]
        public int OrID { get; set; }

        [DisplayName("注文年月日")]
        public DateTime ChDate { get; set; }

        [DisplayName("注文状態フラグ")]
        public int ChStateFlag { get; set; }
        
        [DisplayName("注文管理フラグ")]
        public int ChFlag { get; set; }
        
        [DisplayName("非表示理由")]
        public string ChHidden { get; set; }
    }

}
