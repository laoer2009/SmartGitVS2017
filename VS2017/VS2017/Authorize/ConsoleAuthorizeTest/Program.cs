using System;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;
using IdentityServer4.Models;

namespace ConsoleAuthorizeTest
{
    /// <summary>
    /// 向http://localhost:5000申请token  访问http://localhost:5001/api/values接口
    /// </summary>
    class Program
    {
        static  void     Main(string[] args)
        {
            var disco =  DiscoveryClient.GetAsync("http://localhost:5000").Result;
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }

            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            TokenResponse tokenResponse = tokenClient.RequestClientCredentialsAsync("api").Result;
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }
            else
            {
                Console.WriteLine(tokenResponse.Json);
            }

            var httpClient = new HttpClient();
            httpClient.SetBearerToken(tokenResponse.AccessToken);

            var response = httpClient.GetAsync("http://localhost:5001/api/values").Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
      
            Console.ReadKey();
        }
    }
}
