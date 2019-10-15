﻿using Newtonsoft.Json;
using System.Net.Http;

namespace TennisApi.Repositories.Htttp
{
    public static class HttpHelper
    {
        public static T Get<T>(string uri)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(content);
                }

                return default(T);
            }

        }
    }
}
