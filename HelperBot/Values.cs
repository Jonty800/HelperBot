//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fCraft;

namespace HelperBot {
    /// <summary>
    /// This class will be used to store constant values, such as arrays of replies
    /// </summary>
    public static class Values {
        /// <summary>
        /// The name of the bot, colored using Settings.BotNameColor
        /// </summary>
        /// <returns>Settings.BotNameColor + Name;</returns>
        public static string ClassyName {
            get { return Settings.BotNameColor + Settings.Name; }
        }

        #region Personality (Maybe)
        public static int Age = 21;
        public static string Hometown = "London, England";
        public static string Sex = "female";
        public static string Occupation = "botting 'n stuff"; //My occupation is + Occupation (lowercase starting)
        #endregion

        /// <summary>
        /// An array of RandomMessages to be said on a very long delayed timer - maybe 20mins
        /// We can probably use this for the same thing as automated server messages
        /// </summary>
        public static string[] RandomMessage = new string[]
        {

        };

        /// <summary>
        /// An array of thankyou replies to send back to the player
        /// </summary>
        public static string[] ThankyouReplies = new string[]
        { 
          "No problem",
          "You're Welcome",
          "Anytime :P",
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
         "War does not determine who is right – only who is left...",
         "Never hit a man with glasses. Hit him with a baseball bat instead.",
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
