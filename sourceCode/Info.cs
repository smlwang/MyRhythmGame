using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace WindowsFormsApp2
{
    public static class Info
    {
        //按键
        public static int pressed = 1;
        public static int unpressed = 2;

        //判定区间 ms
        public static long goodJudge = 190;
        public static long greatJudge = 90;
        public static long perfectJudge = 50;
        public static long truePerfect = 30;
        //判定结果
        public static int noAct = -1;
        public static int miss = 0;
        public static int good = 1;
        public static int great = 2;
        public static int perfect = 3;
        //暂停偏移调整
        public static long pauseOffset = 4;

        //分数计算
        public static long scoreFrac = 10;
        public static DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long now()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
        // 按键判定处理
        public static int holdJudgeCnt = 5;
        public static int pressCancelCnt = 5;
        // 绘制
        public static float xShift = 10f;
        public static float noteWeight = 100f;
        public static float notexshift= 30f;
        public static float []trackX = { notexshift + noteWeight, 
                                        notexshift + 2 * noteWeight, 
                                        notexshift + 3 * noteWeight, 
                                        notexshift + 4 * noteWeight 
                                     };
        public static float noteComingDis = -10f;
        public static float baseJudgeLine = 530f;
        public static float imgShift = 32f;
        public static float speed = 0.5f;
        public static Image[] clickimg = { Properties.Resources.clickDefault, Properties.Resources.clickDefault2};
        public static Image[] holdimg = { Properties.Resources.longnote, Properties.Resources.longnote23};
        public static Image perfectLine = Properties.Resources.perfectLine; 
        public static Image judgeLine = Properties.Resources.judgeLine; 

        public static Image hit = Properties.Resources.hit;
        public static Font drawFont = new Font("Arial", 16);
        public static SolidBrush[] statBrushes = { new SolidBrush(Color.DarkRed), new SolidBrush(Color.AliceBlue), new SolidBrush(Color.LightGoldenrodYellow), new SolidBrush(Color.Brown) };
        public static SolidBrush[] judgeBrushes = { new SolidBrush(Color.DarkRed), new SolidBrush(Color.AliceBlue), new SolidBrush(Color.GreenYellow), new SolidBrush(Color.LightGoldenrodYellow) };
        public static string[] judgeImg = { "Miss", " Good", " Great", "Perfect" };
        public static string[] eplImg = { "", "   early", "awesome", "    late" };
        public static Font eplFont = new Font("Arial", 12);
        
        public static long showJudge = 300; // ms
        public static int early = 1;
        public static int mid = 2;
        public static int late = 3;
        public static int eShift = 10;
        public static int lShift = 20;
        public static int minComboToShow = 3;
        public static SolidBrush comboBrush = new SolidBrush(Color.Peru);

        public static SolidBrush scoreBrush = new SolidBrush(Color.GreenYellow);
    }
}
