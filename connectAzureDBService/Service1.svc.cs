using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace connectAzureDBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection sqlCon = new SqlConnection("Data Source=robertdb.database.windows.net;Initial Catalog=TempLoggerDB;Integrated Security=False;User ID=robert;Password=87PBu4IaqUjZPRQm3XBS;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string logTemperature(float temperature, float humidity)
        {
            try
            {
                sqlCon.Open();
                string strSql = $"insert into dbo.temperatureLog (temperature, humidity, date, reference) values ({temperature}, {humidity}, getdate(), 'roer74')";

                SqlCommand insertLogData = new SqlCommand(strSql);
                insertLogData.ExecuteNonQuery();
            }
            finally
            {
                sqlCon.Close();
            }
            return "";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
