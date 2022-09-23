﻿using Newtonsoft.Json;
using PlenBotLogUploader.DPSReport.ExtraJSON;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    internal sealed class DPSReportJSONExtraJSON
    {
        [JsonProperty("eliteInsightsVersion")]
        internal string EliteInsightsVersion { get; set; }

        [JsonProperty("recordedBy")]
        internal string RecordedBy { get; set; }

        [JsonProperty("timeStart")]
        internal DateTime TimeStart { get; set; }

        [JsonProperty("timeEnd")]
        internal DateTime TimeEnd { get; set; }

        [JsonProperty("duration")]
        internal string Duration { get; set; }

        [JsonProperty("triggerID")]
        internal int TriggerID { get; set; }

        [JsonProperty("fightName")]
        internal string FightName { get; set; }

        [JsonProperty("gw2Build")]
        internal int GW2Build { get; set; }

        [JsonProperty("fightIcon")]
        internal string FightIcon { get; set; }

        [JsonProperty("isCM")]
        internal bool IsCM { get; set; }

        [JsonProperty("targets")]
        internal List<Target> Targets { get; set; }

        [JsonProperty("players")]
        internal List<Player> Players { get; set; }

        internal Dictionary<Player, int> PlayerTargetDPS
        {
            get
            {
                var dict = new Dictionary<Player, int>();
                Players.ForEach(player => {
                    var damage = player.DpsTargets
                        .Select(x => x.First().DPS)
                        .Sum();
                    dict.Add(player, damage);
                });
                return dict;
            }
        }
    }
}
