using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BenDing.Model;
using BenDing.Model.Dto;
using BenDing.Model.Params;
using BenDing.Model.Params.Basiclevel;
using BenDing.Service;
using BenDing.Xml;

namespace BenDing
{
    public partial class Form1 : Form
    {
        private ResidentMedicalInsuranceTest ResidentTest = new ResidentMedicalInsuranceTest();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new UserInfoParam();

            //XmlHelp.DeSerializerModel(user);

            //var residentMedical = new ResidentMedicalInsurance();
            //residentMedical.GetUserInfo(user);

            //var param = new IdentificationSpecialSettlementParam()
            // {   PI_SFBZ ="1231223",
            //     PI_FYMX=
            //          new List<IdentificationSpecialSettlementPI_FYMXParam>()
            //         { new IdentificationSpecialSettlementPI_FYMXParam()
            //         {
            //             BKE019 = "123",
            //             AAE013 = "123222",
            //             AKA074 = "122222"
            //         }} 
            //};
            //var data = XmlHelp.SaveXml(param);
            //Logs.LogWrite(new LogParam(){Msg = "123",Name = "123",OperatorCode = "3444",Params = "dddd"});
            // XmlHelp.IdentificationSpecialQueryDeSerializerModel(new IdentificationSpecialQueryDto());
            //var ddd=   HttpHelp.CreateGetHttpResponse("http://192.168.101.105:50839/Test/GetInpatientInfo");
            //string url = "http://192.168.101.105:50839/Test/GetInpatientInfo";
            //var ddd=   HttpHelp.HttpGet(url);





            // Resident.GetUserInfo();
            var hisbase = new HisBaseParam()
            {
                YbOrgCode = "123",
                OrgID = Guid.NewGuid(),
                BID = Guid.Empty,
                EmpID = Guid.Parse("A2A4866484DC40F0A10FB7482603AABD"),
                BsCode = "003",
                TransKey = Guid.NewGuid(),
            };
            ResidentTest.HospitalizationRegister(new QueryInpatientInfoBasicParam()
            {
                IdCard = "510821198604156818",InstitutionalNumber = "51072600000000000000000513435964"
            }, hisbase);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
