using Api.Models;
using Api.Models.Album;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Album
{

    public class AlbumRepository : IAlbumRepository
    {

        private readonly string _connectionString;

        public AlbumRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AlbumWrapper GetAlbum(string trackId)
        {
            SpotifyAccessToken token = GetToken().Result;

            AlbumWrapper mData = new AlbumWrapper();

            var getSpotifyTrack = _connectionString + trackId + token.token_type + token.access_token;

            try
            {
                var jsonObj = new WebClient().DownloadString(getSpotifyTrack);
            

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                mData = JsonConvert.DeserializeObject<AlbumWrapper>(jsonObj, settings);



            }
            catch (Exception ex)
            {
                Error_Add("get_Album", ex);
            }


            return mData;
        }
        static async Task<SpotifyAccessToken> GetToken()
        {
            Console.WriteLine("Getting Token");
            string clientId = "1a67eb3680d249e080ba6acbc86b9584";
            string clientSecret = "a48ee165f1ce4fa19ae28a4d114db58b";
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);

            using (var client = new HttpClient())
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
                var request = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
                var response = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SpotifyAccessToken>(response);
            }
        }

        private void Error_Add(string v, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
