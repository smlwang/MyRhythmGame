using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
namespace WindowsFormsApp2
{
    public class game 
    {
        int combo;
        long Score;
        int trackNum;
        bool paused = false;
        public static long startTime;
        public int maxCombo;
        public Track[] tracks;
        public long pauseTime;
        judgeNode []judgeQue;
        WMPLib.WindowsMediaPlayer wm = new WMPLib.WindowsMediaPlayer();
        //System.Media.SoundPlayer soundPlayer;
        
        bool run = true;
        Bitmap cacheImage;
        Graphics cacheG;
        Graphics g;
        
        //offset 为正 音符出现更晚， 负 更早
        public game(int trackNum, string music, string trackInfo, long offset, Size size, Graphics g)
        {//TODO: 加载音乐和铺面
            Score = 0;
            combo = 0;
            maxCombo = 0;
            cacheImage = new Bitmap(size.Width, size.Height);
            cacheG = Graphics.FromImage(cacheImage);
            judgeQue = new judgeNode[trackNum];
            PrepareMusic(music);
            PrepareTrack(trackNum, trackInfo);
            startTime -= offset;
            this.g = g;
        }
        public void starts()//游戏开始
        {
            wm.settings.volume = 100;
            wm.controls.play();
            startTime = Info.now();
            run = true;
            new Task(gaming).Start();
        }
        public void gaming()
        {
            while (run)
            {   
                cacheG.Clear(Color.Black);
                judge();
                paint(g);   
            }
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
        public void exitGame()
        {
            //soundPlayer.Stop();
            //soundPlayer.Dispose();
            wm.controls.stop();
            run = false;
        }
        public void pauseControl()
        {
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
            //soundPlayer = new System.Media.SoundPlayer(music);
        }
        void PrepareTrack(int trackNum, string trackInfo)
        {
            this.trackNum = trackNum;
            tracks = new Track[trackNum];
            for(int i = 0; i < trackNum; i++)
                    tracks[i] = new Track();
            FileStream fs = new FileStream(trackInfo, FileMode.Open);
            StreamReader sr = new StreamReader(fs); 
            string[] src = sr.ReadToEnd().Split(' ');
            for(int i = 0; i < src.Length;)
            {
                int kind = (int)Int64.Parse(src[i]);//note类型
                int trackNo = (int)Int64.Parse(src[i + 1]) - 1;//轨道
                long time = (long)(float.Parse(src[i + 2]) * 1000f);//时间
                note newNote = new note
                {
                    kind = kind,
                    start = time,
                    end = time,
                };
                if(kind == 2)
                {
                    long endTime = (long)(float.Parse(src[i + 3]) * 1000);
                    newNote.end = endTime;
                    i++;
                }
                tracks[trackNo].track.Add(newNote);
                i += 3; 
            }
            sr.Close();
        }
        void pauseGame()
        {
            //soundPlayer.Stop();
            pauseTime = Info.now();
            wm.controls.pause();
            run = false;
        }
        void recoverGame()
        {
            run = true;
            wm.controls.play();
            startTime += Info.now() - pauseTime - Info.pauseOffset;
            new Task(gaming).Start();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void judge()
        {//检测note
            long gameTime = GameTime();
            for (int i = 0; i < trackNum; i++)
            {
                trackJudge(gameTime, i);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void trackJudge(long gameTime, int trackNo)
        {
            int stat = tracks[trackNo].judge(gameTime);
            if (stat == Info.noAct) return;
            int epl = Info.mid;
            if (stat > Info.lShift)
            {
                stat -= Info.lShift;
                epl = Info.late;
            }
            else if (stat > Info.eShift)
            {
                stat -= Info.eShift;
                epl = Info.early;
            }
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
                    if(Info.baseJudgeLine - (cur.start - gameTime) * Info.speed < Info.noteComingDis)
                    {
                        break;
                    }
                    long deltaTime = cur.end - gameTime;
                    int chose = 1;
                    if (i == 0 || i == 3) chose = 0;
                    if(cur.kind == 1)
                    {
                        float noShift = Info.baseJudgeLine - Info.speed * deltaTime;
                        float y = noShift - Info.imgShift;
                        paintClick(i, chose, y, cacheG);
                        paintPerfectLine(i, noShift, cacheG);
                    }
                    else
                    {
                        float y = Info.baseJudgeLine - Info.speed * deltaTime;
                        float len = Info.speed * (cur.end - cur.start);
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
                    cacheG.DrawString(Info.judgeImg[judgeQue[i].stat], Info.drawFont, Info.judgeBrushes[judgeQue[i].stat], Info.trackX[i], Info.baseJudgeLine - 150);
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
