using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperBot {
    /// <summary>
    /// Static class containing Trigger for the bot to respond to a player.
    /// </summary>
    public static class Triggers {

        public static bool AggrevateOutput ( string rawMessage, String[][] ArrayContainer ) {
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
