using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Threading;

namespace WindowsFormsApp2
{
    public class game 
    {
        int combo;
        long Score;
        int trackNum;
        bool paused = false;
        float speed;
        public static long startTime;
        public int maxCombo;
        public Track[] tracks;
        public long pauseTime;
        string trackInfo;
        string music;
        long offset;
        int allnote = 0;
        int []noteCount;
        judgeNode []judgeQue;
        WMPLib.WindowsMediaPlayer wm = new WMPLib.WindowsMediaPlayer();
        
        public bool run = true;
        public bool end = false;
        Bitmap cacheImage, cacheImgend;
        Graphics cacheG, cacheEnd;
        Graphics g, endg;
        public void exit()
        {
            wm.controls.stop();
            run = false;
        }
        //offset 为正 音乐出现更晚， 负 更早
        public game(int trackNum, string music, string trackInfo, Size size, Graphics g, Size endsize, Graphics endg)
        {
            this.trackNum = trackNum;
            this.music = music;
            this.trackInfo = trackInfo;
            cacheImage = new Bitmap(size.Width, size.Height);
            cacheImgend = new Bitmap(endsize.Width, endsize.Height);
            cacheG = Graphics.FromImage(cacheImage);
            cacheEnd = Graphics.FromImage(cacheImgend);
            this.g = g;
            this.endg = endg;
        }
        void finalScore()
        {
            cacheEnd.Clear(Color.DarkOrange);
            cacheEnd.DrawString("score : " + Score, Info.drawFont, Info.scoreBrush,5, 20);
            cacheEnd.DrawString("MaxCombo : " + maxCombo, Info.drawFont, Info.scoreBrush, 0, 50);
            for (int i = 3; i >= 0; i--)
                cacheEnd.DrawString(Info.judgeImg[i] + ": " + noteCount[i].ToString(), Info.drawFont, Info.scoreBrush, 30, 100 + (3 - i) * 30);
            if(allnote > 0)
                cacheEnd.DrawString(string.Format("acc : {0:F2} %", (double)Score * 100 / (double)(allnote * Info.scoreFrac * Info.perfect)), Info.drawFont, Info.scoreBrush, 20, 60 + 5 * 30 + 40);
            endg.DrawImage(cacheImgend, 0, 0);
        }
        public void prepare()
        {
            noteCount = new int[4]; 
            allnote = 0;
            Score = 0;
            combo = 0;
            maxCombo = 0;
            wm.settings.volume = 100;
            startTime = offset;
            judgeQue = new judgeNode[trackNum];
            cacheEnd.Clear(Color.White);
            endg.Clear(Color.White);
            PrepareMusic(music);
            PrepareTrack(trackNum, trackInfo);
            cacheEnd.Clear(Color.WhiteSmoke);
            endg.Clear(Color.WhiteSmoke);
        }
        public void starts()//游戏开始
        {
            wm.settings.volume = 100;
            prepare();
            run = true;
            startGaming();
        }
        public void reStart()
        {
            wm.controls.stop();
            run = true;
            end = false;
            paused = false;
            prepare();
            startTime = -offset;
            startGaming();
        }
        public void Set(float speed, long offset)
        {
            this.speed = speed;
            this.offset = offset;
            startTime -= offset;
        }
        long endTime = 0;
        void gameRunning()
        {
            while (run)
            {   
                cacheG.Clear(Color.Black);
                judge();
                paint(g);   
                if (end)
                {
                    finalScore();
                    if (endTime == 0)
                        endTime = Info.now() + 5000;
                    wm.settings.volume = Math.Max(0, (int)(endTime - Info.now()) / 50);
                    if(Info.now() > endTime)
                    {
                        run = false;
                    }
                }
            }
            if (paused)
            {
                cacheG.DrawString(Info.pauseImg, Info.pauseFont, Info.pauseBrush, Info.trackX[1], Info.baseJudgeLine - 250);
                g.DrawImage(cacheImage, 0, 0);
            }
        }
        public void startGaming()
        {
            wm.controls.play();
            startTime += Info.now();
            new Task(gameRunning).Start();
        }
        public void lisenKey(int chose, bool stat)
        {
            if (chose == -1) return;
            tracks[chose].keyChange(stat);
        }
        public long GameTime()
        {
            return Info.now() - startTime;
        }
        public void pauseControl()
        {
            if (end) return;
            if (paused)
            {
                paused = false;
                recoverGame();
            }
            else
            {
                paused = true;
                pauseGame();
            }
        }
        
