using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class M_Message
    {

        [Key]
        [MaxLength(5)]
        [Required]
        public string MsgCD { get; set; }

        [MaxLength(150)]
        [Required]
        public string MsgComments { get; set; }


        [MaxLength(20)]
        [Required]
        public string MsgTitle { get; set; }

        public int MsgButton { get; set; }
        public int MsgICon { get; set; }
    }
}
