using System;
using System.Drawing;

namespace WindowsFormsApp2
{
    public static class Info
    {
        //按键
        public static int pressed = 1;
        public static int unpressed = 2;

        //判定区间
        public static long goodJudge = 80;
        public static long greatJudge = 50;
        public static long perfectJudge = 20;

        //判定结果
        public static int miss = -1;
        public static int noAct = 0;
        public static int good = 1;
        public static int great = 2;
        public static int perfect = 3;

        //分数计算
        public static long scoreFrac = 1000;
        public static DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long now()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
        // 绘制
        public static int xShift = 10;
        public static int noteWeight = 60;
        public static int notexshift= 30;
        public static int []trackX = { notexshift + noteWeight, 
                                        notexshift + 2 * noteWeight, 
                                        notexshift + 3 * noteWeight, 
                                        notexshift + 4 * noteWeight 
                                     };
        public static float baseJudgeLine = 450f;
        public static float imgShift = 23;
        public static float speed = 1.80f;
        public static Image[] clickimg = { Properties.Resources.click, Properties.Resources.click23};
        public static Image judgeLine = Properties.Resources.judgeLine; 
        public static Image hit = Properties.Resources.hit; 
    }
}
