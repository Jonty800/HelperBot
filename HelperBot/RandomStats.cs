//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperBot {
    /// <summary>
    /// An enumerable containing Random Fact types. 
    /// The idea is to use Math.Random() to pick one out of this list
    /// </summary>
    public enum RandomStats : byte {
        MostPromoted = 0,
        MostBuilt = 1,
        MostKicked = 2,
        MostTimesGotKicked = 3,
        MostBanned = 4,
        MostHours = 5,
        MostMessagesSent = 6,
        MostBlocksDrawn = 7,
        CurrentTime = 8,
        FirstPersonKicked = 9,
        FirstPersonBanned = 10,
        //more soon
    }
}
