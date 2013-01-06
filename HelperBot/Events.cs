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
                Methods.SetAllValues(); //Load all the player reply values
            }
        }

        /// <summary>
        /// This event happens when a chat message has been sent and shown on screen
        /// This should be used to relay the AI messages to the server / player
        /// </summary>
        public static void ChatSentMessage ( object sender, ChatSentEventArgs e ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: ChatSentMessage P="+e.Player.Name +"; ML="+e.Message.Length + "; MT="+e.MessageType );
            }
        }

        /// <summary>
        /// This event happens when a command is called
        /// This should be used to check for impersonation
        /// </summary>
        public static void CommandCalled ( object sender, CommandCalledEventArgs e ) {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: CommandCalledEvent" );
            }
            if ( e.Command == null || e.CommandDescriptor == null || e.Player == null ) return;
            if ( e.CommandDescriptor.Name.ToLower() == "say" ) { //say doesnt have aliases
                if ( Methods.DetectMessageImpersonation( e.Command.NextAll() ) ) {
                    e.Player.Kick( Player.Console, "Impersonation Detected", LeaveReason.Kick, true, true, false );
                }
            }
        }
    }
}
