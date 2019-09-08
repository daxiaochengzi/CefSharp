﻿using BenDing.Model;
using BenDing.Model.Dto;
using BenDing.Model.Params;
using BenDing.Model.Params.Service;
using BenDing.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Model.Params.Basiclevel;
using BenDing.Model.Params.Basiclevel.Dto;
using Newtonsoft.Json;
using BenDing.Model.Params.Basiclevel.Param;
using BenDing.Model.Params.Web;

namespace BenDing.Service
{
    public class ResidentMedicalInsuranceTest
    {
        private ResidentMedicalInsurance Resident = new ResidentMedicalInsurance();
        public ApiJsonResultData GetUserInfo()
        {
            var resultData = new ApiJsonResultData();
            //获取社保卡信息
            var hisBase = new HisBaseParam() 
            {
                YbOrgCode = "003",
                OrgID = Guid.NewGuid().ToString(),
                BID = Guid.NewGuid().ToString(),
                EmpID = "A2A4866484DC40F0A10FB7482603AABD",
                BsCode = "003",
                TransKey = Guid.NewGuid().ToString(),
            };
            //读取社保卡
            var Param = new UserInfoParam
            {
                PI_CRBZ = "1",
                PI_SFBZ = "513701199002124815"
            };
            try
            {
                var data = Resident.GetUserInfo(Param);
                if (data.PO_FHZ == "1")
                {
                    //查看当前病人是否有医保信息
                    var residentInfoParam = new ResidentInfoBasiclevelParam()
                    {
                        BusinessId = hisBase.BID,
                        IdCard = data.PO_SFZH,
                        OrgCode = hisBase.OrgID
                    };
                    var result = HttpHelp.HttpPost(Logs.ToJson(residentInfoParam), "QueryMedicalInsuranceResidentInfo",
                        new MedicalInsuranceResidentInfoBasiclevelDto ());
                    if (result == null)
                    {//保存医保病人信息
                        var saveResidentInfoParam = new SaveMedicalInsuranceResidentInfoBasiclevelParam()
                        {  YbOrgCode= hisBase.YbOrgCode,
                            BID = hisBase.YbOrgCode,
                            BsCode = hisBase.BsCode,
                            TransKey= hisBase.TransKey,
                            EmpID= hisBase.EmpID,
                            OrgID= hisBase.OrgID,
                            BusinessId = hisBase.BID,
                            ContentJson = Logs.ToJson(data),
                            DataAllId = Guid.NewGuid().ToString("N"),
                            DataId = hisBase.BID,
                            IdCard= data.PO_SFZH,
                            DataType = hisBase.BsCode
                        };
                        var resultSaveData = HttpHelp.HttpPost(Logs.ToJson(residentInfoParam), "SaveMedicalInsuranceResidentInfo",
                            new ApiJsonResultData());
                    }
                    //CXJB001 存入基层
                    var saveXmlParam = new SaveXmlDataServiceParam()
                    {
                        YbOrgCode = hisBase.YbOrgCode,
                        OrgID = hisBase.OrgID,
                        BID = hisBase.BID,
                        EmpID = hisBase.EmpID,
                        BsCode = hisBase.BsCode,
                        TransKey = hisBase.TransKey,
                        Participation = Logs.ToJson(Param),
                        ResultData = Logs.ToJson(data),
                        BusinessNumber = "CXJB001",

                    };
                    var resultXml = HttpHelp.HttpPost(Logs.ToJson(saveXmlParam), 
                        "SaveXmlData",new ApiJsonResultData());
                }
                //日志
                Logs.LogWrite(new LogParam()
                {
                    OperatorCode = hisBase.EmpID.ToString(),
                    Params = Logs.ToJson(Param),
                    ResultData = Logs.ToJson(data) //Logs.ToJson(data)
                });
            }
            catch (Exception e)
            {
                resultData.Success = false;
                resultData.Message = e.Message;
                Logs.LogWrite(new LogParam()
                {
                    Msg = e.Message,
                    OperatorCode = hisBase.EmpID.ToString(),
                });  
            }
            return resultData;
        }
        public ApiJsonResultData HospitalizationRegister(QueryInpatientInfoBasicParam param, HisBaseParam baseParam)
        {  // 1.查询中间库当前病人是否入院
           // 1.1.1如果入院直接返回查询结果
           // 1.1.2如果住院病人无数据则对当前病人进行基础入院信息下载(GetInpatientInfo),再进行查询并返回结果
           // 1.2 判断医保信息回写至基层系统CXJB002数据是否存在入院数据
           // 1.2.1 如果已有入院登记记录(则返回已有入院记录)
           // 1.2.2 居民医保进行入院办理(HospitalizationRegister)  
           // 1.2.3 更新医保人员信息   
           // 1.2.4 医保信息回写至基层系统CXJB002
           //-------------------------------

            var resultData = new ApiJsonResultData();

            try
            {
                //1.    1.1.1    1.1.2
                var result = HttpHelp.HttpPost(Logs.ToJson(param), "QueryInpatientInfo",
                    new QueryInpatientInfoBasicLevelDto());

                if (result != null && !string.IsNullOrWhiteSpace(result.Id)) //判断是否存在
                {
                    var residentInfoParam = new ResidentInfoBasiclevelParam()
                    {
                        BusinessId = baseParam.BID,
                        IdCard = result.身份证号,
                        OrgCode = baseParam.OrgID
                    };
                    // 1.2
                    var saveDataAllQueryData = HttpHelp.HttpPost(Logs.ToJson(residentInfoParam),
                        "QueryMedicalInsuranceResidentInfo",
                        new MedicalInsuranceResidentInfoBasiclevelDto());
                    if (saveDataAllQueryData != null &&
                        !string.IsNullOrWhiteSpace(saveDataAllQueryData.DataAllId)) //判断是否存在
                    {   //获取社保卡信息
                        if (saveDataAllQueryData.DataType == "003")
                        {//医保办理入院
                         

                        }
                        else
                        {
                            throw new Exception("BusinessId:" + saveDataAllQueryData.BusinessId + "DataType" +
                                                saveDataAllQueryData.DataType + "病人状态不正确");
                        }
                    }
                }
                else
                {
                    throw new Exception("IdCard:" + param.IdCard + "该病人未在基层系统中住院，请检查该病人是否离院!!!");

                }
            }
            catch (Exception e)
            {
                resultData.Success = false;
                resultData.Message = e.Message;
                Logs.LogWrite(new LogParam()
                {
                    //Msg = data.Po_MSG,
                    Msg = e.Message,
                    OperatorCode = baseParam.EmpID.ToString(),

                });
            }

            return resultData;
        }
        /// <summary>
        /// 处方上传
        /// </summary>
        /// <returns></returns>
        public ApiJsonResultData PrescriptionUpload(PrescriptionUploadWebParam param, HisBaseParam baseParam)
        {   //选择性上次
            if (param.BusinessIdDetailList != null && param.BusinessIdDetailList.Any())
            {
            }

            return new ApiJsonResultData();
        }
    }
}
