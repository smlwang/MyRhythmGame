using System;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    public class Track
    {
        public List<note> track;
        public bool keyCheck = false;
        public bool keyHold = false;
        public Track()
        {
            track = new List<note>();
        }
        public void keyChange(bool pressed)
        {
            keyCheck = pressed;
            if(!pressed) keyHold = false;
        }
        //deltaTime 距离游戏开始时间
        public int judge(long gameTime)
        {   
            if(track.Count == 0) return 0;
            note note = track[0];
            // deltaTime 与判定时间的差
            if(!keyCheck)
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
                return Info.noAct;
            }
            if(note.kind == 1)
            {
                if (keyHold) return Info.noAct;
                keyHold = keyCheck;
                track.RemoveAt(0);
                return clickJudge(Math.Abs(deltaTime));
            }
            else
            {
                if(note.end < gameTime)//长条尾判
                {
                    track.RemoveAt(0);
                    if(note.preCheck && (keyHold || keyCheck))
                    {
                        return Info.perfect;
                    }
                    return Info.miss;
                }
                if(!note.preCheck && Math.Abs(deltaTime) <= Info.greatJudge)//长条头判
                {   
                    if(keyHold || !keyCheck) return Info.noAct;
                    keyHold = true;
                    track[0].preCheck = true;
                    note.preCheck = true;
                    return Info.perfect;
                }
                if(note.preCheck && keyHold)
                    track[0].start = Math.Max(gameTime, note.start);
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
