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
using System.Web;

namespace Halo5_Stats.Models.Responses
{

    public class ImpulseStatCounts
    {
        public string Id { get; set; }
        public double Count { get; set; }
    }

    public class ImpulseTimelapse
    {
        public string Id { get; set; }
        public string Timelapse { get; set; }
    }

    public class FlexibleStats
    {
        public List<object> MedalStatCounts { get; set; }
        public List<ImpulseStatCounts> ImpulseStatCounts { get; set; }
        public List<object> MedalTimelapses { get; set; }
        public List<ImpulseTimelapse> ImpulseTimelapses { get; set; }
    }

    public class WeaponId
    {
        public double StockId { get; set; }
        public List<object> Attachments { get; set; }
    }

    public class WeaponWithMostKills
    {
        public WeaponId WeaponId { get; set; }
        public double TotalShotsFired { get; set; }
        public double TotalShotsLanded { get; set; }
        public double TotalHeadshots { get; set; }
        public double TotalKills { get; set; }
        public double TotalDamageDealt { get; set; }
        public string TotalPossessionTime { get; set; }
    }

    public class MedalAward
    {
        public object MedalId { get; set; }
        public double Count { get; set; }
    }

    public class WeaponId2
    {
        public object StockId { get; set; }
        public List<object> Attachments { get; set; }
    }

    public class WeaponStat
    {
        public WeaponId2 WeaponId { get; set; }
        public double TotalShotsFired { get; set; }
        public double TotalShotsLanded { get; set; }
        public double TotalHeadshots { get; set; }
        public double TotalKills { get; set; }
        public double TotalDamageDealt { get; set; }
        public string TotalPossessionTime { get; set; }
    }

    public class Impulse
    {
        public double Id { get; set; }
        public double Count { get; set; }
    }

    public class ArenaGameBaseVariantStat
    {
        public FlexibleStats FlexibleStats { get; set; }
        public string GameBaseVariantId { get; set; }
        public double TotalKills { get; set; }
        public double TotalHeadshots { get; set; }
        public double TotalWeaponDamage { get; set; }
        public double TotalShotsFired { get; set; }
        public double TotalShotsLanded { get; set; }
        public WeaponWithMostKills WeaponWithMostKills { get; set; }
        public double TotalMeleeKills { get; set; }
        public double TotalMeleeDamage { get; set; }
        public double TotalAssassinations { get; set; }
        public double TotalGroundPoundKills { get; set; }
        public double TotalGroundPoundDamage { get; set; }
        public double TotalShoulderBashKills { get; set; }
        public double TotalShoulderBashDamage { get; set; }
        public double TotalGrenadeDamage { get; set; }
        public double TotalPowerWeaponKills { get; set; }
        public double TotalPowerWeaponDamage { get; set; }
        public double TotalPowerWeaponGrabs { get; set; }
        public string TotalPowerWeaponPossessionTime { get; set; }
        public double TotalDeaths { get; set; }
        public double TotalAssists { get; set; }
        public double TotalGamesCompleted { get; set; }
        public double TotalGamesWon { get; set; }
        public double TotalGamesLost { get; set; }
        public double TotalGamesTied { get; set; }
        public string TotalTimePlayed { get; set; }
        public double TotalGrenadeKills { get; set; }
        public List<MedalAward> MedalAwards { get; set; }
        public List<object> DestroyedEnemyVehicles { get; set; }
        public List<object> EnemyKills { get; set; }
        public List<WeaponStat> WeaponStats { get; set; }
        public List<Impulse> Impulses { get; set; }
        public double TotalSpartanKills { get; set; }
        public string FastestMatchWin { get; set; }
    }

    public class TopGameBaseVariant
    {
        public double GameBaseVariantRank { get; set; }
        public double NumberOfMatchesCompleted { get; set; }
        public string GameBaseVariantId { get; set; }
        public double NumberOfMatchesWon { get; set; }
    }

    public class WeaponId3
    {
        public double StockId { get; set; }
        public List<object> Attachments { get; set; }
    }

