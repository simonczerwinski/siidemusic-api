using Api.Models;
using Api.Models.Music;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class MusicRepository : IMusicRepository
    {

        private readonly string _connectionString;

        public MusicRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MusicModelWrapper GetMusic()
        {
            MusicModelWrapper mData = new MusicModelWrapper();

            try
            {
                var jsonObj = new WebClient().DownloadString(_connectionString);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                mData = JsonConvert.DeserializeObject<MusicModelWrapper>(jsonObj, settings);



            }
            catch (Exception ex)
            {
                Error_Add("get_Music", ex);
            }


            return mData;
        }

        public IList<MusicModelWrapper> SaveMusic()
        {
            IList<MusicModelWrapper> data = new List<MusicModelWrapper>();
            try
            {

            }
            catch
            {

            }
            return data;
        }

        private void Error_Add(string v, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
