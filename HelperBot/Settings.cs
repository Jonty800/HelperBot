//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

//NOTE: I am not happy with this class, I need to rethink and rewrite it
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using fCraft;

namespace HelperBot {

    public enum Flags {
        Debug,
        Release
    }

    public static class Settings {
        public static Flags ReleaseFlag = Flags.Release;

        #region XML settings

        /// <summary>
        /// Current version of the config file and xml file
        /// </summary>
        public static int CurrentVersion = 1;

        public static int XmlVersion = 1;

        /// <summary>
        /// The XML root name
        /// </summary>
        private const string ConfigXmlRootName = "HelperBotConfig"; //unneeded?

        /// <summary>
        /// The location of the XML file
        /// </summary>
        private const string FilePath = "plugins/HelperBot.xml";

        #endregion XML settings

        #region Booleans

        /// <summary>
        /// Whether a server announces how to fly or not
        /// </summary>
        public static bool AnnounceFly = true;

        /// <summary>
        /// Announce the server name upon asking
        /// </summary>
        public static bool AnnounceServerName = true;

        /// <summary>
        /// Announce a players current hours upon asking
        /// </summary>
        public static bool AnnounceHours = true;

        /// <summary>
        /// Announce what a players next rank is
        /// </summary>
        public static bool AnnounceRank = true;

        /// <summary>
        /// Warn a player when they log back in after a kick (Via PM)
        /// </summary>
        public static bool AnnounceWarnKick = true;

        /// <summary>
        /// Warn players when they swear via PM
        /// </summary>
        public static bool AnnounceWarnSwear = true;

        /// <summary>
        /// Suggest to mods in staff chat that a ban is in order
        /// </summary>
        public static bool AnnounceSuggestBan = true;

        /// <summary>
        /// Bot will display time of day
        /// </summary>
        public static bool AnnounceTime = true;

        /// <summary>
        /// Explains how to use PM
        /// </summary>
        public static bool AnnouncePM = true;

        /// <summary>
        /// Explains how to return to respawn (r)
        /// </summary>
        public static bool AnnounceFell = true;

        /// <summary>
        /// Bot will start a timer for spleef
        /// </summary>
        public static bool AnnounceSpleefTimer = true;

        /// <summary>
        /// Greets a player if they are logging in for the first time
        /// </summary>
        public static bool AnnounceGreeting = true;

        /// <summary>
        /// Explains why a player was demoted
        /// </summary>
        public static bool AnnounceDemoted = true;

        /// <summary>
        /// Warns players for spamming caps
        /// </summary>
        public static bool AnnounceCaps = true;

        /// <summary>
        /// Bot will display jokes/funfacts
        /// </summary>
        public static bool AnnounceJokes = true;

        /// <summary>
        /// Bot will kick a player if impersonating the bot
        /// </summary>
        public static bool AnnounceImpersonation = true;

        #endregion Booleans

        #region Strings

        /// <summary>
        /// The name of the bot
        /// Deafult: Alice
        /// </summary>
        public static string Name = "Alice";

        /// <summary>
        /// String value for "how do I get ranked" (builder)
        /// </summary>
        public static string HowToGetRankedBuilderString = "&F to get ranked, keep building then use /Review and a member of staff will check your build";

        /// <summary>
        /// String value for "how do I get ranked" (staff)
        /// </summary>
        public static string HowToGetRankedStaffString = "&F to get the next staff rank, try to moderate the server in the best way possible";

        /// <summary>
        /// String value for the server's website
        /// </summary>
        public static string Website = "http://yourwebsite.com";

        /// <summary>
        /// String value for "I am stuck" reply
        /// </summary>
        public static string StuckMessage = "&F, if you are stuck press R to respawn";

        #region Personality (Maybe)

        public static int Age = 21;
        public static string Hometown = "London, England";
        public static string Sex = "female";
        public static string Occupation = "botting 'n stuff"; //My occupation is + Occupation (lowercase starting)

        #endregion Personality (Maybe)

        #endregion Strings

        #region ColorParsing

        public static bool IsValidColorCode( char code ) {
            return ( code >= '0' && code <= '9' ) || ( code >= 'a' && code <= 'f' ) || ( code >= 'A' && code <= 'F' );
        }

