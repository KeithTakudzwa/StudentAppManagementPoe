using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace StudentAppManagementPoe.Models
{
    public class RecordingHours
    {
        public void recordingHours(string ModuleCode, string ModuleName, string ModuleCredit, string ClassHoursPerWeek, string StartDate)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=E50\SQLEXPRESS;
                                Initial Catalog=StudentInfo;Integrated Security=True"); 
            SqlCommand cmd = new SqlCommand(@"INSERT INTO SelfStudy 
                                               ([Module_Code]
                                               ,[Module_Name]
                                               ,[Module_Credit]
                                               ,[Class_Hours_Per_Week]
                                               ,[StartDate]
                                               )
                                                VALUES 
                                                ('" + ModuleCode + "', '" + ModuleName + "', '" + ModuleCredit + "', '" + ClassHoursPerWeek + "', " +
                                               "'" + StartDate + "')", conn);
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
        }
    }
}