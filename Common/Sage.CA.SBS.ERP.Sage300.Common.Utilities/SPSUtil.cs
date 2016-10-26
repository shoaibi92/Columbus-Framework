using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;

namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities
{
    public class SPSUtil
    {

        public const string SpsUrl = "https://www.sageexchange.com";
        public const string InitialRequestUrl = "/virtualpaymentterminal/frmenvelope.aspx";
        public const string DecryptRequestUrl = "/virtualpaymentterminal/frmopenenvelope.aspx";
        public const string FinalRequestUrl = "/virtualpaymentterminal/frmpayment.aspx";

        /// <summary>
        /// Send xml request and gets back xml response from SPS
        /// </summary>
        /// <param name="requestXml"></param>
        /// <returns></returns>
        public static string SendRequestAndGetResponseNoUI(string requestXml)
        {
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri(SpsUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("request", requestXml) });
                var response =
                    client.PostAsync(InitialRequestUrl, content)
                        .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode())
                        .Result;
                var responseXml = response.Content.ReadAsStringAsync().Result; //

                content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("request", responseXml) });

                response = client.PostAsync(FinalRequestUrl, content).Result;
                return responseXml = response.Content.ReadAsStringAsync().Result;
            }

        }

        /// <summary>
        /// Gets the response xml that should be embedded on the form before forwarding to external SPS url
        /// </summary>
        /// <param name="requestXml"></param>
        public static string SendRequestAndGetEncryptedResponseForUI(string requestXml)
        {
            using (var client = new HttpClient())
            {
                //
                client.BaseAddress = new Uri(SpsUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("request", requestXml) });
                var response =
                    client.PostAsync(InitialRequestUrl, content)
                        .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode())
                        .Result;
                //
                return response.Content.ReadAsStringAsync().Result; //


            }
        }

        /// <summary>
        /// Decrypts the SPS response parameter from Request
        /// </summary>
        /// <param name="encryptedResponseXml"></param>
        /// <returns></returns>
        public static string DecryptSPSResponseForUI(string encryptedResponseXml)
        {
            using (var client = new HttpClient())
            {
                //
                client.BaseAddress = new Uri(SpsUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("request", encryptedResponseXml) });
                var response =
                    client.PostAsync(DecryptRequestUrl, content)
                        .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode())
                        .Result;
                //
                var result = response.Content.ReadAsStringAsync().Result; //

                // parse
                var responseCodes = HttpUtility.ParseQueryString(result);

                if (responseCodes.Count > 1)
                {
                    if (!string.IsNullOrEmpty(responseCodes["status_code"]))
                    {
                        int statusCode;
                        Int32.TryParse(responseCodes["status_code"], out statusCode);
                        //Get Status Code Error Message
                        throw new Exception(GetSPSGatewayErrorCodeMessage(statusCode));
                    }

                    if (!string.IsNullOrEmpty(responseCodes["status_description"]))
                    {
                        // TODO: refactor this to use a custom Exception class
                        throw new Exception(responseCodes["status_description"]); // you can also use: responseCodes["status_code"]
                    }
                }

                return result;

            }
        }

        /// <summary>
        /// Get SPS Gateway Error Code Message
        /// </summary>
        /// <param name="errorCode">ErrorCode/StatusCode/ResponseCode</param>
        /// <returns>Message</returns>
        public static string GetSPSGatewayErrorCodeMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 0:
                    return SPSCommonResx.SpsGatewayErrorCode000000;
                case 900000:
                    return SPSCommonResx.SpsGatewayErrorCode900000;
                case 900001:
                    return SPSCommonResx.SpsGatewayErrorCode900001;
                case 900002:
                    return SPSCommonResx.SpsGatewayErrorCode900002;
                case 900003:
                    return SPSCommonResx.SpsGatewayErrorCode900003;
                case 900004:
                    return SPSCommonResx.SpsGatewayErrorCode900004;
                case 900005:
                    return SPSCommonResx.SpsGatewayErrorCode900005;
                case 900006:
                    return SPSCommonResx.SpsGatewayErrorCode900006;
                case 900007:
                    return SPSCommonResx.SpsGatewayErrorCode900007;
                case 900008:
                    return SPSCommonResx.SpsGatewayErrorCode900008;
                case 900009:
                    return SPSCommonResx.SpsGatewayErrorCode900009;
                case 900010:
                    return SPSCommonResx.SpsGatewayErrorCode900010;
                case 900011:
                    return SPSCommonResx.SpsGatewayErrorCode900011;
                case 900012:
                    return SPSCommonResx.SpsGatewayErrorCode900012;
                case 900013:
                    return SPSCommonResx.SpsGatewayErrorCode900013;
                case 900014:
                    return SPSCommonResx.SpsGatewayErrorCode900014;
                case 900015:
                    return SPSCommonResx.SpsGatewayErrorCode900015;
                case 900016:
                    return SPSCommonResx.SpsGatewayErrorCode900016;
                case 900017:
                    return SPSCommonResx.SpsGatewayErrorCode900017;
                case 900018:
                    return SPSCommonResx.SpsGatewayErrorCode900018;
                case 900019:
                    return SPSCommonResx.SpsGatewayErrorCode900019;
                case 900020:
                    return SPSCommonResx.SpsGatewayErrorCode900020;
                case 900021:
                    return SPSCommonResx.SpsGatewayErrorCode900021;
                case 900022:
                    return SPSCommonResx.SpsGatewayErrorCode900022;
                case 900023:
                    return SPSCommonResx.SpsGatewayErrorCode900023;
                case 900024:
                    return SPSCommonResx.SpsGatewayErrorCode900024;
                case 900025:
                    return SPSCommonResx.SpsGatewayErrorCode900025;
                case 900026:
                    return SPSCommonResx.SpsGatewayErrorCode900026;
                case 900027:
                    return SPSCommonResx.SpsGatewayErrorCode900027;
                case 900028:
                    return SPSCommonResx.SpsGatewayErrorCode900028;
                case 900029:
                    return SPSCommonResx.SpsGatewayErrorCode900029;
                case 900030:
                    return SPSCommonResx.SpsGatewayErrorCode900030;
                case 900031:
                    return SPSCommonResx.SpsGatewayErrorCode900031;
                case 900032:
                    return SPSCommonResx.SpsGatewayErrorCode900032;
                case 900033:
                    return SPSCommonResx.SpsGatewayErrorCode900033;
                case 900034:
                    return SPSCommonResx.SpsGatewayErrorCode900034;
                case 900035:
                    return SPSCommonResx.SpsGatewayErrorCode900035;
                case 900100:
                    return SPSCommonResx.SpsGatewayErrorCode900100;
                case 910000:
                    return SPSCommonResx.SpsGatewayErrorCode910000;
                case 910001:
                    return SPSCommonResx.SpsGatewayErrorCode910001;
                case 910002:
                    return SPSCommonResx.SpsGatewayErrorCode910002;
                case 910003:
                    return SPSCommonResx.SpsGatewayErrorCode910003;
                case 910004:
                    return SPSCommonResx.SpsGatewayErrorCode910004;
                case 910005:
                    return SPSCommonResx.SpsGatewayErrorCode910005;
                case 911911:
                    return SPSCommonResx.SpsGatewayErrorCode911911;
                case 920000:
                    return SPSCommonResx.SpsGatewayErrorCode920000;
                case 920001:
                    return SPSCommonResx.SpsGatewayErrorCode920001;
                case 920002:
                    return SPSCommonResx.SpsGatewayErrorCode920002;
                case 920050:
                    return SPSCommonResx.SpsGatewayErrorCode920050;
                case 7:
                    return SPSCommonResx.SpsProcessTimeout;
                default:
                    return SPSCommonResx.SpsGatewayErrorCodeUNKNOWN;
            }
        }


    }
}
