//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fCraft;

namespace HelperBot
{
    /// <summary>
    /// A collection of static methods used for the bot
    /// </summary>
    class Methods
    {
        #region Chat

        /// <summary>
        /// Send a message without the need of a player name (DO NOT use this for PMs)
        /// </summary>
        public static void SendMessage(string Message, MessageChannel Channel)
        {
            SendMessage(null, Message, Channel);
        }

        /// <summary>
        /// Send a message
        /// </summary>
        public static void SendMessage(Player player, string Message, MessageChannel Channel)
        {
            switch (Channel)
            {
                case MessageChannel.Admin:
                    //TODO
                    break;
                case MessageChannel.Global:
                    SendChat(Message);
                    break;
                case MessageChannel.Me:
                    //TODO
                    break;
                case MessageChannel.PM:
                    SendPM(player, Message);
                    break;
                case MessageChannel.Staff:
                    SendStaff(Message);
                    break;
            }
        }


        /// <summary>
        /// Send a personal message to a player
        /// </summary>
        /// <param name="player">The player object of the target. Cannot be null</param>
        /// <param name="msg">The message to send to the target, cannot be null or 0 length</param>
        public static void SendPM(Player player, string msg)
        {
            if (Settings.ReleaseFlag == Flags.Debug)
            {
                Logger.Log(LogType.SystemActivity, "HelperBot: SendPM Method");
            }
            if (player == null)
            {
                SendError(player, "HelperBot: Player cannot be null", MessageChannel.PM);
                return;
            }
            if (msg == null)
            {
                SendError(player, "HelperBot: Msg cannot be null", MessageChannel.PM);
                return;
            }
            if (msg.Length < 1)
            {
                SendError(player, "HelperBot: Msg cannot be 0-length", MessageChannel.PM);
                return;
            }
            player.Message("{0}from {1}: {2}", Color.PM, Settings.Name, msg);
        }

        /// <summary>
        /// Send a global server message
        /// </summary>
        /// <param name="msg">The message to send to the server, cannot be null or 0 length</param>
        public static void SendChat(string msg)
        {
            if (Settings.ReleaseFlag == Flags.Debug)
            {
                Logger.Log(LogType.SystemActivity, "HelperBot: SendChat Method");
            }
            if (msg == null)
            {
                SendError("HelperBot: Msg cannot be null", MessageChannel.Global);
                return;
            }
            if (msg.Length < 1)
            {
                SendError("HelperBot: Msg cannot be 0-length", MessageChannel.Global);
                return;
            }
            msg = Color.ReplacePercentCodes(msg);
            Server.Players.Message("{0}&F: {1}", Values.ClassyName, msg);
        }

        /// <summary>
        /// Send a message in the staff chat channel
        /// </summary>
        /// <param name="msg">The message to send to the staff, cannot be null or 0 length</param>
        public static void SendStaff(string msg)
        {
            if (Settings.ReleaseFlag == Flags.Debug)
            {
                Logger.Log(LogType.SystemActivity, "HelperBot: SendStaff Method");
            }
            if (msg == null)
            {
                SendError("HelperBot: Msg cannot be null", MessageChannel.Staff);
                return;
            }
            if (msg.Length < 1)
            {
                SendError("HelperBot: Msg cannot be 0-length", MessageChannel.Staff);
                return;
            }
            msg = Color.ReplacePercentCodes(msg);
            Server.Players.Can(Permission.ReadStaffChat).Message("{0}(staff){1}{2}: {3}",
                Color.PM, Values.ClassyName, Color.PM, msg);
        }

        public static void SendError(Exception e, MessageChannel Channel)
        {
            SendError(null, e.Message, Channel);
        }

        public static void SendError(String Msg, MessageChannel Channel)
        {
            if (Channel != MessageChannel.Logger)
            {
                SendError(null, Msg, Channel);
            }
            else
            {
                Logger.Log(LogType.Error, Msg);
            }
        }

        public static void SendError(Player player, String Msg, MessageChannel Channel)
        {
            if (player != null)
            {
                SendMessage(player, "&WError!!! " + Msg, Channel);
            }
            else
            {
                SendMessage("&WError!!! " + Msg, Channel);
            }
        }
        #endregion

        #region Detection

