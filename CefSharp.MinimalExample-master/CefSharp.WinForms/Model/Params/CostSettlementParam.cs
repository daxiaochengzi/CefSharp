﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Model.Params
{
  public  class CostSettlementParam
    {/// <summary>
        /// 住院号
        /// </summary>
        public string PI_ZHY { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string PI_CZY { get; set; }
        /// <summary>
        /// 出院日期
        /// </summary>
        public string PI_CYRQ { get; set; }
        /// <summary>
        /// 出院情况
        /// </summary>
        public string PI_CYQK { get; set; }
        ///<summary>
        /// 出院主要诊断疾病ICD-10编码
        /// </summary>
        public string PI_ICD10 { get; set; }
        ///<summary>
        /// 出院次要诊断疾病ICD-10编码
        /// </summary>
        public string PI_ICD10_2 { get; set; }
        ///<summary>
        /// 出院次要诊断疾病ICD-10编码
        /// </summary>
        public string PI_ICD10_3 { get; set; }
        ///<summary>
        /// 出院主要诊断（确诊疾病）
        /// </summary>
        public string PI_CYZD { get; set; }
    }
}
