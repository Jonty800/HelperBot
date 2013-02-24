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
        public static bool IsAllUpper(String text)
        {
            for (int i = 0; i < text.Length; i++)
            { 
                if (!Char.IsUpper(text[i]))
                    return false;
            }

            return true;
        }

        public static void CheckTriggers ( Player player, String Message, MessageChannel Channel ) {
            //Check swears in PMs
            if ( Channel == MessageChannel.PM ) {
                if (File.Exists("SwearWords.txt") && Settings.AnnounceWarnSwear)
                {
                    if (!player.Can(Permission.Swear))
                    {
                        if (Triggers.MatchesTrigger(Message, MaintenanceTriggers.SwearFullTrigger))
                        {
                            Methods.SendMessage(player, Color.PM + "Please refrain from swearing :)", MessageChannel.PM);
                            return;
                        }
                    }
                }
            }
            if ( Channel == MessageChannel.PM ) return; //ignore PMs for this

            //What is my next rank?
            if ( Triggers.MatchesTrigger( Message, RankTriggers.NextRankFullTrigger ) && Settings.AnnounceRank ) {
                if ( player.Info.Rank != RankManager.HighestRank ) {
                    Methods.SendMessage( player.ClassyName + "&F, your next rank is " + player.Info.Rank.NextRankUp.ClassyName, Channel );
                    Methods.AddTYPlayer( player );
                } else {
                    Methods.SendMessage( player.ClassyName + "&F, you are already the highest rank!", Channel );
                    Methods.AddTYPlayer( player );
                }
                return;
            }
            //Caps checker
            if (IsAllUpper(Message))
            {
                Methods.SendPM(player, "Please refrain from abusing caps.");
            }
            //How do I get the next rank?
            if (Triggers.MatchesTrigger(Message, RankTriggers.HowDoFullTrigger) && Settings.AnnounceRank)
            {
                if ( player.Info.Rank == RankManager.HighestRank ) return;
                if ( player.Can( Permission.ReadStaffChat ) ) {
                    Methods.SendMessage( player.ClassyName + "&f, " + Settings.HowToGetRankedStaffString, Channel );
                    Methods.AddTYPlayer( player );
                } else {
                    Methods.SendMessage( player.ClassyName + "&f, " + Settings.HowToGetRankedBuilderString, Channel );
                    Methods.AddTYPlayer( player );
                }
                return;
            }

            //How do I PM players?
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.PMFullTrigger ) && Settings.AnnouncePM) {
                Methods.SendMessage( player.ClassyName + "&f, to PM, type '@playername [message]'.", Channel );
                Methods.AddTYPlayer( player );
                return;
            }

            //What is the time
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.TimeFullTrigger ) && Settings.AnnounceTime) {
                Methods.SendMessage( player.ClassyName + "&f, the server's time is currently " + DateTime.Now.ToShortTimeString(), Channel );
                Methods.AddTYPlayer( player );
                return;
            }

            //I fell
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.FellFullTrigger ) && Settings.AnnounceFell) {
                Methods.SendMessage( player.ClassyName + Settings.StuckMessage, Channel );
                Methods.AddTYPlayer( player );
                return;
            }

            //What are my hours?
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.HoursFullTrigger ) && Settings.AnnounceHours) {
                Methods.SendMessage(Methods.GetPlayerTotalHoursString(player) , Channel);
                Methods.AddTYPlayer( player );
                return;
            }
            
            //What is the website?
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.WebFullTrigger )) {
                Methods.SendMessage( player.ClassyName + "&F, the server's website is " + Settings.Website, Channel );
                Methods.AddTYPlayer( player );
                return;
            }

            //What is the server's name?
            if ( Triggers.MatchesTrigger( Message, MaintenanceTriggers.ServFullTrigger ) && Settings.AnnounceServerName) {
                Methods.SendMessage( player.ClassyName + "&F, you are currently playing on " + ConfigKey.ServerName.GetString(), Channel );
                Methods.AddTYPlayer( player );
                return;
            }

            //!Spleef
            if ( Triggers.MatchesTrigger( Message, MiscTriggers.SpleefFullTrigger ) && Settings.AnnounceSpleefTimer ) {
                if ( SpleefInProgress ) {
                    Methods.SendPM( player, "There is already a spleef timer!" );
                    return;
                }
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

            //Alice, Joke
            if ( Triggers.MatchesNameAndTrigger( Message, MiscTriggers.JokeFullTrigger ) && Settings.AnnounceJokes) {
                Methods.SendMessage( Methods.GetRandomJoke(), MessageChannel.Global );
                return;
            }

            //how do I fly? Using CM now since Java 7 is such a pain
            if ( Triggers.MatchesTrigger( Message, MiscTriggers.FlyFullTrigger ) && Settings.AnnounceFly) {
                Methods.SendMessage( player.ClassyName + "&F, to fly, type /fly, or download CM at http://is.gd/charged.", MessageChannel.Global );
                Methods.AddTYPlayer( player );
                return;
            }

            //fun fact
            if ( Triggers.MatchesNameAndTrigger( Message, MiscTriggers.FunFactFullTrigger ) && Settings.AnnounceJokes) {
                Methods.SendMessage( Methods.GetRandomStatString( player ), Channel );
                return;
            }

            //Thanks checking
            if ( Triggers.MessageIsTrigger( Message, MiscTriggers.ThanksFullTrigger ) ) {
                lock ( Values.AwaitingThanks ) {
                    foreach ( Values.TYObject _O in Values.AwaitingThanks ) {
                        if ( _O.player == player ) {
                            double totalTime = ( DateTime.Now - _O.Time ).TotalSeconds;
                            if ( totalTime <= 20 ) {
                                Methods.SendMessage( Values.ThankyouReplies[new Random().Next( 0, Values.ThankyouReplies.Length)], MessageChannel.Global );
                            }
                        }
                    }
                    Methods.RemoveTYPlayer( player );
                }
            }
        }

        #region Trigger Checkers
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

        public static bool MessageIsTrigger ( string rawMessage, String[][] ArrayContainer ) {
            rawMessage = fCraft.Color.StripColors( rawMessage );
            rawMessage = rawMessage.ToLower();
            foreach ( String[] Array in ArrayContainer ) {
                if ( Array.All( s => rawMessage.Equals( s ) ) ) {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
