using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Model.Params.Basiclevel
{
   public class QueryInpatientInfoBasicParam: HisBaseParam
    {/// <summary>
     /// 身份证
     /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 机构编号
        /// </summary>
        public string InstitutionalNumber { get; set; }
    }
}
