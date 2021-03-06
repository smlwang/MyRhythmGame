using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WindowsFormsApp2
{
    public class Track
    {
        public List<note> track;
        
        public bool keyPressed;
        bool keyPress = false;
        bool keyHold = false;

        int holdCnt = 0;
        int pressCancel = 0;

        public Track()
        {
            track = new List<note>();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void keyChange(bool pressed)
        {   
            keyPressed = pressed;
            if (pressed)
            {
                keyPress = true;
                keyHold = false;
                pressCancel = 0;
                holdCnt = 0;
                return;
            }
            pressCancel++;
        }
         //deltaTime 距离游戏开始时间

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int judge(long gameTime)
        {
            if (!keyPressed)
            {
                pressCancel++;
                if(pressCancel > Info.pressCancelCnt)
                {
                    keyReset();
                }
            }
            if (!keyPress && !keyHold)
            {
                keyHold = false;
                holdCnt = 0;
            }
            if(keyPress)
                holdCnt = Math.Min(Info.holdJudgeCnt, holdCnt + 1);
            if(holdCnt >= Info.holdJudgeCnt) keyHold = true;
            if(track.Count == 0) return Info.noAct;
            note note = track[0];
            // deltaTime 与判定时间的差
            if(!keyPress)
            {
                if(note.end - gameTime < -Info.greatJudge)
                {
                    track.RemoveAt(0);
                    return Info.miss;
                }
                return Info.noAct;
            }
            long deltaTime = note.start - gameTime;
            if(deltaTime > Info.goodJudge) // 没到前判不判定
            {
                return Info.noAct;
            }
            if (note.kind == 1)
            {
                if (keyHold) return Info.noAct;
                track.RemoveAt(0);
                if (!keyPressed)
                {
                    keyReset();
                }
                keyHold = keyPress;
                return clickJudge(deltaTime);
            }
            else
            {
                if (!keyPress || note.end < gameTime)
                {
                    if (note.dead)
                    {
                        track.RemoveAt(0);
                        return Info.perfect;
                    }
                }
                if(note.end < gameTime - Info.perfectJudge)
                {
                    track.RemoveAt(0);
                    return Info.miss;
                }
                long tailJudge = -Info.greatJudge;
                if (note.preCheck && keyPress)
                    tailJudge = Info.perfectJudge + 10;
                if (note.end < gameTime + tailJudge)//长条尾判
                {
                    if (note.preCheck && keyPress)
                    {
                        note.dead = true;
                        return Info.noAct;
                    }
                }
                if (!note.preCheck)//长条头判
                {
                    if (keyHold) return Info.noAct;
                    if (Math.Abs(deltaTime) <= Info.greatJudge)
                    {
                        note.preCheck = true;
                        keyHold = keyPress;
                        return Info.perfect;
                    }
                    else if (deltaTime < -Info.greatJudge)
                    {
                        note.preCheck = true;
                        keyHold = keyPress;
                        return Info.good;
                    }
                    return Info.noAct;
                }
                if (note.preCheck) 
                    note.start = Math.Max(gameTime, note.start);
                return Info.noAct;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int clickJudge(long deltaTime)
        {
            int stat;
            if(deltaTime >= 0)
            {
                if (deltaTime <= Info.truePerfect)
                    return Info.perfect;
                if (deltaTime <= Info.perfectJudge)
                    stat = Info.perfect;
                else if(deltaTime <= Info.greatJudge)
                    stat = Info.great;
                else if(deltaTime <= Info.goodJudge)
                    stat = Info.good;
                else stat = Info.miss;
                stat += Info.eShift;
            }
            else
            {
                deltaTime = -deltaTime;
                if (deltaTime <= Info.truePerfect)
                    return Info.perfect;
                if (deltaTime <= Info.perfectJudge)
                    stat = Info.perfect;
                else if(deltaTime <= Info.greatJudge)
                    stat = Info.great;
                else if(deltaTime <= Info.goodJudge)
                    stat = Info.good;
                else stat = Info.miss;
                stat += Info.lShift; 
            }
            return stat;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void keyReset()
        {
            keyPress = false;
            keyHold = false;
            pressCancel = 0;
            holdCnt = 0;
        }

    }
}
