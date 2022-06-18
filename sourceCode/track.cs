using System;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    public class Track
    {
        public List<note> track;
        bool keyPressed;
        public bool keyCheck = false;
        public bool keyHold = false;
        public int cnt = 0;
        public int cancel = 0;
        public Track()
        {
            track = new List<note>();
        }
        public void keyChange(bool pressed)
        {   
            keyPressed = pressed;
            if (pressed)
            {
                keyCheck = true;
                keyHold = false;
                cancel = 0;
                cnt = 0;
                return;
            }
            cancel++;
        }
         //deltaTime 距离游戏开始时间
        public int judge(long gameTime)
        {
            if (!keyPressed)
            {
                cancel++;
                if(cancel > 5)
                {
                    keyReset();
                }
            }
            if (!keyCheck && !keyHold)
            {
                keyHold = false;
                cnt = 0;
            }
            if(keyCheck)
                cnt = Math.Min(Info.holdCount, cnt + 1);
            if(cnt >= Info.holdCount) keyHold = true;
            if(track.Count == 0) return 0;
            note note = track[0];
            // deltaTime 与判定时间的差
            if(!keyCheck)
            {
                if(note.end - gameTime < -Info.greatJudge)
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
                if(!keyPressed)
                {
                    keyReset();
                }
                return clickJudge(deltaTime);
            }
            else
            {
                if(note.end < gameTime - Info.perfectJudge)//长条尾判
                {
                    track.RemoveAt(0);
                    if (note.preCheck && keyCheck)
                        return Info.perfect;
                    return Info.miss;
                }
                if(!note.preCheck)//长条头判
                {   
                    if(keyHold) return Info.noAct;
                    if(Math.Abs(deltaTime) <= Info.greatJudge)
                    {
                        track[0].preCheck = true;
                        keyHold = keyCheck;
                        return Info.perfect;
                    }else if(deltaTime < -Info.greatJudge)
                    {
                        track[0].preCheck = true;
                        keyHold = keyCheck;
                        return Info.good;
                    }
                    return Info.noAct;
                }
                if(note.preCheck)
                    track[0].start = Math.Max(gameTime, note.start);
                return Info.noAct;
            }
        }
        public int clickJudge(long deltaTime)
        {
            if(deltaTime >= 0)
            {
                if (deltaTime <= Info.perfectJudge)
                    return Info.perfect;
                if(deltaTime <= Info.greatJudge)
                    return Info.great;
                if(deltaTime <= Info.goodJudge)
                    return Info.good;
            }
            else
            {
                deltaTime = -deltaTime;
                if (deltaTime <= Info.perfectJudge)
                    return Info.perfect;
                if(deltaTime <= Info.greatJudge)
                    return Info.great;
                if (deltaTime < Info.goodJudge)
                    return Info.good;
            }
            return Info.miss;
        }
        public void keyReset()
        {
            keyCheck = false;
            keyHold = false;
            cnt = 0;
            cancel = 0;
        }

    }
}
