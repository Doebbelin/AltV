using AltV.MyPlayer;
using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltV
{
    class Server : Resource
    {
        public override void OnStart()
        {
            Alt.Log("Server ist gerstart");
            //MYSQL
            Datenbank.InitConnection();
        }

        public override void OnStop()
        {
            Alt.Log("Der Server ist gestopt");
        }

        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new MyPlayerFactory();
        }
    }
}
