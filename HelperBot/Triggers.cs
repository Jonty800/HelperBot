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

        public static void CheckRankTriggers ( Player player, String Message, MessageChannel Channel) {
            if ( Triggers.MatchesTrigger( Message, RankTriggers.NextRankFullTrigger ) ) {
                if ( player.Info.Rank != RankManager.HighestRank ) {
                    Methods.SendMessage( player.ClassyName + "&F, your next rank is " + player.Info.Rank.NextRankUp.ClassyName, Channel );
                } else {
                    Methods.SendMessage( player.ClassyName + "&F, you are already the highest rank!", Channel );
                }
            }
            if ( Triggers.MatchesTrigger( Message, RankTriggers.HowDoFullTrigger ) ) {
                if ( player.Info.Rank == RankManager.HighestRank ) return;
                if ( player.Can( Permission.ReadStaffChat ) )
                    Methods.SendMessage( player.ClassyName + "&f, " + Settings.HowToGetRankedStaffString, Channel);
                else
                    Methods.SendMessage( player.ClassyName + "&f, " + Settings.HowToGetRankedBuilderString, Channel);
            }
        }

        public static void CheckMaintenanceTriggers ( Player player, String Message, MessageChannel Channel ) {
            if (Triggers.MatchesNameAndTrigger(Message, MaintenanceTriggers.TimeFullTrigger))
            {
                Methods.SendMessage(player.ClassyName + "&f, the time is currently " +  DateTime.Now.ToShortTimeString() + ".", Channel);
            }
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.FellFullTrigger ) ) {
                Methods.SendMessage( player.ClassyName + Settings.StuckMessage, Channel );
            }
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.HoursFullTrigger ) ) {
                Methods.SendMessage( Methods.GetPlayerTotalHoursString( player ), Channel );
            }
            if ( File.Exists( "SwearWords.txt" ) ) {
                if ( !player.Can( Permission.Swear ) ) {
                    if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.SwearFullTrigger ) ) {
                        Methods.SendMessage( player.ClassyName + "&F, Please refrain from swearing.", Channel );
                    }
                }
            }
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.WebFullTrigger ) ) {
                Methods.SendMessage( player.ClassyName + "&F, the server's website is " + Settings.Website, Channel );
            }
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.ServFullTrigger ) ) {
                Methods.SendMessage( player.ClassyName + "&F, you are currently playing on " + ConfigKey.ServerName.GetString(), Channel );
            }
        }

        public static void CheckMiscTriggers ( Player player, String Message, MessageChannel Channel ) {
            if ( Triggers.MatchesNameAndTrigger( Message, MiscTriggers.SpleefFullTrigger ) ) {
                //cheap timer is cheap
                Methods.SendMessage( "&f3", MessageChannel.Global );
                Thread.Sleep( 1000 );
                Methods.SendMessage( "&f2", MessageChannel.Global );
                Thread.Sleep( 1000 );
                Methods.SendMessage( "&f1", MessageChannel.Global );
                Thread.Sleep( 1000 );
                Methods.SendMessage( "&fGO!", MessageChannel.Global );
            }
            if ( Triggers.MatchesNameAndTrigger( Message, MiscTriggers.JokeFullTrigger ) ) {
                Methods.SendMessage( Methods.GetRandomJoke(), MessageChannel.Global );
            }
            if (Triggers.MatchesTrigger(Message, MiscTriggers.FlyFullTrigger))
            {
                Methods.SendMessage(player.ClassyName + "&F, to fly, type /fly, or download WoM at womjr.com/game_client.", MessageChannel.Global);
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
