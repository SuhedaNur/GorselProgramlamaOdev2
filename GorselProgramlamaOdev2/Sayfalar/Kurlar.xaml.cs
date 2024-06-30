using Newtonsoft.Json;
using System.Net.Http.Json;

namespace GorselProgramlamaOdev2.Sayfalar;

public partial class Kurlar : ContentPage
{
    public Kurlar()
    {
        InitializeComponent();
        LoadData();
    }
    public async void LoadData()
    {
        HttpClient client = new HttpClient();
        var json = await client.GetStringAsync("https://finans.truncgil.com/today.json");

        var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

        // Update_Date'i ayr� olarak al
        var updateDate = data["Update_Date"].ToString();

        // Kurlar k�sm�n� Dictionary<string, DovizKuru> olarak al
        var kurlarJson = JsonConvert.SerializeObject(data.Where(kv => kv.Key != "Update_Date").ToDictionary(kv => kv.Key, kv => kv.Value));
        var kurlar = JsonConvert.DeserializeObject<Dictionary<string, DovizKuru>>(kurlarJson);

        // BindingContext'i g�ncelle
        var doviz = new Doviz
        {
            Update_Date = updateDate,
            Kurlar = kurlar
        };

        BindingContext = doviz;
    }
}
public class DovizKuru
{
    [JsonProperty("Al��")]
    public string Alis { get; set; }

    [JsonProperty("T�r")]
    public string Tur { get; set; }

    [JsonProperty("Sat��")]
    public string Satis { get; set; }

    [JsonProperty("De�i�im")]
    public string Degisim { get; set; }
}

public class Doviz
{
    public string Update_Date { get; set; }
    public Dictionary<string, DovizKuru> Kurlar { get; set; }
}