        /// <summary>
        /// Checks if the player has changed his displayedName to the bots
        /// </summary>
        /// <param name="player">Player in question</param>
        /// <returns>true if the displayednames are the same</returns>
        public static bool IsPlayersDisplayedNameBots(Player player)
        {
            if (Settings.ReleaseFlag == Flags.Debug)
            {
                Logger.Log(LogType.SystemActivity, "HelperBot: IsPlayersDisplayedNameBots Method");
            }
            if (player == null)
                return false;
            if (player.Info.DisplayedName == null)
                return false;
            if (player.Info.DisplayedName == Values.ClassyName)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if a player is impersonating a bot
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>true if the player is suspected of impersonation</returns>
        public static bool DetectMessageImpersonation(string Message)
        {
            if (Settings.ReleaseFlag == Flags.Debug)
            {
                Logger.Log(LogType.SystemActivity, "HelperBot: DetectMessageImpersonation Method");
            }
            if (Message == null)
                SendError("HelperBot: Message cannot be null", MessageChannel.Logger);
            Message = Color.StripColors(Message);
            //Say impersonation
            if (Message.StartsWith(Color.StripColors(Values.ClassyName + ":")))
                return true;
            //staff impersonation
            if (Message.StartsWith(Color.StripColors("(staff)" + Values.ClassyName + ":")))
                return true;
            //adminchat impersonation
            if (Message.StartsWith(Color.StripColors("(admin)" + Values.ClassyName + ":")))
                return true;
            //me impersonation
            if (Message.StartsWith(Color.StripColors("*" + Values.ClassyName)))
                return true;
            //PM impersonation
            if (Message.StartsWith(Color.StripColors("@" + Values.ClassyName)))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Does the String contain the bots name?
        /// </summary>
        /// <param name="Message">Message in question</param>
        /// <returns>true if it does</returns>
        public static bool ContainsBotName(String Message)
        {
            if (Message == null)
                SendError("HelperBot: Message cannot be null", MessageChannel.Logger);
            Message = Message.ToLower();
            return Message.Contains(Settings.Name.ToLower());
        }

        #endregion

        /// <summary>
        /// Gets a random statistic and returns the string message that the player will recieve
        /// TODO write the return messages
        /// </summary>
        /// <param name="player">The player in question [NotNull]</param>
        /// <returns>A string message containing the statistical information</returns>
        public static string GetRandomStatString(Player player)
        {
            if (Settings.ReleaseFlag == Flags.Debug)
            {
                Logger.Log(LogType.SystemActivity, "HelperBot: GetRandomStatString Method");
            }
            if (player == null) SendError("HelperBot: Player cannot be null", MessageChannel.Global);
            byte Max = 13; //Max enum byte
            int StringID = new Random().Next(0, Max);
            if (Settings.ReleaseFlag == Flags.Debug) SendChat(StringID.ToString());
            RandomStat Picked = (RandomStat)StringID;
            if (Settings.ReleaseFlag == Flags.Debug) SendChat(Picked.ToString());
            switch (Picked)
            {
                case RandomStat.FirstPersonBanned:
                    try
                    {
                        if (Values.FirstBanned.ClassyName == null)
                        {
                            return "No one has been banned on this server.... yet";
                        }
                        return "The first person to get banned on this server was " + Values.FirstBanned.ClassyName;
                    }
                    catch (NullReferenceException)
                    {
                        return "No one has been banned on this server.... yet";
                    }
                case RandomStat.FirstPersonKicked:
                    if (Values.FirstKicked == null)
                    {
                        return "No one has been kicked on this server";
                    }
                    return "The first person to get kicked on this server was " + Values.FirstKicked.ClassyName;
                case RandomStat.MostBanned:
                    if (Values.MostBans == null)
                    {
                        return "It appears that staff haven't banned anyone yet on this server... Unbeliveable!";
                    }
                    return "The person with the most bans on this server is " + Values.MostBans.ClassyName;
                case RandomStat.MostBlocksDrawn:
                    if (Values.MostBlocksDrawn == null)
                    {
                        return "No one has drawn a block yet on this server";
                    }
                    return "The person who has drawn the most blocks is " + Values.MostBlocksDrawn.ClassyName;
                case RandomStat.MostBuilt:
                    if (Values.MostBuilt == null)
                    {
                        return "Not a single soul has placed a block on this server yet... sigh!";
                    }
                    return "The person who has placed the most blocks is " + Values.MostBuilt.ClassyName;
                case RandomStat.MostHours:
                    if (Values.MostHours == null) return "No players have achieved 1 whole hour on this server :(";
                    return "The person with the most hours on this server is " + Values.MostHours.ClassyName;
                case RandomStat.MostKicked:
                    if (Values.MostKicks == null)
                    {
                        return "No one has been kicked on this server";
                    }
                    return "The person with the most kicks on this server is " + Values.MostKicks.ClassyName;
                case RandomStat.MostLogins:
                     if (Values.MostLogins == null) return "No one has the most log ins!!";
                    return Values.MostLogins.ClassyName + "&F has connected to the server the most number of times";
                case RandomStat.MostMessagesSent:
                    try
                    {
                        if (Values.MostMessagesSent == null) return "No one has sent the most messages yet!";
                        return Values.MostMessagesSent.ClassyName + "&F has sent the most number of messages on the server";
                    }
                    catch (NullReferenceException)
                    {
                        return "No one has sent the most messages yet!";
                    }
                case RandomStat.MostPromoted:
                    if (Values.MostPromoted == null) return "No one has been promoted on this server yet :S";
                    return Values.MostPromoted.ClassyName + "&F has promoted the more people on this server than anyone else!";
                case RandomStat.MostTimesGotKicked:
                    if (Values.MostTimesGotKicked == null) return "No one has been kicked on this server";
                    return Values.MostTimesGotKicked.ClassyName + "&F has cbeen kicked more times than anyone else on this server";
                case RandomStat.NewestStaff:
                    try
                    {
                        if (Values.NewestStaff == null) return "This sever has no staff!";
                        return Values.MostBans.ClassyName + "&F is the newest member of staff";
                    }
                    catch (NullReferenceException)
                    {
                        return "This sever has no staff!";
                    }
                case RandomStat.OldestStaff:
                    if (Values.OldestStaff == null) return "This sever has no staff!";
                    return "Our oldest active staff member is " + Values.OldestStaff.ClassyName;
                case RandomStat.FirstJoined:
                    //cannot be null
                    return "The first person to join the server was " +
                        Values.FirstJoined.ClassyName + "&Fon " + Values.FirstJoined.FirstLoginDate +
                        " (" + Values.FirstJoined.TimeSinceFirstLogin.ToMiniString() + " ago).";
                default: return null; //shouldn't happen
            }
        }

        public static MessageChannel ParseChatType(ChatMessageType MessageType)
        {
            switch (MessageType)
            {
                case ChatMessageType.Global:
                    return MessageChannel.Global;
                case ChatMessageType.Me:
                    return MessageChannel.Me;
                case ChatMessageType.PM:
                    return MessageChannel.PM;
                case ChatMessageType.Staff:
                    return MessageChannel.Staff;
                default: return MessageChannel.Admin;
            }
        }

        public static String GetPlayerTotalHoursString(Player player)
        {
            TimeSpan totalTime = player.Info.TotalTime;
            return player.ClassyName + "&F, you have spent " +
                Math.Round(totalTime.TotalHours, 0, MidpointRounding.AwayFromZero) + " hours (" +
                 Math.Round(totalTime.TotalMinutes, 0, MidpointRounding.AwayFromZero) +
                " minutes) here.";
        }

        public static string GetRandomJoke()
        {
            return Values.Jokes[new Random().Next(0, Values.Jokes.Length)];
        }

        public static void SetAllValues()
        {
            SetFirstJoined();
            SetFirstBanned();
            SetOldestStaff();
            LoadSwearArray();
            SetFirstKicked();
            SetMostBans();
            SetMostKicks();
            SetMostPromoted();
            SetMostBuilt();
            SetMostTimesGotKicked();
            SetMostHours();
            SetMostMessagesSent();
            SetMostBlocksDrawn();
            SetNewestStaff();
            SetMostLogins();
        }

        public static void AddTYPlayer(Player player)
        {
            if (Values.AwaitingThanks == null) return;
            Values.TYObject _TYObject = new Values.TYObject() { player = player, Time = DateTime.Now };
            lock (Values.AwaitingThanks)
            {
                if (Values.AwaitingThanks.Contains(_TYObject)) return;
                Values.AwaitingThanks.Add(_TYObject);
            }
        }

        public static void RemoveTYPlayer(Player player)
        {
            if (Values.AwaitingThanks == null) return;
            if (Values.AwaitingThanks.Count < 1) return;
            lock (Values.AwaitingThanks)
            {
                for (int i = Values.AwaitingThanks.Count - 1; i >= 0; i--)
                {
                    if (Values.AwaitingThanks[i].player == player)
                    {
                        Values.AwaitingThanks.RemoveAt(i);
                    }
                }
            }
        }

        #region SetValues
        public static void LoadSwearArray()
        {
            if (MaintenanceTriggers.SwearFullTrigger == null)
            {
                MaintenanceTriggers.SwearFullTrigger = new String[][] { System.IO.File.ReadAllLines(MaintenanceTriggers.swearFile.FullName) };
            }
        }

        public static void SetFirstJoined()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                Logger.Log(LogType.Error, "HelperBot: PlayerInfoList is null @ SetFirstJoined");
                return;
            }
            Values.FirstJoined = PlayerDB.PlayerInfoList.OrderBy(pi => pi.FirstLoginDate).FirstOrDefault(pi => pi.FirstLoginDate != DateTime.MinValue);
        }

