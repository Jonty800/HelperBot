//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares
using System;
using System.Linq;
using fCraft;
using fCraft.Events;

namespace HelperBot {

    public static class Events {

        /// <summary>
        /// This will be our initilization. This has to happen once the server has fully been
        /// started so no errors occur
        /// </summary>
        public static void ServerStarted( object sender, EventArgs e ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: ServerStartedEvent" );
            }
            Methods.SetAllValues(); //Load all the player reply values
            Chat.Sent += ChatSentMessage;
            PlayerInfo.RankChanged += PlayerPromoted;
            Player.Connected += PlayerConnected;
            Settings.Load(); //Load HelperBot.xml
        }

        /// <summary>
        /// This event happens when a chat message has been sent and shown on screen
        /// This should be used to relay the AI messages to the server / player
        /// NOTE IRC is not controlable, which means we can't do !Players
        /// </summary>
        public static void ChatSentMessage( object sender, ChatSentEventArgs e ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: ChatSentMessage P=" + e.Player.Name + "; ML=" + e.Message.Length + "; MT=" + e.MessageType );
            }
            if ( e.Message == null )
                return;
            MessageChannel Channel = Methods.ParseChatType( e.MessageType );
            if ( Methods.DetectMessageImpersonation( e.Message ) || Methods.IsPlayersDisplayedNameBots( e.Player ) ) {
                if ( e.Player != Player.Console ) {
                    if ( Settings.AnnounceImpersonation ) {
                        e.Player.Kick( Player.Console, "Impersonation Detected", LeaveReason.Kick, true, true, false ); //tad harsh? //it will stop it from happening!
                    } else {
                        Methods.SendMessage( "That wasn't me, that was " + e.Player.Info.Rank.Color + e.Player.Name, Channel ); //DetectMessageImpersonation shouldnt work for PMs
                    }
                }
            }
            if ( e.MessageType == ChatMessageType.IRC || e.MessageType == ChatMessageType.Say || e.MessageType == ChatMessageType.Rank )
                return;

            Triggers.CheckTriggers( e.Player, e.Message, Channel );
        }

        /// <summary>
        /// Player connected successfully to the server event
        /// </summary>
        public static void PlayerConnected( object sender, PlayerConnectedEventArgs e ) {
            PlayerInfo info = e.Player.Info;
            //if the player left due to a kick
            if ( info.LeaveReason == LeaveReason.Kick && Settings.AnnounceWarnKick ) {
                if ( info.LastKickReason != null ) {
                    if ( info.LastKickReason.Length > 0 ) {
                        Methods.SendMessage( e.Player, info.Name + Color.PM + " you were kicked by a staff member. Please follow the /Rules next time! Kick Reason: " + info.LastKickReason, MessageChannel.PM );
                    } else {
                        Methods.SendMessage( e.Player, info.Name + Color.PM + " you were kicked by a staff member. Please follow the /Rules next time!", MessageChannel.PM );
                    }
                } else {
                    Methods.SendMessage( e.Player, info.Name + Color.PM + " you were kicked by a staff member. Please follow the /Rules next time!", MessageChannel.PM );
                }
            }
                ///<summary>
                /// Player logging in for first time
                /// <summary>
            else if ( info.TimesVisited == 1 && Settings.AnnounceGreeting ) {
                //should pick out all the admins online
                Player[] OnlineStaff = Server.Players.Where( p => p.Can( Permission.ReadStaffChat ) ).ToArray();
                if ( OnlineStaff.Count() != 0 ) {
                    Methods.SendStaff( info.ClassyName + Color.PM + " just logged on for the first time! Welcome them to the server!" );
                }
            }
                ///<summary>
                /// Suspicious behavoir
                /// <summary>
            else if ( info.BlocksBuilt + info.BlocksDrawn < info.BlocksDeleted && Settings.AnnounceSuggestBan ) {
                Methods.SendStaff( info.ClassyName + Color.PM + " is matching suspicious behavior! (Blocks deleted > Blocks Placed) Please address the issue." );
            }
        }

        ///<summary>
        ///Suggest ban for player that was kicked 2 times in 2 days
        ///<summary>
        public static void PlayerKicked( object sender, PlayerBeingKickedEventArgs e ) {
            PlayerInfo info = e.Player.Info;
            if ( info.TimeSinceLastKick < TimeSpan.FromDays( 1 ) && info.TimesKicked > 0 && Settings.AnnounceSuggestBan ) {
                Methods.SendStaff( info.ClassyName + Color.PM + " has been kicked 2 times within the last two days. Please review if a ban is neccessary" );
            }
        }

        /// <summary>
        /// Player getting promoted event
        /// Used to say well done to ranking up players
        /// </summary>
        public static void PlayerPromoted( object sender, PlayerInfoRankChangedEventArgs e ) {
            if ( e.NewRank > e.OldRank ) {
                //3 second wait so its not announced before the promotion itself
                Scheduler.NewTask( t => AnnouncePlayerPromotion( e.PlayerInfo ) ).RunOnce( TimeSpan.FromSeconds( 3 ) );
                return;
            }
        }

        /// <summary>
        /// Used in the PlayerPromoted event, so a null check can be implemented after the timer
        /// </summary>
        /// <param name="playerInfo"></param>
        private static void AnnouncePlayerPromotion( PlayerInfo playerInfo ) {
            if ( playerInfo == null )
                return;
            Methods.SendMessage( playerInfo.ClassyName + "&F, congratulations on your new rank! " + Methods.GetRandomPosComment(), MessageChannel.Global );
            Methods.AddTYPlayer( playerInfo.PlayerObject );
        }
    }
}