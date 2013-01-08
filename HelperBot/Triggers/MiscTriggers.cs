//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//May rename/move when other trigger files are created

namespace HelperBot {
    public static class MiscTriggers {
        
        static String[] FellTrigger = new String[]
        {
           "i",
           "fell" 
        };
        static String[] FellTrigger2 = new String[]
        {
           "i",
           "am",
           "stuck"
        };

        static String[] FellTrigger3 = new String[]
        {
           "i'm",
           "stuck"
        };

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        static String[] JokeTrigger = new String[]
        {
           "joke"
        };

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        static String[] JokeTrigger2 = new String[]
        {
           "tell",
           "a",
           "joke"
        };

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        static String[] JokeTrigger3 = new String[]
        {
           "say",
           "a",
           "joke"
        };

        static String[] WebTrigger = new String[]
        {
           "what",
           "website"
        };

        static String[] WebTrigger2 = new String[]
        {
           "server",
           "website"
        };

        static String[] ServTrigger = new String[]
        {
           "what",
           "server"
        };

        static String[] ServTrigger2 = new String[]
        {
            "what",
           "this",
           "server"
        };


        public static String[][] FellFullTrigger = new String[][]
        {
            FellTrigger,
            FellTrigger2,
            FellTrigger3
        };
        public static String[][] JokeFullTrigger = new String[][]
        {
            JokeTrigger,
            JokeTrigger2,
            JokeTrigger3
        };
        public static String[][] WebFullTrigger = new String[][]
        {
            WebTrigger,
            WebTrigger2
        };
        public static String[][] ServFullTrigger = new String[][]
        {
            ServTrigger,
            ServTrigger2
        };
    }
}
