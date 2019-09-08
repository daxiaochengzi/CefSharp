﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Model.Params.Basiclevel.Param
{
   public class SaveMedicalInsuranceResidentInfoBasiclevelParam: HisBaseParam
    {/// <summary>
     /// id
     /// </summary>

        public string DataAllId { get; set; }
        /// <summary>
        /// 内容json
        /// </summary>
      
        public string ContentJson { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 数据id
        /// </summary>
        public string DataId { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 身份证
     
        public string IdCard { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
      
        public string OrgCode { get; set; }
    }
}
