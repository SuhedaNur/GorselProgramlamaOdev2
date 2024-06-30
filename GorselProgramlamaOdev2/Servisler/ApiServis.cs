using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using GorselProgramlamaOdev2.Models;

namespace GorselProgramlamaOdev2.Servisler
{
    public class ApiServisi
    {
        private readonly HttpClient _httpClient;

        public ApiServisi()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Kur> KurBilgileriniGetirAsync()
        {
            var url = "https://api.genelpara.com/embed/altin.json";
            return await _httpClient.GetFromJsonAsync<Kur>(url);
        }
    }
}