        public static void SetOldestStaff()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                Logger.Log(LogType.Error, "HelperBot: PlayerInfoList is null @ SetOldestStaff");
                return;
            }
            Values.OldestStaff = PlayerDB.PlayerInfoList.Where(p => p.Can(Permission.ReadStaffChat)).OrderByDescending(pi => pi.FirstLoginDate).FirstOrDefault(pi => pi.FirstLoginDate != DateTime.MinValue);
        }

        public static void SetFirstBanned()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                Logger.Log(LogType.Error, "HelperBot: PlayerInfoList is null @ SetFirstBanned");
                return;
            }
            Values.FirstBanned = PlayerDB.PlayerInfoList.Where(p => p.IsBanned).OrderByDescending(pi => pi.BanDate).FirstOrDefault(pi => pi.BanDate != DateTime.MinValue);
        }
        public static void SetFirstKicked()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                Logger.Log(LogType.Error, "HelperBot: PlayerInfoList is null @ SetFirstKicked");
                return;
            }
            Values.FirstKicked = PlayerDB.PlayerInfoList.Where(p => p.LastKickDate != null).OrderByDescending(pi => pi.LastKickDate).FirstOrDefault(pi => pi.LastKickDate != DateTime.MinValue);
        }

        public static void SetMostBans()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                Logger.Log(LogType.Error, "HelperBot: PlayerInfoList is null @ SetMostBans");
                return;
            }
            Values.MostBans = PlayerDB.PlayerInfoList.Where(p => p.TimesBannedOthers != 0).OrderByDescending(pi => pi.TimesBannedOthers).FirstOrDefault(pi => pi.TimesBannedOthers != 0);
        }

        public static void SetMostKicks()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                Logger.Log(LogType.Error, "HelperBot: PlayerInfoList is null @ SetMostKicks");
                return;
            }
            Values.MostKicks = PlayerDB.PlayerInfoList.Where(p => p.TimesKickedOthers != 0).OrderByDescending(pi => pi.TimesKickedOthers).FirstOrDefault(pi => pi.TimesKickedOthers != 0);
        }

        public static void SetNewestStaff()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                return;
            }
            Values.NewestStaff = PlayerDB.PlayerInfoList.Where(p => p.Can(Permission.ReadStaffChat)).OrderByDescending(pi => pi.RankChangeDate).FirstOrDefault(pi => pi.RankChangeDate != null);
        }

        public static void SetMostTimesGotKicked()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                return;
            }
            Values.MostTimesGotKicked = PlayerDB.PlayerInfoList.Where(p => p.TimesKicked > 0).OrderByDescending(pi => pi.TimesKicked).FirstOrDefault(pi => pi.TimesKicked > 0);
        }

        public static void SetMostPromoted()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                return;
            }
            Values.MostPromoted = PlayerDB.PlayerInfoList.Where(p => p.PromoCount > 0).OrderByDescending(pi => pi.PromoCount).FirstOrDefault(pi => pi.PromoCount > 0);
        }

        public static void SetMostMessagesSent()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                return;
            }
            Values.MostMessagesSent = PlayerDB.PlayerInfoList.Where(p => p.MessagesWritten > 0).OrderByDescending(pi => pi.MessagesWritten).FirstOrDefault(pi => pi.MessagesWritten > 0);
        }

        public static void SetMostLogins()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                return;
            }
            Values.MostLogins = PlayerDB.PlayerInfoList.Where(p => p.TimesVisited > 0).OrderByDescending(pi => pi.TimesVisited).FirstOrDefault(pi => pi.TimesVisited > 0);
        }

        public static void SetMostHours()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                return;
            }
            Values.MostHours = PlayerDB.PlayerInfoList.Where(p => p.TotalTime.TotalHours > 0).OrderByDescending(pi => pi.TotalTime.TotalHours).FirstOrDefault(pi => pi.TotalTime.TotalHours > 0);
        }

        public static void SetMostBuilt()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                return;
            }
            Values.MostBuilt = PlayerDB.PlayerInfoList.Where(p => p.BlocksBuilt > 0).OrderByDescending(pi => pi.BlocksBuilt).FirstOrDefault(pi => pi.BlocksBuilt > 0);
        }

        public static void SetMostBlocksDrawn()
        {
            if (PlayerDB.PlayerInfoList == null)
            {
                return;
            }
            Values.MostBlocksDrawn = PlayerDB.PlayerInfoList.Where(p => p.BlocksDrawn > 0).OrderByDescending(pi => pi.BlocksDrawn).FirstOrDefault(pi => pi.BlocksDrawn > 0);
        }
        #endregion

        public static string GetRandomPosComment()
        {
            return Values.PositiveComments[new Random().Next(0, Values.PositiveComments.Length)];
        }
    }
}
