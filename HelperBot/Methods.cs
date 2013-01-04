//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fCraft;

namespace HelperBot {
    /// <summary>
    /// A collection of static methods used for the bot
    /// </summary>
    class Methods {
        /// <summary>
        /// Send a personal message to a player
        /// </summary>
        /// <param name="player">The player object of the target. Cannot be null</param>
        /// <param name="msg">The message to send to the target, cannot be null or 0 length</param>
        public static void SendPM ( Player player, string msg ) {
            if ( player == null )
                throw new Exception( "HelperBot: Player cannot be null" );
            if ( msg == null )
                throw new Exception( "HelperBot: Msg cannot be null" );
            if ( msg.Length < 1 )
                throw new Exception( "HelperBot: Msg cannot be 0-length" );
            player.Message( "{0}from {1}: {2}", Color.PM, Settings.Name, msg );
        }

        /// <summary>
        /// Send a global server message
        /// </summary>
        /// <param name="msg">The message to send to the server, cannot be null or 0 length</param>
        public static void SendChat ( string msg ) {
            if ( msg == null )
                throw new Exception( "HelperBot: Msg cannot be null" );
            if ( msg.Length < 1 )
                throw new Exception( "HelperBot: Msg cannot be 0-length" );
            msg = Chat.ReplaceEmoteKeywords(msg);
            msg = Color.ReplacePercentCodes(msg);
            Server.Players.Message( "{0}&F: {1}", Constants.ClassyName, msg );
        }

        /// <summary>
        /// Send a message in the staff chat channel
        /// </summary>
        /// <param name="msg">The message to send to the staff, cannot be null or 0 length</param>
        public static void SendStaff ( string msg ) {
            if ( msg == null )
                throw new Exception( "HelperBot: Msg cannot be null" );
            if ( msg.Length < 1 )
                throw new Exception( "HelperBot: Msg cannot be 0-length" );
            msg = Chat.ReplaceEmoteKeywords( msg );
            msg = Color.ReplacePercentCodes( msg );
            Server.Players.Can( Permission.ReadStaffChat ).Message( "{0}(staff){1}{2}: {3}", 
                Color.PM, Constants.ClassyName, Color.PM, msg );
        }
    }
}
