using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

class Program
{
private static readonly HttpClient client = new HttpClient();


static async Task Main(string[] args)
{
    await ProcessRepositories();
}

private static async Task ProcessRepositories()
{

while(true)
{
    try
    {
        Console.WriteLine("Enter car name. Press Enter without writing a name to quit the program.");
        var carName = Console.ReadLine();
        if (string.IsNullOrEmpty(carName))
        {
            break;
        }
        var result = await client.GetAsync("https://vpic.nhtsa.dot.gov/api/vehicles/getallmanufacturers?format=json" + carName.ToLower());
        var resultRead = await result.Content.ReadAsStringAsync();

        var car = JsonConvert.DeserializeObject<carName>(resultRead);
        Console.WriteLine("_______");
        Console.WriteLine("CAR name"+ car.name);
        Console.WriteLine("\n.....");
    }
    catch (Exception)
    {
        Console.WriteLine("ERROR. Please enter a valid car name");
    }
    
    }
  }
}

namespace WebAPIClient
{
    class car
    {    
        [JsonProperty("Mfr_CommonName")]
        public string commonname {get; set; }

        [JsonProperty("Name")]
        public string name {get; set; }

         [JsonProperty("Mfr_ID")]
        public int manufacture {get; set; }

        [JsonProperty("Country")]
        public string country {get; set; }

        
    }

    public class Type
    {
        [JsonProperty("Name")]
        public string name {get; set; }
    }


    public class Typ1
    {
        [JsonProperty("Mfr_CommonName")]
        public string commonname {get; set; }

    }

    
     private static readonly HttpClient client = new HttpClient();
     
    }
    