        void PrepareMusic(string music)
        {
            wm.URL = music;
        }
        void PrepareTrack(int trackNum, string trackInfo)
        {
            this.trackNum = trackNum;
            tracks = new Track[trackNum];
            for(int i = 0; i < trackNum; i++)
                tracks[i] = new Track();
            FileStream fs = new FileStream(trackInfo, FileMode.Open);
            StreamReader sr = new StreamReader(fs); 
            string[] src = sr.ReadToEnd().Split('\n');
            for(int i = 0; i < src.Length; i++)
            {
                src[i] = src[i].TrimEnd(Info.spaceChar);
                string[] note = src[i].Split(' ');
                int kind = (int)Int64.Parse(note[0]);//note类型
                int trackNo = (int)Int64.Parse(note[1]) - 1;//轨道
                long time = Int64.Parse(note[2]);//时间
                note newNote = new note
                {
                    kind = kind,
                    start = time,
                    end = time,
                };
                allnote++;
                if(kind == 2)//如果是长条就再读一个 endTime
                {
                    allnote++;
                    long endTime = Int64.Parse(note[3]);
                    newNote.end = endTime;
                }
                tracks[trackNo].track.Add(newNote);
            }
            sr.Close();
            fs.Close();
            for(int i = 0; i < trackNum; i++)
            {
                tracks[i].track.Sort();
            }
        }
        void pauseGame()
        {
            pauseTime = Info.now();
            wm.controls.pause();
            run = false;
        }
        void recoverGame()
        {
            if (end) return;
            run = true;
            wm.controls.play();
            startTime += Info.now() - pauseTime - Info.pauseOffset;
            new Task(gameRunning).Start();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void judge()
        {//检测note
            long gameTime = GameTime();
            bool noteAllDone = true;
            for (int i = 0; i < trackNum; i++)
            {
                trackJudge(gameTime, i);
                if (tracks[i].track.Count > 0) noteAllDone = false;
            }
            if (noteAllDone)
            {
                end = true;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void trackJudge(long gameTime, int trackNo)
        {
            int stat = tracks[trackNo].judge(gameTime);
            if (stat == Info.noAct) return;
            int epl = Info.mid;
            if (stat >= Info.lShift)
            {
                stat -= Info.lShift;
                epl = Info.late;
            }
            else if (stat >= Info.eShift)
            {
                stat -= Info.eShift;
                epl = Info.early;
            }
            noteCount[stat]++;
            judgeQue[trackNo] = new judgeNode(stat, trackNo, gameTime + Info.showJudge, epl);
            if(stat == Info.miss)
            {
                combo = 0;
                judgeQue[trackNo].EPL = Info.miss;
                return;
            }
            combo++;
            if(combo > maxCombo)
                maxCombo = combo;
            Score += Info.scoreFrac * stat;
            if(stat == Info.perfect && epl == Info.mid)
            {
                Score += 1;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void paint(Graphics g)
        {
            if(combo >= Info.minComboToShow)
                paintCombo(cacheG);
            paintScore(cacheG);
            long gameTime = GameTime();
            for(int i = 0; i < trackNum; i++)
            {
                for(int j = 0; j < tracks[i].track.Count; j++)
                {
                    note cur = tracks[i].track[j];
                    if(Info.baseJudgeLine - (cur.start - gameTime) * speed < Info.noteComingDis)
                    {
                        break;
                    }
                    long deltaTime = cur.end - gameTime;
                    int chose = 1;
                    if (i == 0 || i == 3) chose = 0;
                    if(cur.kind == 1)
                    {
                        float noShift = Info.baseJudgeLine - speed * deltaTime;
                        float y = noShift - Info.imgShift;
                        paintClick(i, chose, y, cacheG);
                        paintPerfectLine(i, noShift, cacheG);
                    }
                    else
                    {
                        float y = Info.baseJudgeLine - speed * deltaTime;
                        float len = speed * (cur.end - cur.start);
                        paintHold(i, chose, y, len, cacheG);
                    }
                }
                paintJudgeLine(cacheG);
                if (tracks[i].keyPressed)
                {
                    paintHit(i, cacheG);
                }
            }
            paintJudgeStat(gameTime, cacheG);
            g.DrawImage(cacheImage, 0, 0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void paintJudgeStat(long gameTime, Graphics g)
        {
            for(int i = 0; i < trackNum; i++)
            {
                if (judgeQue[i] == null) continue;

                if(gameTime < judgeQue[i].end)
                {
                    string space = "";
                    if (judgeQue[i].stat != Info.perfect)
                        space = " ";
                    cacheG.DrawString(space + Info.judgeImg[judgeQue[i].stat], Info.drawFont, Info.judgeBrushes[judgeQue[i].stat], Info.trackX[i], Info.baseJudgeLine - 150);
                    cacheG.DrawString(Info.eplImg[judgeQue[i].EPL], Info.eplFont, Info.statBrushes[judgeQue[i].EPL], Info.trackX[i], Info.baseJudgeLine - 130);
                }
            }

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void paintCombo(Graphics g)
        {
            g.DrawString("combo      " + combo.ToString(), Info.drawFont, Info.comboBrush,Info.trackX[1] - Info.xShift, Info.baseJudgeLine - 200);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void paintScore(Graphics g)
        {
            g.DrawString("score     " + Score.ToString(), Info.drawFont, Info.scoreBrush, Info.trackX[1] - Info.xShift, Info.baseJudgeLine - 300);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void paintClick(int track, int chose, float y, Graphics g)
        {
            g.DrawImage(Info.clickimg[chose], Info.trackX[track], y, Info.noteWeight, 40);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void paintHold(int track, int chose, float y, float len, Graphics g)
        {
            g.DrawImage(Info.holdimg[chose], Info.trackX[track], y, Info.noteWeight, len);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void paintJudgeLine(Graphics g)
        {
            g.DrawImage(Info.judgeLine, Info.trackX[0] - Info.xShift, Info.baseJudgeLine - 3, 4*Info.noteWeight + 2 * Info.xShift, 6);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void paintPerfectLine(int track, float y, Graphics g)
        {
            g.DrawImage(Info.perfectLine, Info.trackX[track], y, Info.noteWeight, 2);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void paintHit(int track, Graphics g)
        {
            g.DrawImage(Info.hit, Info.trackX[track], Info.baseJudgeLine, Info.noteWeight, 60);
        }
    }
}
