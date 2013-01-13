//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//May rename/move when other trigger files are created

namespace HelperBot {
    public static class MiscTriggers {
        
        //I'll throw some funfacts from RandomStat.cs later
        static String[] FlyTrigger = new String[]
        {
           "how",
           "fly"
        };

        static String[] FlyTrigger2 = new String[]
        {
           "help",
           "fly"
        };
        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        static String[] SpleefTrigger = new String[]
        {
            "spleef"
        };

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        static String[] JokeTrigger = new String[]
        {
           "joke"
        };

        public static String[][] SpleefFullTrigger = new String[][]
        {
            SpleefTrigger
        };

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        public static String[][] JokeFullTrigger = new String[][]
        {
            JokeTrigger
        };
        public static String[][] FlyFullTrigger = new String[][]
        {
            FlyTrigger,
            FlyTrigger2,
        };

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        public static String[][] FunFactTrigger = new String[][]
        {
            new String[]{"fun", "fact"}
        };

    }
}
