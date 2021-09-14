using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CI.interview.pltosman.Business.Abstract;
using CI.interview.pltosman.Core.Entities.Concrete;
using CI.interview.pltosman.Core.Utilities.Results;
using CI.interview.pltosman.Core.Utilities.Security;
using CI.interview.pltosman.Entities.Concrete;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CI.interview.pltosman.Business.Concrete
{
    public class FixerDetailService:IFixerDetailService
    {
        private readonly ILogger<FixerDetailService> _logger;
        private readonly RestClient _restClient;
        private readonly ApplicationSettings _settings;

        public FixerDetailService(ILogger<FixerDetailService> logger, IOptions<ApplicationSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
            _restClient = new RestClient(_settings.CustomerSettings.ApiBaseUrl);
        }

        public async Task<IDataResult<List<Rate>>> GetFixerDetail(string sdate, string edate, string rateTypes= null)
        {

           // var fixerDetailResponse = new DataResult<FixerDetailResponse>(null, false);
            var ratesResponse = new DataResult<List<Rate>>(null,false);
            var rateData = new List<Rate>();
            if (IsRateTypesCorrectFormat(rateTypes))
            {
                try
                {

                    for (int i = 0; i < 31; i++)
                    {
                        var rates = GetFixerRateByDateAsync(new DateTime(2019,10,1).AddDays(i).ToString("yyyy-MM-dd")).Result;

                        var rateResponse =  Rate.FillList(rates);
                        rateData.AddRange(rateResponse);
                    }

                    ratesResponse = new DataResult<List<Rate>>(rateData, true);
               
                    /*
                    var url = _settings.CustomerSettings.ApiBaseUrl;

                    var client = new RestClient(url);
                    //var request = new RestRequest($"/fluctuation", Method.GET);
                    //  var request = new RestRequest($"/latest", Method.GET);
                    var request = new RestRequest($"/{sdate}", Method.GET);
                    // var request = new RestRequest($"/timeseries", Method.GET);

                    request.AddParameter("access_key", string.Format(_settings.CustomerSettings.ApiCode), ParameterType.QueryString);
                    // request.AddParameter("start_date", string.Format(sdate), ParameterType.QueryString);
                    //request.AddParameter("end_date", string.Format(edate), ParameterType.QueryString); //2012-05-03
                    request.AddHeader("Content-type", "application/json");

                    var cancellationTokenSource = new CancellationTokenSource();

                    var response = await client.ExecuteAsync(request, cancellationTokenSource.Token);


                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);
                        var json = jsonResponse.ToString();
                        var data = JsonConvert.DeserializeObject<FixerDetailResponse>(json);
                        fixerDetailResponse = new DataResult<FixerDetailResponse>(data, true);
                    }
                    */
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }
            else
            {
                ratesResponse= new DataResult<List<Rate>>(null, true, "Rate Types couldn't correct format. Example: \"USD,AUD,CAD,PLN,MXN\" ");
            }

            
            return ratesResponse;
        }

        private bool IsRateTypesCorrectFormat(string rateTypes)
        {
            bool result = false;
            try
            {
                if(!string.IsNullOrEmpty(rateTypes))
                {
                    var rateTypesArray = rateTypes.Split(",");

                    if (rateTypesArray.Length > 0)
                        result = true;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Rate Types couldn't correct format. Example: \"USD,AUD,CAD,PLN,MXN\" ");
              
            }

            return result;
        }


        private async Task<FixerDetailResponse> GetFixerRateByDateAsync(string date, string rateTypes = null)
        {
            var fixerDetailResponse = new FixerDetailResponse();

            try
            {
                var url = _settings.CustomerSettings.ApiBaseUrl;

                var client = new RestClient(url);
                //var request = new RestRequest($"/fluctuation", Method.GET);
                //  var request = new RestRequest($"/latest", Method.GET);
                var request = new RestRequest($"/{date}", Method.GET);
                // var request = new RestRequest($"/timeseries", Method.GET);

                request.AddParameter("access_key", string.Format(_settings.CustomerSettings.ApiCode), ParameterType.QueryString);
                // request.AddParameter("start_date", string.Format(sdate), ParameterType.QueryString);
                //request.AddParameter("end_date", string.Format(edate), ParameterType.QueryString); //2012-05-03
                request.AddHeader("Content-type", "application/json");

                var cancellationTokenSource = new CancellationTokenSource();

                var response = await client.ExecuteAsync(request, cancellationTokenSource.Token);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);
                    var json = jsonResponse.ToString();
                    var data = JsonConvert.DeserializeObject<FixerDetailResponse>(json);
                    fixerDetailResponse = data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return fixerDetailResponse;
        }

    }
}
