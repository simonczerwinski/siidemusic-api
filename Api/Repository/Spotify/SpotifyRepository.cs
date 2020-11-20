using Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Spotify
{
    public class SpotifyRepository : ISpotifyRepository
    {
        private readonly string _connectionString;

        public SpotifyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<SpotifyAccessTokenWrapper> GetToken()
        {
            Console.WriteLine("Getting Token");
            var response = "0";
            string clientId = "#";
            string clientSecret = "#";
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);

            using (var client = new HttpClient())
            {
                try 
                { 
                //Define Headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

                //Prepare Request Body
                List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

                //Request Token
                var request = await client.PostAsync(_connectionString + "/token", requestBody);
                response = await request.Content.ReadAsStringAsync();
         
                }
                catch (Exception ex)
                {
                    Error_Add("get_Album", ex);
                }

            }
            return JsonConvert.DeserializeObject<SpotifyAccessTokenWrapper>(response);
        }


        private void Error_Add(string v, Exception ex)
        {
            throw new NotImplementedException();
        }

        SpotifyAccessTokenWrapper ISpotifyRepository.GetToken()
        {
            throw new NotImplementedException();
        }
        //public SpotifyAccessToken GetAuth()
        //{
        //    SpotifyAccessToken auth = new SpotifyAccessToken();
        //    //SpotifyToken token = new SpotifyToken();
        //    string url5 = _connectionString;
        //    auth.clientId = "your_client_id";
        //    auth.clientSecret = "your_client_secret";

        //    //request to get the access token
        //    var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", auth.clientId, auth.clientSecret)));

        //    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);

        //    webRequest.Method = "POST";
        //    webRequest.ContentType = "application/x-www-form-urlencoded";
        //    webRequest.Accept = "application/json";
        //    webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);

        //    var request = ("grant_type=client_credentials");
        //    byte[] req_bytes = Encoding.ASCII.GetBytes(request);
        //    webRequest.ContentLength = req_bytes.Length;

        //    Stream strm = webRequest.GetRequestStream();
        //    strm.Write(req_bytes, 0, req_bytes.Length);
        //    strm.Close();

        //    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
        //    String json = "";
        //    using (Stream respStr = resp.GetResponseStream())
        //    {
        //        using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
        //        {
        //            //should get back a string i can then turn to json and parse for accesstoken
        //            json = rdr.ReadToEnd();
        //            rdr.Close();
        //        }
        //        return json;
        //    }
        //    return auth.accessToken; 
        //}
    }
  
}
