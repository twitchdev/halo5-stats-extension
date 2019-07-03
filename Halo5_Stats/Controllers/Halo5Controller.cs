/**
 *    Copyright 2019 Amazon.com, Inc. or its affiliates
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Halo5_Stats.Models;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using RestSharp;
using System.Web.Script.Serialization;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using JWT;
using JWT.Builder;
using JWT.Serializers;

namespace Halo5_Stats.Controllers
{
    //EnablingCors
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Halo5Controller : ApiController
    {
        //Your API Token to interact with the Halo API goes here
        private static string API_TOKEN_primary = "YOUR_API_TOKEN";
        private static string API_TOKEN_secondary = "YOUR_SECONDARY_API_TOKEN";
        private static string Extension_ClientId = "YOUR_EXTENSION_CLIENT_ID";
        private static string Extension_Secret = "YOUR_EXTENSION_SECRET";

        // GET: api/Halo5
        [RequireHttps]
        public Halo5Stats Get(string gamertag)
        {
            //Verify JWT to ensure request is coming from Twitch
            var re = Request;
            var headers = re.Headers;
            string token = "";
            if (headers.Contains("x-extension-jwt"))
            {
                token = headers.GetValues("x-extension-jwt").First();
            }

            //Now I have the token, let's verify it
            bool isVerified = false;
            var secret_Converted = Convert.FromBase64String(Extension_Secret);
            try
            {
                var json = new JwtBuilder()
                    .WithSecret(secret_Converted)
                    .MustVerifySignature()
                    .Decode(token);

                //Verified
                isVerified = true;
            }
            catch (SignatureVerificationException d)
            {
                Console.WriteLine("Token has invalid signature");
            }

            //Has the token been verified?
            if (!isVerified)
            {
                //If not, return an error in the stats
                return new Halo5Stats
                {
                    Gamertag = "Error",
                    KillDeathRatio = 0.0,
                    Kills = 0.0,
                    Deaths = 0.0,
                    MatchesPlayed = 0,
                    Wins = 0,
                    EmblemURI = ""
                };
            }

            //Use Halo5 API to fetch stats and profile information for the gamertag provided
            Models.Responses.ArenaServiceRecordResponse myStats = getHalo5Stats(gamertag);
            string myProfileEmblem = getSpartanEmblem(gamertag);
            
            //Set the values to return
            var stats = new Halo5Stats
            {
                Gamertag = myStats.Results[0].Result.PlayerId.Gamertag,
                KillDeathRatio = Math.Round((myStats.Results[0].Result.ArenaStats.TotalKills / myStats.Results[0].Result.ArenaStats.TotalDeaths), 2),
                Kills = myStats.Results[0].Result.ArenaStats.TotalKills,
                Deaths = myStats.Results[0].Result.ArenaStats.TotalDeaths,
                MatchesPlayed = myStats.Results[0].Result.ArenaStats.TotalGamesCompleted,
                Wins = myStats.Results[0].Result.ArenaStats.TotalGamesWon,
                EmblemURI = myProfileEmblem
            };
            
            return stats;
        }

        //Get stats of provided gamertag
        private Models.Responses.ArenaServiceRecordResponse getHalo5Stats(string tag)
        {
            //using RestSharp
            var restClient = new RestClient("https://www.haloapi.com/stats/h5/servicerecords/arena?players=" + tag);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", API_TOKEN_primary);

            //execute request and serialize response into data model
            var response = restClient.Execute(request);
            var stats = new JavaScriptSerializer().Deserialize<Models.Responses.ArenaServiceRecordResponse>(response.Content);

            return stats;
        }


        //Get Spartan Emblem of provided gamertag
        private string getSpartanEmblem(string tag)
        {
            //using RestSharp
            var restClient = new RestClient("https://www.haloapi.com/profile/h5/profiles/" + tag + "/emblem");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", API_TOKEN_primary);

            //Execute request and return the string
            var response = restClient.Execute(request);
            string emblemUri = response.ResponseUri.AbsoluteUri;

            return emblemUri;
        }
    }
}
