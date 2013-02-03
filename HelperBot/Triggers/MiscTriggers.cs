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
        
        static String[] ThanksTrigger = new String[]
        {
           "Ty"
        };

        static String[] ThanksTrigger2 = new String[]
        {
           "Thanks"
        };
        static String[] ThanksTrigger3 = new String[]
        {
           "Thx"
        };
        static String[] ThanksTrigger4 = new String[]
        {
           "Thankyou"
        };
        static String[] ThanksTrigger5 = new String[]
        {
           "Thank you"
        };
        static String[] ThanksTrigger6 = new String[]
        {
           "Thank9you"
        };
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

        public static String[][] ThanksFullTrigger = new String[][]
        {
            ThanksTrigger,
            ThanksTrigger2,
            ThanksTrigger3,
            ThanksTrigger4,
            ThanksTrigger5,
            ThanksTrigger6
        };
        public static String[][] SpleefFullTrigger = new String[][]
        {
            new String[]{"!spleef"}
        };

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        public static String[][] JokeFullTrigger = new String[][]
        {
            new String[]{"joke"}
        };

        public static String[][] FlyFullTrigger = new String[][]
        {
            FlyTrigger,
            FlyTrigger2
        };

        /// <summary>
        /// This requres the MatchesNameAndTrigger method
        /// </summary>
        public static String[][] FunFactFullTrigger = new String[][]
        {
            new String[]{"fun", "fact"}
        };

    }
}
