//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
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
            Player.Connected += PlayerConnected;
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
            if ( e.Message == null ) return;
            if ( Methods.DetectMessageImpersonation( e.Message ) ) {
                e.Player.Kick( Player.Console, "Impersonation Detected", LeaveReason.Kick, true, true, false ); //tad harsh? //it will stop it from happening!
                //plus it will be optional for the host
            }
            if ( e.MessageType == ChatMessageType.IRC || e.MessageType == ChatMessageType.Say || e.MessageType == ChatMessageType.Rank ) return;
            MessageChannel Channel = Methods.ParseChatType( e.MessageType );
            
            Triggers.CheckRankTriggers( e.Player, e.Message, Channel );
            Triggers.CheckMiscTriggers( e.Player, e.Message, Channel );
            Triggers.CheckMaintenanceTriggers( e.Player, e.Message, Channel );
        }
        public static void PlayerConnected(PlayerInfo info, PlayerConnectedEventArgs e)
        {
            int LastKick = info.TimeSinceLastKick.Milliseconds;
            //if the player left due to a kick, and it has been under two minutes
            if(info.LeaveReason == LeaveReason.Kick && LastKick < 120000)
            {
                Methods.SendMessage(e + "&F, You have been kicked by a staff member. Please follow the rules in /rules next time! Kick Reason: " + info.LastKickReason, MessageChannel.PM);
            }
            else
            {
                return;
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
