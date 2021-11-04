using RestSharp;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;
using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            getEmployeeData();
        }
        public static void getEmployeeData()
        {
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/");
            var request = new RestRequest("employees");
            var response = client.Execute(request);
            
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Root result = JsonConvert.DeserializeObject<Root>(rawResponse);
                Console.WriteLine("{0}", rawResponse);
            }   
         
        }
        
    }
    public class Datum
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public List<Datum> data { get; set; }
    }

}
