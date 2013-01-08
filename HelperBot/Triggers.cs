//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperBot {
    /// <summary>
    /// Static class containing Trigger for the bot to respond to a player.
    /// </summary>
    public static class Triggers {

        public static bool MatchesNameAndTrigger ( string rawMessage, String[][] ArrayContainer ) {
            if ( rawMessage.ToLower().Contains( Settings.Name.ToLower() ) ) {
                if ( MatchesTrigger( rawMessage, ArrayContainer ) ) {
                    return true;
                }
            }
            return false;
        }

        public static bool MatchesTrigger ( string rawMessage, String[][] ArrayContainer ) {
            rawMessage = fCraft.Color.StripColors( rawMessage );
            rawMessage = rawMessage.ToLower();
            foreach ( String[] Array in ArrayContainer ) {
                if ( Array.All( s => rawMessage.Contains( s ) ) ) {
                    return true;
                }
            }
            return false;
        }
    }
}
