using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Model.Dto;
using BenDing.Model.Params;
using BenDing.Xml;
namespace BenDing.Service
{/// <summary>
 /// 居民医保接口
 /// </summary>
    public class ResidentMedicalInsurance
    {/// <summary>
     /// 获取个人基础资料
     /// </summary>
     /// <param name="param"></param>
        public UserInfoDto GetUserInfo(UserInfoParam param)
        {
            UserInfoDto resultData = new UserInfoDto();
           // var Data = XmlHelp.DeSerializerModel(new IdentificationSpecialDownloadListDto());

            var xmlStr = XmlHelp.SaveXml(param);
            if (xmlStr)
            {
                int result = WorkersMedicalInsurance.CallService_cxjb("CXJB001");
                if (result == 1)
                {
                    resultData = XmlHelp.DeSerializerModel(new UserInfoDto());
                  
                }

            }

            return resultData;

        }
        /// <summary>
        /// 入院登记
        /// </summary>
        /// <returns></returns>
        public string HospitalizationRegister()
        {
            return "";
        }
        /// <summary>
        /// 住院资料修改
        /// </summary>
        /// <returns></returns>
        public string HospitalizationModify()
        {
            return "";
        }
        /// <summary>
        /// 处方上传
        /// </summary>
        /// <returns></returns>
        public string PrescriptionUpload()
        {
            return "";
        }
        /// <summary>
        /// 处方删除
        /// </summary>
        public void PrescriptionDelete()
        {
        }
        /// <summary>
        /// 处方明细查询
        /// </summary>
        public void PrescriptionDetailQuery()
        {
        }
        /// <summary>
        /// 批次确认
        /// </summary>
        public void BatchConfirmation()
        {
        }
        /// <summary>
        /// 批次未确认
        /// </summary>
        public void BatchUnConfirmation()
        {
        }
        /// <summary>
        /// 费用预结算
        /// </summary>
        public void CostPreSettlement()
        {
        }
        /// <summary>
        /// 费用结算
        /// </summary>
        public void CostSettlement()
        {
        }
        /// <summary>
        /// 入院结算取消
        /// </summary>
        public void HospitalizedSettlementCancel()
        {
        }
        /// <summary>
        /// 费用结算查询
        /// </summary>
        public void CostSettlementQuery()
        {
        }
        /// <summary>
        /// 项目下载
        /// </summary>
        public void ProjectDownload()
        {
        }
        /// <summary>
        /// 特殊疾病认定
        /// </summary>
        public void IdentificationSpecialDiseases()
        {
        }
        /// <summary>
        /// 特殊疾病认定取消
        /// </summary>
        public void IdentificationSpecialDiseasesCancel()
        {
        }
        /// <summary>
        /// 特殊疾病查询
        /// </summary>
        public void IdentificationSpecialQuery()
        {
        }
        /// <summary>
        /// 特殊疾病申报变更
        /// </summary>
        public void IdentificationSpecialChange()
        {
        }
        /// <summary>
        /// 特殊疾病预结算
        /// </summary>
        public void IdentificationSpecialSettlement()
        {
        }
        /// <summary>
        /// 特殊疾病报销
        /// </summary>
        public void IdentificationSpecialReimbursement()
        {
        }
        /// <summary>
        /// 特殊疾病报销取消
        /// </summary>
        public void IdentificationSpecialCancel()
        {
        }
        /// <summary>
        /// 特殊疾病报销取消查询
        /// </summary>
        public void IdentificationSpecialReimbursementQuery()
        { 
        }
        /// <summary>
        /// 特殊疾病报销汇总
        /// </summary>
        public void IdentificationSpecialReimbursementAll()
        {
        }
        /// <summary>
        /// 特殊疾病报销汇总取消
        /// </summary>
        public void IdentificationSpecialReimbursementAlllCancel()
        {
        }
        /// <summary>
        /// 特殊疾病下载
        /// </summary>
        public void IdentificationSpecialDownload()
        {
        }

    }
}
