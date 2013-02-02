//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using fCraft;

namespace HelperBot {
    /// <summary>
    /// Static class containing Trigger for the bot to respond to a player.
    /// </summary>
    public static class Triggers {

        public static bool SpleefInProgress = false;
        public static bool IsAllUpper(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!Char.IsUpper(text[i]))
                    return false;
            }

            return true;
        }
        public static DateTime SinceAnswer;

        public static void CheckTriggers ( Player player, String Message, MessageChannel Channel ) {
            if ( Channel == MessageChannel.PM ) return;
            if ( Triggers.MatchesTrigger( Message, RankTriggers.NextRankFullTrigger ) ) {
                if ( player.Info.Rank != RankManager.HighestRank ) {
                    Methods.SendMessage( player.ClassyName + "&F, your next rank is " + player.Info.Rank.NextRankUp.ClassyName, Channel );
                    SinceAnswer = DateTime.Now;
                } else {
                    Methods.SendMessage( player.ClassyName + "&F, you are already the highest rank!", Channel );
                    SinceAnswer = DateTime.Now;
                }
                return;
            }
            if (IsAllUpper(Message))
            {
                Methods.SendPM(player, Color.PM + "Please refrain from abusing caps.");
            }

            if ( Triggers.MatchesTrigger( Message, RankTriggers.HowDoFullTrigger ) ) {
                if ( player.Info.Rank == RankManager.HighestRank ) return;
                if ( player.Can( Permission.ReadStaffChat ) ) {
                    Methods.SendMessage( player.ClassyName + "&f, " + Settings.HowToGetRankedStaffString, Channel );
                    SinceAnswer = DateTime.Now;
                } else {
                    Methods.SendMessage( player.ClassyName + "&f, " + Settings.HowToGetRankedBuilderString, Channel );
                    SinceAnswer = DateTime.Now;
                }
                return;
            }
            if (Triggers.MatchesTrigger(Message, MaintenanceTriggers.PMFullTrigger))
            {
                Methods.SendMessage(player.ClassyName + "&f, to PM, type '@playername [message]'.", Channel);
                SinceAnswer = DateTime.Now;
                return;
            }
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.TimeFullTrigger ) ) {
                Methods.SendMessage( player.ClassyName + "&f, the time is currently " + DateTime.Now.ToShortTimeString(), Channel );
                SinceAnswer = DateTime.Now;
                return;
            }
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.FellFullTrigger ) ) {
                Methods.SendMessage( player.ClassyName + Settings.StuckMessage, Channel );
                SinceAnswer = DateTime.Now;
                return;
            }
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.HoursFullTrigger ) ) {
                double hours = Convert.ToInt64(Methods.GetPlayerTotalHoursString(player));
                Methods.SendMessage( Math.Round(hours, 0, MidpointRounding.AwayFromZero).ToString() , Channel);
                SinceAnswer = DateTime.Now;
                return;
            }
            if ( File.Exists( "SwearWords.txt" ) ) {
                if ( !player.Can( Permission.Swear ) ) {
                    if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.SwearFullTrigger ) ) {
                        Methods.SendMessage( player, Color.PM + "Please refrain from swearing :)", MessageChannel.PM );
                        SinceAnswer = DateTime.Now;
                        return;
                    }
                }
            }
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.WebFullTrigger ) ) {
                Methods.SendMessage( player.ClassyName + "&F, the server's website is " + Settings.Website, Channel );
                SinceAnswer = DateTime.Now;
                return;
            }
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.ServFullTrigger ) ) {
                Methods.SendMessage( player.ClassyName + "&F, you are currently playing on " + ConfigKey.ServerName.GetString(), Channel );
                SinceAnswer = DateTime.Now;
                return;
            }
            if ( Triggers.MatchesTrigger( Message, MiscTriggers.SpleefFullTrigger ) ) {
                if ( SpleefInProgress ) return;
                try {
                    Thread t = new Thread( new ThreadStart( delegate {
                        SpleefInProgress = true;
                        for ( int i = 3; i >= 1; i-- ) {
                            Thread.Sleep( 1000 );
                            Methods.SendChat( i.ToString() );
                        }
                        Thread.Sleep( 1000 );
                        Methods.SendChat( "&WSPLEEF!" );
                        SpleefInProgress = false;
                    } ) );
                    t.Start();
                } catch { SpleefInProgress = false; }
                return;
            }
            if ( Triggers.MatchesNameAndTrigger( Message, MiscTriggers.JokeFullTrigger ) ) {
                Methods.SendMessage( Methods.GetRandomJoke(), MessageChannel.Global );
                return;
            }
            if ( Triggers.MatchesTrigger( Message, MiscTriggers.FlyFullTrigger ) ) {
                Methods.SendMessage( player.ClassyName + "&F, to fly, type /fly, or download WoM at womjr.com/game_client.", MessageChannel.Global );
                SinceAnswer = DateTime.Now;
                return;
            }
            if (Triggers.MatchesTrigger(Message, MiscTriggers.ThanksFullTrigger))
            {
                double totalTime =  (DateTime.Now - SinceAnswer).TotalSeconds;
                if (totalTime < 5)
                {
                    Random thanksMsg = new Random();
                    Methods.SendMessage("&f, " + Values.ThankyouReplies[thanksMsg.Next(0, Values.ThankyouReplies.Length - 1)], MessageChannel.Global);
                }
            }
        }

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
