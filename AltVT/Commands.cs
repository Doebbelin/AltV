using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltV
{

    public class Commands : IScript
    {
        [CommandEvent(CommandEventType.CommandNotFound)]
        public void OnCommandNotFound(MyPlayer.MyPlayer myplayer, string command)
        {
            myplayer.SendChatMessage("{FF0000} Befehl " + command + "nicht gefunden");
            return;
        }

        [Command("car")]
        public void CMD_car(MyPlayer.MyPlayer myplayer, string VehicleName, int R = 0, int G = 0, int B = 0)
        {
            IVehicle veh = Alt.CreateVehicle(Alt.Hash(VehicleName), new AltV.Net.Data.Position(myplayer.Position.X, myplayer.Position.Y + 2.5f, myplayer.Position.Z), myplayer.Rotation);
            if (veh != null)
            {
                veh.PrimaryColorRgb = new AltV.Net.Data.Rgba((byte)R, (byte)G, (byte)B, 255);
                myplayer.SendChatMessage("{04B404} Das Fahrzeug ist erfolgreich gespawned!");
            }
            else
            {
                myplayer.SendChatMessage("{FF0000} Das Fahrzeug konnte nicht gespawned werden!");
            }
        }

        [Command("freezeme")]
        public void CMD_freezeme(MyPlayer.MyPlayer myplayer, bool freeze)
        {
            myplayer.Emit("freezePlayer", freeze);
            myplayer.SendChatMessage("{ff3300}Du wuerdet gefreez!");
        }
    }
}

