//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fCraft;
using fCraft.Events;

namespace HelperBot {
    public static class Events {
        /// <summary>
        /// This will be our initilization. This has to happen once the server has fully been
        /// started so no errors occur
        /// </summary>
        public static void ServerStarted ( object sender, EventArgs e ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: ServerStartedEvent" );
            }
            Methods.SetAllValues(); //Load all the player reply values
            Chat.Sent += ChatSentMessage;
            PlayerInfo.RankChanged += PlayerPromoted;
        }

        /// <summary>
        /// This event happens when a chat message has been sent and shown on screen
        /// This should be used to relay the AI messages to the server / player
        /// NOTE IRC is not controlable, which means we can't do !Players
        /// </summary>
        public static void ChatSentMessage ( object sender, ChatSentEventArgs e ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: ChatSentMessage P=" + e.Player.Name + "; ML=" + e.Message.Length + "; MT=" + e.MessageType );
            }
            if(e.Message == null) return;
            switch ( e.MessageType ) {
                /*case ChatMessageType.IRC:
                    if ( e.Message.ToLower() == "!players" ) {
                        IRC.SendChannelMessage( "Players online: " + Server.Players.Where( p => !p.Info.IsHidden ).JoinToClassyString() );
                    }
                    break;*/
                case ChatMessageType.Global:
                    Random rand = new Random(); //best i can do for now
                    TimeSpan time = TimeSpan.FromHours(e.Player.Info.TotalTime.TotalHours);
                    if (Triggers.MatchesNameAndTrigger(e.Message, MiscTriggers.JokeFullTrigger))
                    {
                        Methods.SendMessage(e.Player.ClassyName + "&F, " + Values.Jokes[rand.Next(0, Values.Jokes.Length)] + ".", MessageChannel.Global);
                    }
                    if (Triggers.MatchesNameAndTrigger(e.Message, MaintenanceTriggers.FellFullTrigger))
                    {
                        Methods.SendMessage(e.Player.ClassyName + "&F, " + Settings.StuckMessage, MessageChannel.Global);                           
                    }
                    if (Triggers.MatchesNameAndTrigger(e.Message, MaintenanceTriggers.HoursFullTrigger))
                    {
                        Methods.SendMessage(e.Player.ClassyName + "&F, you have " + time.ToMiniString() +".", MessageChannel.Global);
                    }
                    if (Triggers.MatchesNameAndTrigger(e.Message, MaintenanceTriggers.SwearFullTrigger))
                    {
                        Methods.SendMessage(e.Player.ClassyName + "&F, Please refrain from swearing." , MessageChannel.PM);
                    }         
                    if (Triggers.MatchesNameAndTrigger(e.Message, MaintenanceTriggers.WebFullTrigger))
                    {
                        Methods.SendMessage(e.Player.ClassyName + "&F, the server's website is " + Settings.Website + ".", MessageChannel.Global);
                    }
                    if (Triggers.MatchesNameAndTrigger(e.Message, MaintenanceTriggers.ServFullTrigger))
                    {
                        Methods.SendMessage(e.Player.ClassyName + "&F, you are currently playing on " + ConfigKey.ServerName.GetString() + ".", MessageChannel.Global);
                    }
                    if ( Triggers.MatchesTrigger( e.Message, RankTriggers.NextRankFullTrigger ) ) {
                        if ( e.Player.Info.Rank != RankManager.HighestRank ) {
                            Methods.SendMessage( e.Player.ClassyName + "&F, your next rank is " + e.Player.Info.Rank.NextRankUp.ClassyName, MessageChannel.Global );
                        } else {
                            Methods.SendMessage( e.Player.ClassyName + "&F, you are already the highest rank!", MessageChannel.Global );
                        }
                    }
                    if ( Triggers.MatchesTrigger( e.Message, RankTriggers.HowDoFullTrigger ) ) {
                        if ( e.Player.Info.Rank == RankManager.HighestRank ) return;
                        if ( e.Player.Can( Permission.ReadStaffChat ) )
                            Methods.SendMessage( e.Player.ClassyName + Settings.HowToGetRankedStaffString, MessageChannel.Global );
                        else
                            Methods.SendMessage( e.Player.ClassyName + Settings.HowToGetRankedBuilderString, MessageChannel.Global );
                    }
                    break;
                case ChatMessageType.PM:
                    break;
                case ChatMessageType.Say:
                    if ( Methods.DetectMessageImpersonation( e.Message ) ) {
                        e.Player.Kick( Player.Console, "Impersonation Detected", LeaveReason.Kick, true, true, false ); //tad harsh?
                    }
                    break;
                case ChatMessageType.Staff:
                    break;
                case ChatMessageType.Rank:
                    break;
                default:
                    //dunno
                    break;
            }
        }

        public static void PlayerPromoted ( object sender, PlayerInfoRankChangedEventArgs e ) {
            if ( e.NewRank > e.OldRank ) {
                Scheduler.NewTask( t => Methods.SendMessage( e.PlayerInfo.ClassyName + "&F, congradulations on your new rank! " + Values.PositiveComments, MessageChannel.Global ) ).RunOnce( TimeSpan.FromSeconds( 3 ) );
                return;
            }
        }
    }
}
