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

        static String[] JokeTrigger = new String[]
        {
           "joke"
        };

        static String[] JokeTrigger2 = new String[]
        {
           "tell",
           "a",
           "joke"
        };

        static String[] JokeTrigger3 = new String[]
        {
           "say",
           "a",
           "joke"
        };

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        public static String[][] JokeFullTrigger = new String[][]
        {
            JokeTrigger,
            JokeTrigger2,
            JokeTrigger3
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
