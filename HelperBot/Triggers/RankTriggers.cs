using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperBot {
    public static class RankTriggers {
        
        static String[] NextRankTrigger1 = new String[]
        {
           "how",
           "do", //I
           "get", //the
           "next", 
           "rank"
        };
        static String[] NextRankTrigger2 = new String[]
        {
           "how",
           "do",
           "promoted"
        };

        static String[] NextRankTrigger3 = new String[]
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

        public static String[][] NextRankFullTrigger = new String[][]
        {
            NextRankTrigger1,
            NextRankTrigger2,
            NextRankTrigger3
        };
        public static String[][] HowDoFullTrigger = new String[][]
        {
            HowDoTrigger1,
            HowDoTrigger2,
            HowDoTrigger3
        };
    }
}
