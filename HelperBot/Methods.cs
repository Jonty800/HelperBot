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
        /// Send a message without the need of a player name (DO NOT use this for PMs)
        /// </summary>
        public static void SendMessage ( string Message, MessageChannel Channel ) {
            SendMessage( null, Message, Channel );
        }

        /// <summary>
        /// Send a message
        /// </summary>
        public static void SendMessage ( Player player, string Message, MessageChannel Channel ) {
            switch ( Channel ) {
                case MessageChannel.Admin:
                    //TODO
                    break;
                case MessageChannel.Global:
                    SendChat( Message );
                    break;
                case MessageChannel.Me: 
                   //TODO
                    break;
                case MessageChannel.PM:
                    SendPM( player, Message );
                    break;
                case MessageChannel.Staff:
                    SendStaff( Message );
                    break;
            }
        }


        /// <summary>
        /// Send a personal message to a player
        /// </summary>
        /// <param name="player">The player object of the target. Cannot be null</param>
        /// <param name="msg">The message to send to the target, cannot be null or 0 length</param>
        public static void SendPM ( Player player, string msg ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: SendPM Method" );
            }
            if ( player == null ) {
                SendError( player, "HelperBot: Player cannot be null", MessageChannel.PM );
                return;
            }
            if ( msg == null ) {
                SendError( player, "HelperBot: Msg cannot be null", MessageChannel.PM );
                return;
            }
            if ( msg.Length < 1 ) {
                SendError( player, "HelperBot: Msg cannot be 0-length", MessageChannel.PM );
                return;
            }
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
            if ( msg == null ) {
                SendError( "HelperBot: Msg cannot be null", MessageChannel.Global);
                return;
            }
            if ( msg.Length < 1 ) {
                SendError( "HelperBot: Msg cannot be 0-length", MessageChannel.Global );
                return;
            }
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
            if ( msg == null ) {
                SendError( "HelperBot: Msg cannot be null", MessageChannel.Staff );
                return;
            }
            if ( msg.Length < 1 ) {
                SendError( "HelperBot: Msg cannot be 0-length", MessageChannel.Staff );
                return;
            }
            msg = Chat.ReplaceEmoteKeywords( msg );
            msg = Color.ReplacePercentCodes( msg );
            Server.Players.Can( Permission.ReadStaffChat ).Message( "{0}(staff){1}{2}: {3}",
                Color.PM, Values.ClassyName, Color.PM, msg );
        }

        public static void SendError ( Exception e, MessageChannel Channel) {
            SendError( null, "&WError!!! " + e.Message, Channel );
        }

        public static void SendError ( String Msg, MessageChannel Channel ) {
            if ( Channel != MessageChannel.Logger ) {
                SendError( null, "&WError!!! " + Msg, Channel );
            } else {
                Logger.Log( LogType.Error, Msg );
            }
        }

        public static void SendError ( Player player, String Msg, MessageChannel Channel ) {
            if ( player != null ) {
                SendMessage( player, "&WError!!! " + Msg, Channel );
            } else {
                SendMessage( "&WError!!! " + Msg, Channel );
            }
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
                SendError( "HelperBot: Message cannot be null", MessageChannel.Logger );
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
                SendError ( "HelperBot: Message cannot be null", MessageChannel.Logger );
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
            if ( player == null ) SendError( "HelperBot: Player cannot be null", MessageChannel.Global );
            byte Max = 13; //Max enum byte
            int StringID = new Random().Next( 0, Max );
            RandomStat Picked = ( RandomStat )StringID;
            string StartOfMessage = player.ClassyName + "&F, ";
            switch ( Picked ) {
                case RandomStat.CurrentTime:
                    return "";
                case RandomStat.FirstPersonBanned:
                    return "The first person to get banned on this server was "+ Values.FirstBanned.ClassyName;
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
                    return "Our oldest active staff member is " + Values.OldestStaff.ClassyName;
                case RandomStat.FirstJoined:
                    return "The first person to join the server was " + 
                        Values.FirstJoined.ClassyName + "&Fon " + Values.FirstJoined.FirstLoginDate +
                        " ("+ Values.FirstJoined.TimeSinceFirstLogin.ToMiniString() + " ago).";
                default: return null; //shouldn't happen
            }
        }

        public static MessageChannel ParseChatType ( ChatMessageType MessageType ) {
            switch ( MessageType ) {
                case ChatMessageType.Global:
                    return MessageChannel.Global;
                case ChatMessageType.Me:
                    return MessageChannel.Me;
                case ChatMessageType.PM:
                    return MessageChannel.PM;
                case ChatMessageType.Staff:
                    return MessageChannel.Staff;
                default: return MessageChannel.Admin;
            }
        }

        public static String GetPlayerTotalHoursString ( Player player ) {
            TimeSpan totalTime = player.Info.TotalTime;
            return player.ClassyName + "&F, you have spent " + 
                totalTime.TotalHours + " hours (" + 
                totalTime.TotalMinutes + 
                " minutes) here.";
        }

        public static string GetRandomJoke () {
            return Values.Jokes[new Random().Next( 0, Values.Jokes.Length - 1 )];
        }

        public static void SetAllValues () {
            SetFirstJoined();
            SetFirstBanned();
            SetOldestStaff();
            LoadSwearArray();
        }

        public static void LoadSwearArray () {
            if ( MaintenanceTriggers.SwearFullTrigger == null){
                MaintenanceTriggers.SwearFullTrigger = new String[][] { System.IO.File.ReadAllLines( MaintenanceTriggers.swearFile.FullName ) };
            }
        }

        public static void SetFirstJoined () {
            if ( PlayerDB.PlayerInfoList == null ) {
                Logger.Log( LogType.Error, "HelperBot: PlayerInfoList is null @ SetFirstJoined" );
                return;
            }
           Values.FirstJoined = PlayerDB.PlayerInfoList.OrderBy( pi => pi.FirstLoginDate ).FirstOrDefault( pi => pi.FirstLoginDate != DateTime.MinValue );
        }

        public static void SetOldestStaff () {
            if ( PlayerDB.PlayerInfoList == null ) {
                Logger.Log( LogType.Error, "HelperBot: PlayerInfoList is null @ SetOldestStaff" );
                return;
            }
            Values.OldestStaff = PlayerDB.PlayerInfoList.Where(p=> p.Can(Permission.ReadStaffChat)).OrderBy( pi => pi.FirstLoginDate ).FirstOrDefault( pi => pi.FirstLoginDate != DateTime.MinValue );
        }

        public static void SetFirstBanned () {
            if ( PlayerDB.PlayerInfoList == null ) {
                Logger.Log( LogType.Error, "HelperBot: PlayerInfoList is null @ SetFirstBanned" );
                return;
            }
            Values.FirstBanned = PlayerDB.PlayerInfoList.Where( p => p.IsBanned ).OrderBy( pi => pi.BanDate ).FirstOrDefault( pi => pi.BanDate != DateTime.MinValue );
        }

        public static string GetRandomPosComment () {
            return Values.PositiveComments[new Random().Next( 0, Values.PositiveComments.Length - 1 )];
        }
    }
}
