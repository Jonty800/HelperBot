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

<<<<<<< HEAD
=======
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
>>>>>>> df0918acae3205799af5d3f587980cc1ed7e5095
        static String[] JokeTrigger = new String[]
        {
           "joke"
        };

<<<<<<< HEAD
        static String[] JokeTrigger2 = new String[]
=======
        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        static String[] JokeTrigger2 = new String[] //no point in these two if the first one is just 'joke'
>>>>>>> df0918acae3205799af5d3f587980cc1ed7e5095
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
<<<<<<< HEAD

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
=======
        public static String[][] SpleefFullTrigger = new String[][]
        {
            SpleefTrigger
        };
>>>>>>> df0918acae3205799af5d3f587980cc1ed7e5095
        public static String[][] JokeFullTrigger = new String[][]
        {
            JokeTrigger,
            JokeTrigger2,
            JokeTrigger3
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
