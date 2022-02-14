using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

using CustomVision.Models;

namespace CustomVision
{

    public class CustomVisionService : ICustomVision
    {
        private readonly string apiEndpoint;
        private RestClient _client;


        public CustomVisionService(string apiUrl)
        {
            apiEndpoint = apiUrl;
            _client = new RestClient(apiEndpoint);
            _client.UseNewtonsoftJson();
        }

        public async Task<ServiceGeneralResponse<Result>> ProcessImage(byte[] imageData, string projectName = "")
        {
            try
            {
                string requestUrI = !String.IsNullOrEmpty(projectName) ? $"{projectName}/image" : "image";
                var request = new RestRequest(requestUrI, Method.Post);
                request.AddFile("imageData", imageData, "image");

                var response = await _client.ExecuteAsync<Result>(request);
                if (!response.IsSuccessful)
                {
                    throw new ServiceException(response.ErrorMessage, response.ErrorException);
                }

                return new ServiceGeneralResponse<Result>
                {
                    Data = response.Data,
                    Error = "",
                    InnerExceptionError = null
                };


            }
            catch (ServiceException ex)
            {
                Console.WriteLine("Custom Vision Service Exception: " + ex.Message);
                return new ServiceGeneralResponse<Result>
                {
                    Data = null,
                    Error = "ServiceException: " + ex.Message,
                    InnerExceptionError = ex.InnerException.ToString()
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("CustomVision ProcessImage Exception: " + e.Message);
                throw;
            }

        }



    }
}
