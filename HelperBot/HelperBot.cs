﻿//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

using fCraft;

namespace HelperBot {

    /// <summary>
    /// This is the plugin's initilization class
    /// The initilization of the bot should happen inside ServerStarted event in Events.cs
    /// </summary>
    public class Init : Plugin {

        public void Initialize() {
            Logger.Log( LogType.ConsoleOutput, "Starting HelperBot " + Version + ". Waiting for Init." );
            Server.Started += Events.ServerStarted;
        }

        /// <summary>
        /// Name of the plugin
        /// </summary>
        public string Name {
            get {
                return "HelperBot";
            }
            set {
                Name = value;
            }
        }

        /// <summary>
        /// Version of the plugin
        /// </summary>
        public string Version {
            get {
                return "1.0";
            }
            set {
                Version = value;
            }
        }
    }
}