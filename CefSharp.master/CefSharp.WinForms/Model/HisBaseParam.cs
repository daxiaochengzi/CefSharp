using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Model
{
  public  class HisBaseParam
    {/// <summary>
     /// 医保医院编号
     /// </summary>
        public string YbOrgCode { get; set; }
        /// <summary>
        /// 医院ID
        /// </summary>
        public Guid OrgID { get; set; }
        /// <summary>
        /// 门诊或住院业务ID
        /// </summary>
        public Guid BID { get; set; }
        /// <summary>
        /// 操作人员ID
        /// </summary>
        public Guid EmpID { get; set; }
        /// <summary>
        /// 医保交易码
        /// </summary>
        public string BsCode { get; set; }
        /// <summary>
        /// HIS调用医保交易动作产生的唯一ID
        /// </summary>
        public Guid TransKey { get; set; }
    }
}
