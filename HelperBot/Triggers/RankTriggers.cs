//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperBot {
    public static class RankTriggers {

        static String[] NextRankTrigger = new String[]
        {
           "what",
           "my",
           "next",
           "rank"
        };

        static String[] HowDoTrigger1 = new String[]
        {
           "how",
           "get",
           "ranks"
        };

        static String[] HowDoTrigger2 = new String[]
        {
           "how",
           "get",
           "ranked"
        };

        static String[] HowDoTrigger3 = new String[]
        {
           "how",
           "get",
           "promoted"
        };

        static String[] HowDoTrigger4 = new String[]
        {
           "how",
           "do",
           "promoted"
        };

        public static String[][] NextRankFullTrigger = new String[][]
        {
            NextRankTrigger
        };

        public static String[][] HowDoFullTrigger = new String[][]
        {
            HowDoTrigger1,
            HowDoTrigger2,
            HowDoTrigger3,
            HowDoTrigger4
        };
    }
}
