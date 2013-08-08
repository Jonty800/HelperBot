//HelperBot - Copyright (c) Jonty800 and LeChosenOne <2013> (http://forums.au70.net)
//This plugin is open source and designed to be used with 800Craft and LegendCraft server softwares

using System;
using System.IO;

//May rename/move when other trigger files are created

namespace HelperBot {

    public static class MaintenanceTriggers {

        private static String[] FellTrigger = new String[]
        {
           "i",
           "fell"
        };

        private static String[] FellTrigger2 = new String[]
        {
           "i",
           "am",
           "stuck"
        };

        private static String[] FellTrigger3 = new String[]
        {
           "i'm",
           "stuck"
        };

        private static String[] WebTrigger = new String[]
        {
           "what",
           "website",
           "this"
        };

        private static String[] WebTrigger2 = new String[]
        {
           "what",
           "server",
           "website"
        };

        private static String[] ServTrigger = new String[]
        {
           "what",
           "server",
           "name"
        };

        private static String[] ServTrigger2 = new String[]
        {
            "what",
           "this",
           "server"
        };

        public static FileInfo swearFile = new FileInfo( "swearwords.txt" );

        private static String[] HoursTrigger = new String[]
        {
           "how",
           "many",
           "hours",
           "have"
        };

        private static String[] HoursTrigger2 = new String[]
        {
           "are",
           "my",
           "hours"
        };

        private static String[] PMTrigger = new String[]
        {
           "how",
           "pm"
        };

        private static String[] PMTrigger2 = new String[]
        {
           "how",
           "whisper"
        };

        public static String[][] PMFullTrigger = new String[][]
        {
            PMTrigger,
            PMTrigger2
        };

        public static String[][] TimeFullTrigger = new String[][]
        {
            new String[]{"what", "is", "the", "time"}
        };

        public static String[][] SwearFullTrigger;

        public static String[][] FellFullTrigger = new String[][]
        {
            FellTrigger,
            FellTrigger2,
            FellTrigger3
        };

        public static String[][] HoursFullTrigger = new String[][]
        {
            HoursTrigger,
            HoursTrigger2,
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