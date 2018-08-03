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
        SortedSet<Bans> ssBans;
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
       

    }
    public class Bans
    {
        int qty;
        string nameban;

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
