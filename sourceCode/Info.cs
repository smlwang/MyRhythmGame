using System;
using System.Drawing;

namespace WindowsFormsApp2
{
    public static class Info
    {
        //按键
        public static int pressed = 1;
        public static int unpressed = 2;

        //判定区间 ms
        public static long goodJudge = 400;
        public static long greatJudge = 200;
        public static long perfectJudge = 80;

        //判定结果
        public static int miss = -1;
        public static int noAct = 0;
        public static int good = 1;
        public static int great = 2;
        public static int perfect = 3;

        //分数计算
        public static long scoreFrac = 10;
        public static DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long now()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
        // 判定
        public static int holdCount = 5;
        // 绘制
        public static int xShift = 10;
        public static int noteWeight = 100;
        public static int notexshift= 30;
        public static int []trackX = { notexshift + noteWeight, 
                                        notexshift + 2 * noteWeight, 
                                        notexshift + 3 * noteWeight, 
                                        notexshift + 4 * noteWeight 
                                     };
        public static float baseJudgeLine = 530f;
        public static float imgShift = 30;
        public static float speed = 0.70f;
        public static Image[] clickimg = { Properties.Resources.clickDefault, Properties.Resources.clickDefault2};
        public static Image[] holdimg = { Properties.Resources.longnote, Properties.Resources.longnote23};
        public static Image perfectLine = Properties.Resources.perfectLine; 
        public static Image judgeLine = Properties.Resources.judgeLine; 
        public static Image hit = Properties.Resources.hit; 
    }
}