        public static readonly SortedList<char, string> ColorNames = new SortedList<char, string>{
            { '0', "black" },
            { '1', "navy" },
            { '2', "green" },
            { '3', "teal" },
            { '4', "maroon" },
            { '5', "purple" },
            { '6', "olive" },
            { '7', "silver" },
            { '8', "gray" },
            { '9', "blue" },
            { 'a', "lime" },
            { 'b', "aqua" },
            { 'c', "red" },
            { 'd', "magenta" },
            { 'e', "yellow" },
            { 'f', "white" }
        };

        //parses the colorcode
        public static string Parse( char code ) {
            code = Char.ToLower( code );
            if ( IsValidColorCode( code ) ) {
                return "&" + code;
            } else {
                return null;
            }
        }

        //parses the colorname
        public static string Parse( string color ) {
            if ( color == null ) {
                return null;
            }
            color = color.ToLower();
            switch ( color.Length ) {
                case 2:
                    if ( color[0] == '&' && IsValidColorCode( color[1] ) ) {
                        return color;
                    }
                    break;

                case 1:
                    return Parse( color[0] );

                case 0:
                    return "";
            }
            if ( ColorNames.ContainsValue( color ) ) {
                return "&" + ColorNames.Keys[ColorNames.IndexOfValue( color )];
            } else {
                return null;
            }
        }

        //color code to name
        public static string GetName( char code ) {
            code = Char.ToLower( code );
            if ( IsValidColorCode( code ) ) {
                return ColorNames[code];
            }
            string color = Parse( code );
            if ( color == null ) {
                return null;
            }
            return ColorNames[color[1]];
        }

        //name to color code
        public static string GetName( string color ) {
            if ( color == null ) {
                return null;
            } else if ( color.Length == 0 ) {
                return "";
            } else {
                string parsedColor = Parse( color );
                if ( parsedColor == null ) {
                    return null;
                } else {
                    return GetName( parsedColor[1] );
                }
            }
        }

        #endregion ColorParsing

        #region Other

        /// <summary>
        /// The color of the bots name
        /// Default: Red
        /// </summary>
        public static string BotNameColor = "&c";

        #endregion Other

        public static void Load() {
            if ( Settings.ReleaseFlag == Flags.Debug ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: Settings.Load called" );
            }
            if ( !File.Exists( FilePath ) ) {
                Logger.Log( LogType.SystemActivity, "HelperBot: HelperBot.xml was not found. Please configure HelperBot with HelperBot.exe. Using default settings." );
                return;
            } else {
                XmlReader reader = XmlReader.Create( FilePath );

                while ( reader.Read() ) {
                    if ( reader.NodeType == XmlNodeType.Element ) {
                        if ( reader.Name == "AnnounceFly" ) {
                            AnnounceFly = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceServer" ) {
                            AnnounceServerName = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceHours" ) {
                            AnnounceHours = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceRank" ) {
                            AnnounceRank = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceWarnKick" ) {
                            AnnounceWarnKick = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceWarnSwear" ) {
                            AnnounceWarnSwear = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceSuggestBan" ) {
                            AnnounceSuggestBan = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                        }
                        if ( reader.Name == "AnnounceImpersonation" ) {
                            AnnounceImpersonation = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceTime" ) {
                            AnnounceTime = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnouncePM" ) {
                            AnnouncePM = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceFell" ) {
                            AnnounceFell = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceSpleefTimer" ) {
                            AnnounceSpleefTimer = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                        }
                        if ( reader.Name == "AnnounceGreeting" ) {
                            AnnounceGreeting = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceDemoted" ) {
                            AnnounceDemoted = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceJokes" ) {
                            AnnounceJokes = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "AnnounceCaps" ) {
                            AnnounceCaps = Convert.ToBoolean( reader.GetAttribute( 0 ).ToLower() );
                            ;
                        }
                        if ( reader.Name == "BotName" ) {
                            Name = reader.GetAttribute( 0 );
                        }
                        if ( reader.Name == "Website" ) {
                            Website = reader.GetAttribute( 0 );
                        }
                        if ( reader.Name == "BotColor" ) {
                            BotNameColor = Parse( reader.GetAttribute( 0 ) );
                        }
                        if ( reader.Name == "CurrentVersion" ) {
                            XmlVersion = Convert.ToInt32( reader.GetAttribute( 0 ) );
                        }
                    }
                }
                reader.Close();
            }

            if ( Settings.CurrentVersion != Settings.XmlVersion ) {
                Logger.Log( LogType.Error, " HelperBot: Warning, HelperBot.xml was made for a different version than your current HelperBot program. Please configure your new HelperBot.xml in HelperBot.exe" );
            }
        }
    }
}