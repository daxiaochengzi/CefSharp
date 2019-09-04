﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Model.Params
{/// <summary>
 /// 费用预结算
 /// </summary>
    public class CostPreSettlementParam
    {
        /// <summary>
        /// 住院号
        /// </summary>
        public string PI_ZHY { get; set; }
        /// <summary>
        /// 出院日期
        /// </summary>
        public string PI_CYRQ { get; set; }
    }
}
