using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace LoraInternOnlin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult dustChart()
        {
            var tuple = ConnectSQL();
            var hankrecords = tuple.Item1;
            var lorarecords = tuple.Item2;

            var dusttimelist = hankrecords.Select(i => i.Time).ToArray();
            var dustvaluelist = hankrecords.Select(i => i.Dust).ToArray();

            var dusttimelist1 = lorarecords.Select(i => i.Time).ToArray();
            var dustvaluelist1 = lorarecords.Select(i => i.Dust).ToArray();

            var dustchart = new Chart(width: 1000, height: 300)
                .AddLegend("Lora Clients")
                .AddSeries(
                name: "Hank",
                chartType: "line",
                xValue: dusttimelist,
                yValues: dustvaluelist)
                .AddSeries(
                name: "Lora",
                chartType: "line",
                xValue: dusttimelist1,
                yValues: dustvaluelist1)
                .Write("png");

            return null;
        }

        public ActionResult uvChart()
        {
            var tuple = ConnectSQL();
            var hankrecords = tuple.Item1;
            var lorarecords = tuple.Item2;

            var uvtimelist = hankrecords.Select(i => i.Time).ToArray();
            var uvvaluelist = hankrecords.Select(i => i.UV).ToArray();

            var uvtimelist1 = lorarecords.Select(i => i.Time).ToArray();
            var uvvaluelist1 = lorarecords.Select(i => i.UV).ToArray();

            var uvchart = new Chart(width: 1000, height: 300)
                .AddLegend("Lora Clients")
                .AddSeries(
                name:"Hank",
                chartType: "line",
                xValue: uvtimelist,
                yValues: uvvaluelist)
                .AddSeries(
                name:"Lora",
                chartType: "line",
                xValue: uvtimelist1,
                yValues: uvvaluelist1)
                .Write("png");

            return null;
        }

        public ActionResult tempChart()
        {
            var tuple = ConnectSQL();
            var hankrecords = tuple.Item1;
            var lorarecords = tuple.Item2;

            var temptimelist = hankrecords.Select(i => i.Time).ToArray();
            var tempvaluelist = hankrecords.Select(i => i.Temp).ToArray();

            var temptimelist1 = lorarecords.Select(i => i.Time).ToArray();
            var tempvaluelist1 = lorarecords.Select(i => i.Temp).ToArray();

            var tempchart = new Chart(width: 1000, height: 300)
                .AddLegend("Lora Clients")
                .AddSeries(
                name: "Hank",
                chartType: "line",
                xValue: temptimelist,
                yValues: tempvaluelist)
                .AddSeries(
                name: "Lora",
                chartType: "line",
                xValue: temptimelist1,
                yValues: tempvaluelist1)
                .Write("png");

            return null;
        }

        public ActionResult presChart()
        {
            var tuple = ConnectSQL();
            var hankrecords = tuple.Item1;
            var lorarecords = tuple.Item2;

            var prestimelist = hankrecords.Select(i => i.Time).ToArray();
            var presvaluelist = hankrecords.Select(i => i.Pressure).ToArray();

            var prestimelist1 = lorarecords.Select(i => i.Time).ToArray();
            var presvaluelist1 = lorarecords.Select(i => i.Pressure).ToArray();

            var dustchart = new Chart(width: 1000, height: 300)
                .AddLegend("Lora Clients")
                .AddSeries(
                name: "Hank",
                chartType: "line",
                xValue: prestimelist,
                yValues: presvaluelist)
                .AddSeries(
                name: "Lora",
                chartType: "line",
                xValue: prestimelist1,
                yValues: presvaluelist1)
                .Write("png");

            return null;
        }

        public ActionResult humChart()
        {
            var tuple = ConnectSQL();
            var hankrecords = tuple.Item1;
            var lorarecords = tuple.Item2;

            var humtimelist = hankrecords.Select(i => i.Time).ToArray();
            var humvaluelist = hankrecords.Select(i => i.Humidity).ToArray();

            var humtimelist1 = lorarecords.Select(i => i.Time).ToArray();
            var humvaluelist1 = lorarecords.Select(i => i.Humidity).ToArray();

            var dustchart = new Chart(width: 1000, height: 300)
                .AddLegend("Lora Clients")
                .AddSeries(
                name: "Hank",
                chartType: "line",
                xValue: humtimelist,
                yValues: humvaluelist)
                .AddSeries(
                name: "Lora",
                chartType: "line",
                xValue: humtimelist1,
                yValues: humvaluelist1)
                .Write("png");

            return null;
        }

        public ActionResult RSSIChart()
        {
            var tuple = ConnectSQL();
            var hankrecords = tuple.Item1;
            var lorarecords = tuple.Item2;

            var rssitimelist = hankrecords.Select(i => i.Time).ToArray();
            var rssivaluelist = hankrecords.Select(i => i.RSSI).ToArray();

            var rssitimelist1 = lorarecords.Select(i => i.Time).ToArray();
            var rssivaluelist1 = lorarecords.Select(i => i.RSSI).ToArray();

            var presschart = new Chart(width: 1000, height: 300)
                .AddLegend("Lora Clients")
                .AddSeries(
                name: "Hank",
                chartType: "line",  
                xValue: rssitimelist,
                yValues: rssivaluelist)
                .AddSeries(
                name: "Lora",
                chartType: "line",
                xValue: rssitimelist1,
                yValues: rssivaluelist1)
                .Write("png");

            return null;
        }

        public class SensorData
        {
            public DateTime Time
            {
                get;
                set;
            }

            public object Dust
            {
                get;
                set;
            }

            public object UV
            {
                get;
                set;
            }

            public object Temp
            {
                get;
                set;
            }

            public object Pressure
            {
                get;
                set;
            }

            public object Humidity
            {
                get;
                set;
            }

            public object RSSI
            {
                get;
                set;
            }
        }

        public Tuple<List<SensorData>,List<SensorData>> ConnectSQL()
        {
            SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder();

            string retrieve = string.Format("select * from (select Row_Number() over (order by TIMESUBMIT) as RowIndex, * from LORA_TABLE) as Sub Where Sub.RowIndex >= {0} and Sub.RowIndex <= {1};", 0, 1000000);

            //list for client "HANK"
            List<SensorData> hankrecords = new List<SensorData>();

            //list for client "LORA"
            List<SensorData> lorarecords = new List<SensorData>();

            //build conenction string
            sql.DataSource = "lorawan-hank.database.windows.net";
            sql.UserID = "Hank";
            sql.Password = "Lorawan1234";
            sql.InitialCatalog = "LoraWan Database";

            using (SqlConnection sqlConn = new SqlConnection(sql.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(retrieve, sqlConn);
                try
                {
                    sqlConn.Open();
                    sqlCommand.ExecuteNonQuery();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DateTime time = reader.GetDateTime(3);
                            if (reader.GetString(1) == "HANK")
                            {
                                hankrecords.Add(new SensorData()
                                {
                                    Time = time,
                                    Dust = reader.GetValue(4),
                                    UV = reader.GetValue(5),
                                    Temp = reader.GetValue(6),
                                    Pressure = reader.GetValue(7),
                                    Humidity = reader.GetValue(8),
                                    RSSI = reader.GetValue(9)
                                });
                            }
                            if (reader.GetString(1) == "LORA")
                            {
                                lorarecords.Add(new SensorData()
                                {
                                    Time = time,
                                    Dust = reader.GetValue(4),
                                    UV = reader.GetValue(5),
                                    Temp = reader.GetValue(6),
                                    Pressure = reader.GetValue(7),
                                    Humidity = reader.GetValue(8),
                                    RSSI = reader.GetValue(9)
                                });
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                sqlConn.Close();
            }
            return Tuple.Create(hankrecords, lorarecords);
        }
    }
}