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
using System.Runtime.Serialization;
using System.Web;

namespace Halo5_Stats.Models
{
    [DataContract]
    public class Halo5Stats
    {
        [DataMember(Name = "gamertag")]
        public string Gamertag { get; set; }

        [DataMember(Name = "kd")]
        public double KillDeathRatio { get; set; }

        [DataMember(Name = "kills")]
        public double Kills { get; set; }

        [DataMember(Name = "deaths")]
        public double Deaths { get; set; }

        [DataMember(Name = "matches_played")]
        public double MatchesPlayed { get; set; }

        [DataMember(Name = "wins")]
        public double Wins { get; set; }

        [DataMember(Name = "profile_emblem_uri")]
        public string EmblemURI { get; set; }

    }
}