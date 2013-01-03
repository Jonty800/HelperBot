using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fCraft;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace HelperBot {
    public static class Config {

        #region XML settings
        /// <summary>
        /// Current version of the config file
        /// </summary>
        public const int CurrentVersion = 1;

        /// <summary>
        /// The XML root name
        /// </summary>
        const string ConfigXmlRootName = "HelperBotConfig";

        /// <summary>
        /// The location of the XML file
        /// </summary>
        const string FilePath = "plugins/HelperBot.xml";

        #endregion

        #region Booleans

        /// <summary>
        /// Whether a server announces how to fly or not
        /// </summary>
        public static bool AnnounceHowToFly = true;

        /// <summary>
        /// Announce the server name upon asking
        /// </summary>
        public static bool AnnounceServerName = true;

        /// <summary>
        /// Announce a players current hours upon asking
        /// </summary>
        public static bool AnnouncePlayerHours = true;

        /// <summary>
        /// Announce what a players next rank is
        /// </summary>
        public static bool AnnounceNextRankUp = true;

        /// <summary>
        /// Warn a player when they log back in after a kick (Via PM)
        /// </summary>
        public static bool WarnPlayersAfterKick = true;

        /// <summary>
        /// Warn players when they swear via PM
        /// </summary>
        public static bool WarnPlayersForSwearing = true;

        /// <summary>
        /// Suggest to mods in staff chat that a ban is in order
        /// </summary>
        public static bool SuggestBan = true;

        #endregion

        #region Strings

        /// <summary>
        /// String value for "how do I get ranked" (builder)
        /// </summary>
        public static string HowToGetRankedBuilderString = "&S to get ranked, keep building then use /Review and a member of staff with check your build";

        /// <summary>
        /// String value for "how do I get ranked" (staff)
        /// </summary>
        public static string HowToGetRankedStaffString = "&S to get the next staff rank, try to moderate the server in the best way possible";

        /// <summary>
        /// String value for the server's website
        /// </summary>
        public static string Website = "http://yourwebsite.com";

        /// <summary>
        /// String value for "I got demoted" reply
        /// </summary>
        public static string DemotedMessage = "&S, if you were wrongfully demoted you can appeal at " + Website;

        /// <summary>
        /// String value for "I am stuck" reply
        /// </summary>
        public static string StuckMessage = "&S, if you are stuck press R to respawn";

        #endregion

        /// <summary>
        /// Designed to load the settings from the XML config file and replace the default values
        /// </summary>
        /// <returns>true if everything went smoothly</returns>
        public static bool Load ( ) {
            bool fromFile = false;
            XDocument file;
            if ( File.Exists( FilePath ) ) {
                try {
                    file = XDocument.Load( FilePath );
                    if ( file.Root == null || file.Root.Name != ConfigXmlRootName ) {
                        Logger.Log( LogType.Warning,
                                    "(HelperBot)Config.Load: Malformed or incompatible config file {0}. Loading defaults.",
                                    FilePath );
                        file = new XDocument();
                        file.Add( new XElement( ConfigXmlRootName ) );
                    } else {
                        Logger.Log( LogType.Debug,
                                    "(HelperBot)Config.Load: Config file {0} loaded succesfully.",
                                    FilePath );
                        fromFile = true;
                    }
                } catch ( Exception ex ) {
                    Logger.LogAndReportCrash( "Config failed to load", "HelperBot", ex, true );
                    return false;
                }
            } else {
                // create a new one (with defaults) if no file exists
                file = new XDocument();
                file.Add( new XElement( ConfigXmlRootName ) );
            }

            XElement config = file.Root;
            if ( config == null ) throw new Exception( "HelperBot.xml has no root. Never happens." );

            int version = 0;
            if ( fromFile ) {
                XAttribute attr = config.Attribute( "version" );
                if ( attr != null && Int32.TryParse( attr.Value, out version ) ) {
                    if ( version != CurrentVersion ) {
                        Logger.Log( LogType.Warning,
                                    "(HelperBot)Config.Load: Your HelperBot.xml was made for a different version." +
                                    "Some obsolete settings might be ignored, and some recently-added settings will be set to defaults. " +
                                    "It is recommended that you run HelperBot.exe to make sure that everything is in order." );
                    }
                } else {
                    Logger.Log( LogType.Warning,
                                "(HelperBot)Config.Load: Unknown version of HelperBot.xml found. It might be corrupted. " +
                                "Please run HelperBot.exe to make sure that everything is in order." );
                }
            }

            //exmaple loading of a key
            XElement settings = config.Element( "Settings" );
            if ( settings != null ) {
                foreach ( XElement element in settings.Elements( "ConfigKey" ) ) {

                    string keyName = element.Attribute( "key" ).Value;
                    string value = element.Attribute( "value" ).Value;
                    int key;
                    if ( keyName == "Version" ) {
                        if ( int.TryParse( value, out key ) ) {
                            version = key;
                        } else {
                            // unknown key
                            Logger.Log( LogType.Warning,
                                        "Config: Unrecognized entry ignored: {0} = {1}",
                                        element.Name, element.Value );
                        }
                    }
                }
            } else {
                Logger.Log( LogType.Warning,
                            "(HelperBot)Config.Load: No <Settings> tag present. Using default for everything." );
            }
            return true;
        }
        
    }
}
