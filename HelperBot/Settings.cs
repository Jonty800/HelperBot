//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

//NOTE: I am not happy with this class, I need to rethink and rewrite it
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using fCraft;
using fCraft.Events;

namespace HelperBot {
    public enum Flags {
        Debug,
        Release
    }

    public static class Settings {

        public static Flags ReleaseFlag = Flags.Debug;

        #region XML settings
        /// <summary>
        /// Current version of the config file and xml file
        /// </summary>
        public static int CurrentVersion = 1;
        public static int XmlVersion = 1;

        /// <summary>
        /// The XML root name
        /// </summary>
        const string ConfigXmlRootName = "HelperBotConfig"; //unneeded?

        /// <summary>
        /// The location of the XML file
        /// </summary>
        const string FilePath = "plugins/HelperBot.xml";

        #endregion

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
        /// Sends random messages to staff about important server stats, and sends misc messages in global chat
        /// </summary>
        public static bool AnnounceRandomMessages = true;

        /// <summary>
        /// Explains how to use PM
        /// </summary>
        public static bool AnnouncePM = true;

        /// <summary>
        /// Explains how to return to spawn (r)
        /// </summary>
        public static bool AnnounceFell= true;

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


        #endregion

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
        /// String value for "I got demoted" reply
        /// </summary>
        public static string DemotedMessage = "&F, if you were wrongfully demoted you can appeal at " + Website;

        /// <summary>
        /// String value for "I am stuck" reply
        /// </summary>
        public static string StuckMessage = "&F, if you are stuck press R to respawn";

     

        #region Personality (Maybe)
        public static int Age = 21;
        public static string Hometown = "London, England";
        public static string Sex = "female";
        public static string Occupation = "botting 'n stuff"; //My occupation is + Occupation (lowercase starting)
        #endregion

        #endregion

        #region Other
        /// <summary>
        /// The color of the bots name
        /// Default: Red
        /// </summary>
        public static string BotNameColor = "%c";
        #endregion

        public static void Load()
        {
            if (Settings.ReleaseFlag == Flags.Debug)
            {
                Logger.Log(LogType.SystemActivity, "HelperBot: Settings.Load called");
            }
            if (!File.Exists(FilePath))
            {
                Logger.Log(LogType.SystemActivity, "HelperBot: HelperBot.xml was not found. Please configure HelperBot with HelperBot.exe. Using default settings.");               
                return;
            }

            else
            {
                 XmlReader reader = XmlReader.Create(FilePath);

                 while (reader.Read())
                 {
                     if (reader.NodeType == XmlNodeType.Element)
                     {
                         if (reader.Name == "AnnounceFly")
                         {
                             AnnounceFly = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceServer")
                         {
                             AnnounceServerName = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceHours")
                         {
                             AnnounceHours = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceRank")
                         {
                             AnnounceRank = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceWarnKick")
                         {
                             AnnounceWarnKick = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceWarnSwear")
                         {
                             AnnounceWarnSwear = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceSuggestBan")
                         {
                             AnnounceSuggestBan = Convert.ToBoolean(reader.GetAttribute(0).ToLower());
                         }
                         if (reader.Name == "AnnounceImpersonation")
                         {
                             AnnounceImpersonation = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceTime")
                         {
                             AnnounceTime = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceRandomMessages")
                         {
                             AnnounceRandomMessages = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnouncePM")
                         {
                             AnnouncePM = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceFell")
                         {
                             AnnounceFell = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceSpleefTimer")
                         {
                             AnnounceSpleefTimer = Convert.ToBoolean(reader.GetAttribute(0).ToLower());
                         }
                         if (reader.Name == "AnnounceGreeting")
                         {
                             AnnounceGreeting = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceDemoted")
                         {
                             AnnounceDemoted = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceJokes")
                         {
                             AnnounceJokes = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "AnnounceCaps")
                         {
                             AnnounceCaps = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                         }
                         if (reader.Name == "BotName")
                         {
                             Name = reader.GetAttribute(0);
                         }
                         if (reader.Name == "Website")
                         {
                             Website = reader.GetAttribute(0);
                         }
                         if (reader.Name == "BotColor")
                         {
                             BotNameColor = Color.Parse(reader.GetAttribute(0)); ;
                         }
                         if (reader.Name == "CurrentVersion")
                         {
                             XmlVersion = Convert.ToInt32(reader.GetAttribute(0));
                         }  
                     }                    
                 }
                 reader.Close();
            }

            if (Settings.CurrentVersion != Settings.XmlVersion)
            {
                Logger.Log(LogType.Error, " HelperBot: Warning, HelperBot.xml was made for a different version than your current HelperBot program. Please configure your new HelperBot.xml in HelperBot.exe");
            }
        }
    }
}
