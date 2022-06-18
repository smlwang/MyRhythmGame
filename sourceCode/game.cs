using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace WindowsFormsApp2
{
    public class game 
    {
        public static long startTime;
        public int combo;
        public int trackNum;
        public Track[] tracks;
        public int maxCombo;
        public long Score;
        System.Media.SoundPlayer soundPlayer;
        bool ok = true;
        Bitmap cacheImage;
        Graphics cacheG;
        Graphics g;
        //offset 为正 音符出现更晚， 负 更早
        public game(int trackNum, System.IO.Stream music, string trackInfo, long offset, Size size, Graphics g)
        {//TODO: 加载音乐和铺面
            Score = 0;
            combo = 0;
            maxCombo = 0;
            cacheImage = new Bitmap(size.Width, size.Height);
            cacheG = Graphics.FromImage(cacheImage);
            PrepareMusic(music);
            PrepareTrack(trackNum, trackInfo);
            startTime -= offset;
            this.g = g;
        }
        void PrepareMusic(System.IO.Stream music)
        {
            soundPlayer = new System.Media.SoundPlayer(music);
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
        public void starts()//游戏开始
        {
            soundPlayer.Load();
            soundPlayer.Play();
            startTime = Info.now();
            ok = true;
            new Task(gaming).Start();
        }
        public void judge()
        {//检测note
            long gameTime = GameTime();
            for (int i = 0; i < trackNum; i++)
            {
                trackJudge(gameTime, i);
            }
        }
        public void gaming()
        {
            while (ok)
            {
                judge();
                paint(g);   
            }
        }
        public void lisenKey(int chose, bool stat)
        {
            if(ok)
            {
                if (chose == -1) return;
                tracks[chose].keyChange(stat);
            }
        }
        public void trackJudge(long gameTime, int trackNo)
        {
            int stat = tracks[trackNo].judge(gameTime);
            if (stat == Info.noAct) return;
            if(stat == Info.miss)
            {
                combo = 0;
                return;
            }
            combo++;
            if(combo > maxCombo)
                maxCombo = combo;
            Score += Info.scoreFrac * stat;
        }
        public long GameTime()
        {
            return Info.now() - startTime;
        }
        public void exitGame()
        {
            soundPlayer.Stop();
            soundPlayer.Dispose();
            ok = false;
        }
        public void paint(Graphics g)
        {
            cacheG.Clear(Color.Black);
            long gameTime = GameTime();
            for(int i = 0; i < trackNum; i++)
            {
                for(int j = 0; j < tracks[i].track.Count; j++)
                {
                    note cur = tracks[i].track[j];
                    //if (cur.start - gameTime > 5000) break;
                    long deltaTime = cur.end - gameTime;
                    int chose = 1;
                    if (i == 0 || i == 3) chose = 0;
                    if(cur.kind == 1)
                    {
                        float noShift = Info.baseJudgeLine - Info.speed * deltaTime;
                        float y = noShift - Info.imgShift;
                        paintClick(i, chose, y, cacheG);
                        paintPerfect(i, noShift, cacheG);
                    }
                    else
                    {
                        float y = Info.baseJudgeLine - Info.speed * deltaTime;
                        float len = Info.speed * (cur.end - cur.start);
                        paintHold(i, chose, y, len, cacheG);
                    }
                }
                paintJudgeLine(cacheG);
                if (tracks[i].keyCheck)
                {
                    paintHit(i, cacheG);
                }
            }
            g.DrawImage(cacheImage, 0, 0);
        }
        void paintCombo(Graphics g)
        {
           // g.DrawString(combo.ToString(), null, ,Info.trackX[2], Info.baseJudgeLine - 200);
        }
        void paintClick(int track, int chose, float y, Graphics g)
        {
            g.DrawImage(Info.clickimg[chose], Info.trackX[track], y, Info.noteWeight, 40);
        }
        void paintHold(int track, int chose, float y, float len, Graphics g)
        {
            g.DrawImage(Info.holdimg[chose], Info.trackX[track], y, Info.noteWeight, len);
        }
        void paintJudgeLine(Graphics g)
        {
            g.DrawImage(Info.judgeLine, Info.trackX[0] - Info.xShift, Info.baseJudgeLine - 3, 4*Info.noteWeight + 2 * Info.xShift, 6);
        }
        void paintPerfect(int track, float y, Graphics g)
        {
            g.DrawImage(Info.perfectLine, Info.trackX[track], y, Info.noteWeight, 2);
        }
        public void paintHit(int track, Graphics g)
        {
            g.DrawImage(Info.hit, Info.trackX[track], Info.baseJudgeLine, Info.noteWeight, 60);
        }
    }
}
