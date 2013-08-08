//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

using System;

namespace HelperBot {

    public static class RankTriggers {

        private static String[] DemotedTrigger = new String[]
        {
           "i",
           "was",
           "demoted"
        };

        private static String[] DemotedTrigger2 = new String[]
        {
           "i",
           "got",
           "demoted"
        };

        private static String[] NextRankTrigger = new String[]
        {
           "what",
           "my",
           "next",
           "rank"
        };

        private static String[] HowDoTrigger1 = new String[]
        {
           "how",
           "get",
           "ranks"
        };

        private static String[] HowDoTrigger2 = new String[]
        {
           "how",
           "get",
           "ranked"
        };

        private static String[] HowDoTrigger3 = new String[]
        {
           "how",
           "get",
           "promoted"
        };

        private static String[] HowDoTrigger4 = new String[]
        {
           "how",
           "do",
           "promoted"
        };

        public static String[][] DemotedFullTrigger = new String[][]
        {
            DemotedTrigger,
            DemotedTrigger2
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