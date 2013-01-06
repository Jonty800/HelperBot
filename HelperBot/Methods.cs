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
        #region Chat
        /// <summary>
        /// Send a personal message to a player
        /// </summary>
        /// <param name="player">The player object of the target. Cannot be null</param>
        /// <param name="msg">The message to send to the target, cannot be null or 0 length</param>
        public static void SendPM ( Player player, string msg ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: SendPM Method" );
            }
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
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: SendChat Method" );
            }
            if ( msg == null )
                throw new Exception( "HelperBot: Msg cannot be null" );
            if ( msg.Length < 1 )
                throw new Exception( "HelperBot: Msg cannot be 0-length" );
            msg = Chat.ReplaceEmoteKeywords( msg );
            msg = Color.ReplacePercentCodes( msg );
            Server.Players.Message( "{0}&F: {1}", Values.ClassyName, msg );
        }

        /// <summary>
        /// Send a message in the staff chat channel
        /// </summary>
        /// <param name="msg">The message to send to the staff, cannot be null or 0 length</param>
        public static void SendStaff ( string msg ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: SendStaff Method" );
            }
            if ( msg == null )
                throw new Exception( "HelperBot: Msg cannot be null" );
            if ( msg.Length < 1 )
                throw new Exception( "HelperBot: Msg cannot be 0-length" );
            msg = Chat.ReplaceEmoteKeywords( msg );
            msg = Color.ReplacePercentCodes( msg );
            Server.Players.Can( Permission.ReadStaffChat ).Message( "{0}(staff){1}{2}: {3}",
                Color.PM, Values.ClassyName, Color.PM, msg );
        }
        #endregion

        #region Detection

        /// <summary>
        /// Checks if the player has changed his displayedName to the bots
        /// </summary>
        /// <param name="player">Player in question</param>
        /// <returns>true if the displayednames are the same</returns>
        public static bool IsPlayersDisplayedNameBots ( Player player ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: IsPlayersDisplayedNameBots Method" );
            }
            if ( player == null )
                return false;
            if ( player.Info.DisplayedName == null )
                return false;
            if ( player.Info.DisplayedName == Values.ClassyName )
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if a player is impersonating a bot
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>true if the player is suspected of impersonation</returns>
        public static bool DetectMessageImpersonation ( string Message ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: DetectMessageImpersonation Method" );
            }
            if ( Message == null )
                throw new Exception( "HelperBot: Message cannot be null" );
            Message = Color.StripColors( Message );
            //Say impersonation
            if ( Message.StartsWith( Color.StripColors( Values.ClassyName + ":" ) ) )
                return true;
            //staff impersonation
            if ( Message.StartsWith( Color.StripColors( "(staff)" + Values.ClassyName + ":" ) ) )
                return true;
            //adminchat impersonation
            if ( Message.StartsWith( Color.StripColors( "(admin)" + Values.ClassyName + ":" ) ) )
                return true;
            //me impersonation
            if ( Message.StartsWith( Color.StripColors( "*" + Values.ClassyName ) ) )
                return true;
            //PM impersonation
            if ( Message.StartsWith( Color.StripColors( "@" + Values.ClassyName ) ) )
                return true;
            else
                return false;
        }

        /// <summary>
        /// Does the String contain the bots name?
        /// </summary>
        /// <param name="Message">Message in question</param>
        /// <returns>true if it does</returns>
        public static bool ContainsBotName ( String Message ) {
            if ( Message == null )
                throw new Exception( "HelperBot: Message cannot be null" );
            Message = Message.ToLower();
            return Message.Contains( Settings.Name.ToLower() );
        }

        #endregion

        /// <summary>
        /// Gets a random statistic and returns the string message that the player will recieve
        /// TODO write the return messages
        /// </summary>
        /// <param name="player">The player in question [NotNull]</param>
        /// <returns>A string message containing the statistical information</returns>
        public static string GetRandomStatString ( Player player ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: GetRandomStatString Method" );
            }
            if ( player == null ) throw new Exception( "HelperBot: Player cannot be null" );
            byte Max = 13; //Max enum byte
            int StringID = new Random().Next( 0, Max );
            RandomStat Picked = ( RandomStat )StringID;
            string StartOfMessage = player.ClassyName + "&F, ";
            switch ( Picked ) {
                case RandomStat.CurrentTime:
                    return "";
                case RandomStat.FirstPersonBanned:
                    return "";
                case RandomStat.FirstPersonKicked:
                    return "";
                case RandomStat.MostBanned:
                    return "";
                case RandomStat.MostBlocksDrawn:
                    return "";
                case RandomStat.MostBuilt:
                    return "";
                case RandomStat.MostHours:
                    return "";
                case RandomStat.MostKicked:
                    return "";
                case RandomStat.MostLogins:
                    return "";
                case RandomStat.MostMessagesSent:
                    return "";
                case RandomStat.MostPromoted:
                    return "";
                case RandomStat.MostTimesGotKicked:
                    return "";
                case RandomStat.NewestStaff:
                    return "";
                case RandomStat.OldestStaff:
                    return "";
                default: return null;//shouldn't happen
            }
        }
    }
}
