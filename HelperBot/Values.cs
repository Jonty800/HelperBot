//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares
using System;
using System.Collections.Generic;
using fCraft;

/*        ____
         [____]   ____
          )__(   [____]
         /    \   )__(
        | .--. | /    \
        | '--' || .--. |
        |      || '--' |
        |      ||      |
        |      ||      |
        '.____.'|      |
                '.____.'*/

namespace HelperBot {

    /// <summary>
    /// This class will be used to store constant values, such as arrays of replies
    /// </summary>
    ///
    public static class Values {

        /// <summary>
        /// The name of the bot, colored using Settings.BotNameColor
        /// </summary>
        /// <returns>Settings.BotNameColor + Name;</returns>
        public static string ClassyName {
            get { return Settings.BotNameColor + Settings.Name; }
        }

        public struct TYObject {
            public Player player;
            public DateTime Time;
        }

        public static List<TYObject> AwaitingThanks = new List<TYObject>();

        public static PlayerInfo FirstJoined;
        public static PlayerInfo OldestStaff;
        public static PlayerInfo FirstBanned;
        public static PlayerInfo FirstKicked;
        public static PlayerInfo MostBans;
        public static PlayerInfo MostKicks;
        public static PlayerInfo MostPromoted;
        public static PlayerInfo MostBuilt;
        public static PlayerInfo MostTimesGotKicked;
        public static PlayerInfo MostHours;
        public static PlayerInfo MostMessagesSent;
        public static PlayerInfo MostBlocksDrawn;
        public static PlayerInfo NewestStaff;
        public static PlayerInfo MostLogins;

        /// <summary>
        /// An array of RandomMessages to be sent to staff chat to report certain stats
        /// </summary>
        public static string[] RandStaffMessage = new string[]
        {
            //silly idea lulz
        };

        /// <summary>
        /// An array of RandomMessages to be said on a very long delayed timer - maybe 20mins
        /// We can probably use this for the same thing as automated server messages
        /// </summary>
        public static string[] RandomMessage = new string[]
        {
            //what is this for again?
        };

        /// <summary>
        /// An array of thankyou replies to send back to the player
        /// </summary>
        public static string[] ThankyouReplies = new string[]
        {
          "No problem",
          "You're Welcome",
          "Anytime!",
          "I'm here for you",
          "Only for you",
          "Np",
          "Yw",
          "^.^"
        };

        /// <summary>
        /// An array of jokes
        /// </summary>
        public static string[] Jokes = new string[]
        {
         "Schrodinger's Cat: Wanted dead and alive.",
         "Light travels faster than sound. This is why some people appear bright until you hear them speak.",
         "War does not determine who is right - only who is left...",
         "Never hit a man with glasses. Hit him with a baseball bat instead.",
         "Energizer Bunny was arrested, charged with battery.",
         "I usually take steps to avoid elevators.",
         "You do not need a parachute to skydive. You only need a parachute to skydive twice.",
         "I bet you I could stop gambling!",
         "We never really grow up, we only learn how to act in public.",
         "If God is watching us, the least we can do is be entertaining.",
         "Better to remain silent and be thought a fool, than to speak and remove all doubt.",
         "How is it one careless match can start a forest fire, but it takes a whole box to start a campfire?",
         "Did you know that dolphins are so smart that within a few weeks of captivity, they can train people to stand on the very edge of the pool and throw them fish?",
         "Never, under any circumstances, take a sleeping pill and a laxative on the same night.",
         "A clear conscience is usually the sign of a bad memory.",
         "Laugh at your problems, everybody else does.",
         "It's not the fall that kills you; it's the sudden stop at the end.",
         "Hospitality: making your guests feel like they're at home, even if you wish they were.",
         "I used to be indecisive. Now I'm not sure.",
         "Nostalgia isn't what it used to be."
        };

        /// <summary>
        /// An array of positive comments that the bot can add onto the end of a message
        /// Examples: "How cool is that?", "Awesome sauce"
        /// </summary>
        public static string[] PositiveComments = new string[]
        {
         "Perfect!",
         "AwesomeSauce!",
         "Well done!",
         "Great job!",
         "You're on fire!",
         "Way to go!"
        };

        /// <summary>
        /// An array of negative comments that the bot can add onto the end of a message
        /// Examples: "I don't like that behavior", "Please don't do it again"
        /// </summary>
        public static string[] NegativeComments = new string[]
        {
         "Please stop doing that.",
         "Stahp!",
         "Not cool bro!",
         "I don't think that was very smart...", //unsure
         "That wasn't a good idea now was it?" // unsure
         //@Jonty800 I noticed that you swore in a private message + That wasn't a good idea now was it?
        };
    }
}