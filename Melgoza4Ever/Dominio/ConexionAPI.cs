/*using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Text;
using Logica;
using RestSharp;
using Newtonsoft.Json;
using RestSharp;*/
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using RestSharp.Authenticators;



namespace Dominio
{
    public static  class ConexionAPI
    {
       
        public static dynamic PostNoToken(string url, string body, string autorizacion = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                RestResponse respo = client.Post(request);

                return respo;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }

        public static dynamic PostToken(string url, string body, string autorizacion = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                if (autorizacion != null)
                {

                }

                RestResponse respo = client.Post(request);

                return respo;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }

        public static dynamic DeleteToken(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Delete(request);

                return response;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string GetNoToken(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Execute(request);

                return response.Content;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string GetNoTokenWithBody(string url, string body)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                return response.Content;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string PutNoToken(string url, string body)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                RestResponse respo = client.Put(request);

                return respo.Content;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }


    }

  
}
