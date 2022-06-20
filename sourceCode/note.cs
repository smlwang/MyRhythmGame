using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class note : IComparable<note>
    {
        public int kind;
        public long start;
        public long end;
        public bool preCheck;
        public int CompareTo(note other)
        {
            if(start < other.start) return -1;
            if(start > other.start) return 1;
            return 0;
        }
    }
    public class judgeNode
    {
        public int stat;
        public int track;
        public long end;
        public int EPL;//early, perfect, late
        public judgeNode(int stat, int track, long end, int epl)
        {
            this.stat = stat;
            this.track = track;
            this.end = end;
            EPL = epl;
        }
    }
}
