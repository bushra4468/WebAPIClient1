using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;



namespace WebAPIClient
{
    class Car
    {    
        [JsonProperty("Mfr_CommonName")]
        public string? commonname {get; set; }  

        [JsonProperty("Name")]
        public string? name {get; set; }

         [JsonProperty("Mfr_ID")]
        public int manufacture {get; set; }


        
    }
    
class Program {
   
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

        var car = JsonConvert.DeserializeObject<Car>(resultRead);

        Console.WriteLine("_______");
        Console.WriteLine("CAR name: "+ car.commonname);
        Console.Write("Car ID: "+ car.name);
        Console.Write("Car Brand: "+ car.manufacture);
        Console.WriteLine("\n.....");
    }
    catch (Exception)
    {
        Console.WriteLine("ERROR. Please enter a valid car name");
    }

    }
  }
}
}