    public class WeaponWithMostKills2
    {
        public WeaponId3 WeaponId { get; set; }
        public double TotalShotsFired { get; set; }
        public double TotalShotsLanded { get; set; }
        public double TotalHeadshots { get; set; }
        public double TotalKills { get; set; }
        public double TotalDamageDealt { get; set; }
        public string TotalPossessionTime { get; set; }
    }

    public class MedalAward2
    {
        public object MedalId { get; set; }
        public double Count { get; set; }
    }

    public class WeaponId4
    {
        public object StockId { get; set; }
        public List<object> Attachments { get; set; }
    }

    public class WeaponStat2
    {
        public WeaponId4 WeaponId { get; set; }
        public double TotalShotsFired { get; set; }
        public double TotalShotsLanded { get; set; }
        public double TotalHeadshots { get; set; }
        public double TotalKills { get; set; }
        public double TotalDamageDealt { get; set; }
        public string TotalPossessionTime { get; set; }
    }

    public class Impulse2
    {
        public double Id { get; set; }
        public double Count { get; set; }
    }

    public class ArenaStats
    {
        public List<object> ArenaPlaylistStats { get; set; }
        public object HighestCsrAttained { get; set; }
        public List<ArenaGameBaseVariantStat> ArenaGameBaseVariantStats { get; set; }
        public List<TopGameBaseVariant> TopGameBaseVariants { get; set; }
        public object HighestCsrPlaylistId { get; set; }
        public string HighestCsrSeasonId { get; set; }
        public string ArenaPlaylistStatsSeasonId { get; set; }
        public double TotalKills { get; set; }
        public double TotalHeadshots { get; set; }
        public double TotalWeaponDamage { get; set; }
        public double TotalShotsFired { get; set; }
        public double TotalShotsLanded { get; set; }
        public WeaponWithMostKills2 WeaponWithMostKills { get; set; }
        public double TotalMeleeKills { get; set; }
        public double TotalMeleeDamage { get; set; }
        public double TotalAssassinations { get; set; }
        public double TotalGroundPoundKills { get; set; }
        public double TotalGroundPoundDamage { get; set; }
        public double TotalShoulderBashKills { get; set; }
        public double TotalShoulderBashDamage { get; set; }
        public double TotalGrenadeDamage { get; set; }
        public double TotalPowerWeaponKills { get; set; }
        public double TotalPowerWeaponDamage { get; set; }
        public double TotalPowerWeaponGrabs { get; set; }
        public string TotalPowerWeaponPossessionTime { get; set; }
        public double TotalDeaths { get; set; }
        public double TotalAssists { get; set; }
        public double TotalGamesCompleted { get; set; }
        public double TotalGamesWon { get; set; }
        public double TotalGamesLost { get; set; }
        public double TotalGamesTied { get; set; }
        public string TotalTimePlayed { get; set; }
        public double TotalGrenadeKills { get; set; }
        public List<MedalAward2> MedalAwards { get; set; }
        public List<object> DestroyedEnemyVehicles { get; set; }
        public List<object> EnemyKills { get; set; }
        public List<WeaponStat2> WeaponStats { get; set; }
        public List<Impulse2> Impulses { get; set; }
        public double TotalSpartanKills { get; set; }
        public string FastestMatchWin { get; set; }
    }

    public class PlayerId
    {
        public string Gamertag { get; set; }
        public object Xuid { get; set; }
    }

    public class Result
    {
        public ArenaStats ArenaStats { get; set; }
        public PlayerId PlayerId { get; set; }
        public double SpartanRank { get; set; }
        public double Xp { get; set; }
    }

    public class ResultObj
    {
        public string Id { get; set; }
        public double ResultCode { get; set; }
        public Result Result { get; set; }
    }

    public class Self
    {
        public string AuthorityId { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RetryPolicyId { get; set; }
        public string TopicName { get; set; }
        public double AcknowledgementTypeId { get; set; }
        public bool AuthenticationLifetimeExtensionSupported { get; set; }
    }

    public class Links
    {
        public Self Self { get; set; }
    }

    public class ArenaServiceRecordResponse
    {
        public List<ResultObj> Results { get; set; }
        public Links Links { get; set; }
    }
}