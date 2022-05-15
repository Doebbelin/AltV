using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltV.MyPlayer
{
    public class MyPlayerFactory : IEntityFactory<MyPlayer>
    {
        public MyPlayer Create(IServer server, IntPtr entityPointer, ushort id)
        {
            return new MyPlayer(server, entityPointer, id);
        }
    }
}
