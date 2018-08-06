using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackListWot
{
    public class MEMBER
    {
        public string nickname { get; set; }
        public SortedSet<Bans> ssBans
        {
            get;
            set;
        }
        private byte[] note = new byte[6];
        public MEMBER() { }

        public MEMBER(string nickname, SortedSet<Bans> ssBans, byte[] note)
        {
            this.nickname = nickname;
            this.ssBans = ssBans;
            this.note = note;
        }

        public void Add(string nickname, SortedSet<Bans> ssBans, byte[] note)
            {
            this.nickname = nickname;
            this.ssBans = ssBans;
            this.note = note;
        }

        public string Print ()
        { StringBuilder str = new StringBuilder();
            foreach (Bans b in ssBans)
            {
                str.Append(b.qty.ToString()+" "+b.nameban.ToString());

            }
            return str.ToString();
        }

    }
    public class Bans
    {
        public int qty { get; set; }
        public string nameban { get; set; }

        public Bans () { }
        
        public Bans (int qty, string nameban)
        {
            this.qty = qty;
            this.nameban = nameban;

        }

        public void AddBan()
        {
            qty++;
        }



    }
}
