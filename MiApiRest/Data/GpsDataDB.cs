using MiApiRest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MiApiRest.Data
{
    public class GpsDataDB
    {
        public static int gpsDataAdd(GpsData values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@dateEvent",values.dateEvent);
            parameters[1] = new SqlParameter("@latitude", values.latitude);
            parameters[2] = new SqlParameter("@longitude",values.longitude);
            parameters[3] = new SqlParameter("@battery", values.battery);
            parameters[4] = new SqlParameter("@source", values.source);
            parameters[5] = new SqlParameter("@type", values.type);                                          

            answer = Data.DataBaseConnection.ExecuteQuery("GPS_DATA_A", parameters);

            return answer;
        }



        public static int gpsDataUpdate(GpsData values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[7];
            
            parameters[0] = new SqlParameter("@id", values.id);
            parameters[1] = new SqlParameter("@dateEvent", values.dateEvent);
            parameters[2] = new SqlParameter("@latitude", values.latitude);
            parameters[3] = new SqlParameter("@longitude", values.longitude);
            parameters[4] = new SqlParameter("@battery", values.battery);
            parameters[5] = new SqlParameter("@source", values.source);
            parameters[6] = new SqlParameter("@type", values.type);

            answer = Data.DataBaseConnection.ExecuteQuery("GPS_DATA_U", parameters);

            return answer;
        }


        public static int gpsDataDelete(int id)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);    

            answer = Data.DataBaseConnection.ExecuteQuery("GPS_DATA_D", parameters);

            return answer;
        }

        public static DataSet gpsDataGetAll()
        {
            DataSet answer = null;
            SqlParameter[] parameters = new SqlParameter[0];
            answer = Data.DataBaseConnection.ExecuteQueryDataSet("GPS_DATA_GA", parameters);

            return answer;
        }


        public static DataSet gpsDataGetOne(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id",id);

            return  Data.DataBaseConnection.ExecuteQueryDataSet("GPS_DATA_GO", parameters);
        }


    }
}