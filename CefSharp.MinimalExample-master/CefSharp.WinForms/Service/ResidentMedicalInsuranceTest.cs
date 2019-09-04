using BenDing.Model;
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
using Newtonsoft.Json;
using BenDing.Model.Params.Basiclevel.Param;

namespace BenDing.Service
{
    public class ResidentMedicalInsuranceTest
    {
        private ResidentMedicalInsurance Resident = new ResidentMedicalInsurance();
        public void GetUserInfo()
        {
            //获取社保卡信息
            var hisbase = new HisBaseParam()
            {
                YbOrgCode = "123",
                OrgID = Guid.NewGuid(),
                BID = Guid.Empty,
                EmpID = Guid.Parse("A2A4866484DC40F0A10FB7482603AABD"),
                BsCode = "003",
                TransKey = Guid.NewGuid(),
            };

            //读取社保卡
            var Param = new UserInfoParam
            {
                PI_CRBZ = "1",
                PI_SFBZ = "513701199002124815"
            };
            //var data= Resident.GetUserInfo(Param);
            //日志
            Logs.LogWrite(new LogParam()
            {
                //Msg = data.Po_MSG,
                Msg = "123",
                OperatorCode = hisbase.EmpID.ToString(),
                Name = "橙子",
                Params = Logs.ToJson(Param),
                ResultData = "123" //Logs.ToJson(data)
            });
            // CXJB001 存入基层
            //var result = HttpHelp.HttpPost(Logs.ToJson(new SaveXmlDataServiceParam()
            //{
            //    YbOrgCode = hisbase.YbOrgCode,
            //    OrgID = hisbase.OrgID,
            //    BID = hisbase.BID,
            //    EmpID = hisbase.EmpID,
            //    BsCode = hisbase.BsCode,
            //    TransKey = hisbase.TransKey,
            //    Participation = Logs.ToJson(Param),
            //    ResultData = Logs.ToJson("123"),
            //    BusinessNumber = "CXJB001",

            //}), "SaveXmlData");

        }

        public ApiJsonResultData HospitalizationRegister(QueryInpatientInfoBasicParam param, HisBaseParam baseParam)
        {  // 1.查询中间库当前病人是否入院
           // 1.1.1如果入院直接返回查询结果
           // 1.1.2如果住院病人无数据则对当前病人进行基础入院信息下载(GetInpatientInfo),再进行查询并返回结果
           // 1.2 判断医保信息回写至基层系统CXJB002数据是否存在入院数据
           // 1.2.1 如果已有入院登记记录(则返回已有入院记录)
           // 1.2.2 居民医保进行入院办理(HospitalizationRegister)   
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
                    
                    var saveMedicalInsuranceDataAllQuery = new MedicalInsuranceDataAllBasiclevelParam()
                    {
                        OrgCode = baseParam.YbOrgCode,
                        BusinessId = result.业务ID,
                        DataId = result.住院号,
                        DataType = "CXJB002"
                    };
                    // 1.2
                    var SaveDataAllQueryData = HttpHelp.HttpPost(Logs.ToJson(saveMedicalInsuranceDataAllQuery),
                        "SaveDataAllQuery",
                        new MedicalInsuranceDataAllBasiclevelDto());
                    if (SaveDataAllQueryData != null &&
                        !string.IsNullOrWhiteSpace(SaveDataAllQueryData.DataAllId)) //判断是否存在
                    {

                    }
                    else
                    {
                        new Exception("IdCard:" + param.IdCard + "该病人未在基层系统中住院，请检查该病人是否离院!!!");

                    }




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

    }
}
