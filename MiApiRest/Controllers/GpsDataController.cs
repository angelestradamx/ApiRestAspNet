using MiApiRest.Data;
using MiApiRest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiApiRest.Controllers
{
    public class GpsDataController : ApiController
    {
        // GET: api/GpsData
        public HttpResponseMessage Get()
        {
            HttpResponseMessage answer = null;
            Response response = new Response();

            try
            {
                using (DataSet data = GpsDataDB.gpsDataGetAll())
                {

                    if (data != null)
                    {
                        response.code = 1;
                        response.message = "Ok";

                        if (data.Tables[0].Rows.Count > 0)
                        {
                           GpsData[] list =new GpsData[data.Tables[0].Rows.Count];

                            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                            {
                                GpsData obj = new GpsData();

                                obj.id = Convert.ToInt32(data.Tables[0].Rows[i][0]);
                                obj.dateSystem = Convert.ToString(data.Tables[0].Rows[i][1]);
                                obj.dateEvent = Convert.ToString(data.Tables[0].Rows[i][2]);
                                obj.latitude = Convert.ToSingle(data.Tables[0].Rows[i][3]);
                                obj.longitude = Convert.ToSingle(data.Tables[0].Rows[i][4]);

                                obj.battery = Convert.ToInt32(data.Tables[0].Rows[i][5]);
                                obj.source = Convert.ToInt32(data.Tables[0].Rows[i][6]);
                                obj.type = Convert.ToInt32(data.Tables[0].Rows[i][7]);

                                list[i] = obj;

                            }

                            response.values = list;
                        }

                        answer = Request.CreateResponse(response);
                    }
                    else
                    {
                        response.code = -1;
                        response.message = "ups!! algo salió mal°°";
                        answer = Request.CreateResponse(response);

                    }
                }

            }
            catch (Exception ex) {
                response.code = -1;
                response.message = ex.ToString();
                answer = Request.CreateResponse(response);
            }

            return answer;
        }

        // GET: api/GpsData/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage answer = null;
            Response response = new Response();

            try
            {
                using (DataSet data = GpsDataDB.gpsDataGetOne(id))
                {

                    if (data != null)
                    {
                        response.code = 1;
                        response.message = "Ok";

                        if (data.Tables[0].Rows.Count > 0)
                        {
                            GpsData[] list = new GpsData[data.Tables[0].Rows.Count];                                             
                            GpsData obj = new GpsData();

                                obj.id = Convert.ToInt32(data.Tables[0].Rows[0][0]);
                                obj.dateSystem = Convert.ToString(data.Tables[0].Rows[0][1]);
                                obj.dateEvent = Convert.ToString(data.Tables[0].Rows[0][2]);
                                obj.latitude = Convert.ToSingle(data.Tables[0].Rows[0][3]);
                                obj.longitude = Convert.ToSingle(data.Tables[0].Rows[0][4]);

                                obj.battery = Convert.ToInt32(data.Tables[0].Rows[0][5]);
                                obj.source = Convert.ToInt32(data.Tables[0].Rows[0][6]);
                                obj.type = Convert.ToInt32(data.Tables[0].Rows[0][7]);

                            list[0] = obj;
                            response.values = list;

                        }

                        answer = Request.CreateResponse(response);
                    }
                    else
                    {
                        response.code = -1;
                        response.message = "ups!! algo salió mal°°";
                        answer = Request.CreateResponse(response);

                    }
                }

            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.ToString();
                answer = Request.CreateResponse(response);
            }

            return answer;
        }

        // POST: api/GpsData
        public HttpResponseMessage Post([FromBody]GpsData values)
        {
            HttpResponseMessage answer = null;
            Response response = new Response();

            try
            {
                int index = GpsDataDB.gpsDataAdd(values);

                if (index > 0)
                {
                    response.code = 1;
                    response.message = "Guardado";
                }
                else
                {
                    response.code = 0;
                    response.message = "NO Guardado";

                }

                answer = Request.CreateResponse(response);


            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.ToString();
                answer = Request.CreateResponse(response);
            }

            return answer;
        }

        // PUT: api/GpsData/
        public HttpResponseMessage Put([FromBody]GpsData values)
        {
            HttpResponseMessage answer = null;
            Response response = new Response();

            try
            {
                int rowCount = GpsDataDB.gpsDataUpdate(values);

                if (rowCount > 0)
                {
                    response.code = 1;
                    response.message = "Actualizado";
                }
                else
                {
                    response.code = 0;
                    response.message = "NO Actualizado";

                }

                answer = Request.CreateResponse(response);


            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.ToString();
                answer = Request.CreateResponse(response);
            }

            return answer;
        }

        // DELETE: api/GpsData/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage answer = null;
            Response response = new Response();

            try
            {
                int rowCount = GpsDataDB.gpsDataDelete(id);

                if (rowCount > 0)
                {
                    response.code = 1;
                    response.message = "Eliminado";
                }
                else
                {
                    response.code = 0;
                    response.message = "NO eliminado";

                }

                answer = Request.CreateResponse(response);


            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.ToString();
                answer = Request.CreateResponse(response);
            }

            return answer;

        }
    }
}
