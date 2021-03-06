﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Model.Dto.Single
{/// <summary>
/// 处方查询单数
/// </summary>
  public  class SinglePrescriptionDetailQueryDto:IniDto
    { 
        public PrescriptionDetailQueryRow PI_CFMX { get; set; }
    }

    public class PrescriptionDetailQueryRow
    {
        public PrescriptionDetailPI_CFMX ROW { get; set; }
    }
    public class PrescriptionDetailQueryRowList
    {
        public List<PrescriptionDetailPI_CFMX>  ROW { get; set; }
    }
    /// <summary>
    /// 处方查询复数
    /// </summary>

    public class PrescriptionDetailQueryListDto : IniDto
    {
        public PrescriptionDetailQueryRowList PI_CFMX { get; set; }
    }

    public class PrescriptionDetailPI_CFMX
    {
        /// <summary>
        /// 行号
        /// </summary>
        public string CO { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        public string AKB020 { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string AKC190 { get; set; }

        /// <summary>
        /// 处方号
        /// </summary>
        public string AKC220 { get; set; }
        /// <summary>
        /// 费用顺序号
        /// </summary>
        public string AKC584 { get; set; }
        /// <summary>
        /// 收费项目编码
        /// </summary>
        public string AKC222 { get; set; }
        /// <summary>
        /// 医院内码
        /// </summary>
        public string AKC515 { get; set; }
        /// <summary>
        /// 处方日期
        /// </summary>
        public string AKC221 { get; set; }
        /// <summary>
        /// 结算日期
        /// </summary>
        public string AAE040 { get; set; }
        /// <summary>
        /// 收费类别
        /// </summary>
        public string AKA063 { get; set; }
        /// <summary>
        /// 收费项目名称
        /// </summary>
        public string AKC223 { get; set; }
        /// <summary>
        /// 收费项目等级
        /// </summary>

        public string AKA065 { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public string AKC225 { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string AKC226 { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string AKC227 { get; set; }
        /// <summary>
        /// 自付金额
        /// </summary>
        public string AKC228 { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>
        public string AKA070 { get; set; }
        /// <summary>
        /// 每次用量
        /// </summary>
        public string AKA071 { get; set; }
        /// <summary>
        /// 使用频次
        /// </summary>
        public string AKA072 { get; set; }
        /// <summary>
        /// 用法
        /// </summary>
        public string AKA073 { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string AKA074 { get; set; }
        /// <summary>
        /// 是否单病种住院除外内容
        /// </summary>
        public string CKE619 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string AKA067 { get; set; }
        /// <summary>
        /// 执行天数
        /// </summary>
        public string AKC229 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string AAE013 { get; set; }
    }
}
