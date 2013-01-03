//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fCraft;

namespace HelperBot {
    /// <summary>
    /// This class will be used to store constant values, such as XML values and arrays of replies
    /// </summary>
    public static class Constants {

        /// <summary>
        /// The name of the bot
        /// Deafult: Alice
        /// </summary>
        public static string Name = "Alice";

        #region Personality (Maybe)
        public static int Age = 21;
        public static string Hometown = "London, England";
        public static string Sex = "female";
        public static string Occupation = "being a Bot";
        #endregion

        /// <summary>
        /// An array of RandomMessages to be said on a very long delayed timer - maybe 20mins
        /// </summary>
        public static string[] RandomMessage = new string[]
        {

        };

        /// <summary>
        /// An array of thankyou replies to send back to the player
        /// </summary>
        public static string[] ThankyouReplies = new string[]
        {

        };

        /// <summary>
        /// An array of jokes
        /// </summary>
        public static string[] Jokes = new string[]
        {

        };

        /// <summary>
        /// An array of positive comments that the bot can add onto the end of a message
        /// Examples: "How cool is that?", "Awesome sauce"
        /// </summary>
        public static string[] PositiveComments = new string[]
        {

        };

        /// <summary>
        /// An array of nagative comments that the bot can add onto the end of a message
        /// Examples: "I don't like that behavior", "Please don't do it again"
        /// </summary>
        public static string[] NegativeComments = new string[]
        {

        };
    }
}
