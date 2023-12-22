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
    class T_Order
    {
        public T_Order()
        {
            T_Arrival = new HashSet<T_Arrival>();
            T_Chumon = new HashSet<T_Chumon>();
            T_OrderDetail = new HashSet<T_OrderDetail>();
            T_Shipment = new HashSet<T_Shipment>();
            T_Syukko = new HashSet<T_Syukko>();
        }

        [Key]
        public int OrID { get; set; }           //受注ID		
        public int SoID { get; set; }           //営業所ID		
        public int EmID { get; set; }           //社員ID		
        public int ClID { get; set; }           //顧客ID
        [MaxLength(50)]
        [Required]
        public string ClCharge { get; set; }    //顧客担当者名
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime OrDate { get; set; }    //受注年月日
        public int OrStateFlag { get; set; }    //受注状態フラグ
        public int OrFlag { get; set; }         //受注管理フラグ
        public string OrHidden { get; set; }    //非表示理由

        public virtual M_Client M_Client { get; set; }
        public virtual M_Employee M_Employee { get; set; }
        public virtual M_SalesOffice M_SalesOffice { get; set; }
        public virtual ICollection<T_Arrival> T_Arrival { get; set; }
        public virtual ICollection<T_Chumon> T_Chumon { get; set; }
        public virtual ICollection<T_OrderDetail> T_OrderDetail { get; set; }
        public virtual ICollection<T_Shipment> T_Shipment { get; set; }
        public virtual ICollection<T_Syukko> T_Syukko { get; set; }
    }

    //データグリッド表示用
    class T_OrderDsp
    {
        [DisplayName("受注ID")]
        public int OrID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("社員ID")]
        public int EmID { get; set; }

        [DisplayName("顧客ID")]
        public int ClID { get; set; }

        [DisplayName("顧客担当者名")]
        public string ClCharge { get; set; }

        [DisplayName("受注年月日")]
        public DateTime? OrDate { get; set; }

        [DisplayName("受注状態フラグ")]
        public int OrStateFlag { get; set; }

        [DisplayName("受注管理フラグ")]
        public int OrFlag { get; set; }

        [DisplayName("非表示理由")]
        public string OrHidden { get; set; }
    }
}
