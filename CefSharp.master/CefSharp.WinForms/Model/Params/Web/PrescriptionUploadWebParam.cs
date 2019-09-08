using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Model.Params.Web
{
   public class PrescriptionUploadWebParam
    {/// <summary>
    /// 明细id
    /// </summary>
        public List<string> BusinessIdDetailList { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public  string IdCard { get; set; }
    }
}
