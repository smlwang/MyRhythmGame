using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Track
    {
        public List<note> track;
        public Track()
        {
            track = new List<note>();
        }

        //deltaTime 距离游戏开始时间
        public int judge(long gameTime, int keyStat)
        {
            if(track.Count == 0) return 0;
            note note = track[0];
            // deltaTime 与判定时间的差
            if(keyStat == Info.unpressed)
            {
                if(note.end - gameTime < -Info.goodJudge)
                {
                    track.RemoveAt(0);
                    return Info.miss;
                }
                return Info.noAct;
            }
            long deltaTime = note.start - gameTime;
            if(deltaTime > Info.good) // 没到前判不判定
            {
                return 0;
            }
            if(note.kind == 1)
            {   
                track.RemoveAt(0);
                return clickJudge(Math.Abs(deltaTime));
            }
            else
            {
                if(note.end < gameTime)
                {
                    track.RemoveAt(0);
                    if(note.preCheck == true)
                    {
                        return Info.perfect;
                    }
                    return Info.miss;
                }
                if (note.preCheck) return Info.noAct;
                if(Math.Abs(deltaTime) <= Info.great)
                {
                    note.preCheck = true;
                    return Info.perfect;
                }
                return Info.noAct;
            }
        }
        public int clickJudge(long deltaTime)
        {
            if (deltaTime <= Info.perfectJudge)
                return Info.perfect;
            if(deltaTime <= Info.greatJudge)
                return Info.great;
            if(deltaTime <= Info.goodJudge)
                return Info.good;
            return Info.miss;
        }


    }
}
