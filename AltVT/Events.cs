using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltV
{
    public class Ebents : IScript
    {
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void OnPlayerConnect(MyPlayer.MyPlayer myplayer, string reason)
        {
            Alt.Log($"Der Spieler {myplayer.Name} hat den Server beitreten!");
            myplayer.Spawn(new AltV.Net.Data.Position(-425, 1123, 325), 0);
            myplayer.Model = (uint)PedModel.Business01AMM;
        }
/*
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnePlayerConnect(MyPlayer.MyPlayer myplayer, string reason)
        {
            Alt.Log($"Spieler {myplayer.Name} hat den Server verlassen - Grund: {reason}!");
        }

        [ClientEvent("alttutorial:loginAttempt")]
        public void OnLoginAttempt( IPlayer iplayer, string username, string password) {
            if (player.IsLoggedIn || username.Length < 4 || password.Length < 4) return;

        }

        [ClientEvent("alttutorial:registerAttempt")]
        public void OnRegisterAttempt(IPlayer player, string name, string password) 
        {

        }
*/



         [ClientEvent("alttutorial:Attempt")]
         public void OnPlayerRegister(MyPlayer.MyPlayer myplayer, String name, String password)
         {
             if (!Datenbank.IstAccountBereitsVorhanden(name))
             {
                 if (!myplayer.Eingeloggt && name.Length < 4 && password.Length < 4)
                 {
                     Datenbank.NeuenAccountErstellen(name, password);
                     myplayer.Spawn(new AltV.Net.Data.Position(-425, 1123, 325), 0);
                     myplayer.Model = (uint)PedModel.Business01AMM;
                     myplayer.Eingeloggt = true;
                     myplayer.Emit("CloseLoginHud");
                     myplayer.SendChatMessage("{00c900}Erfolgreich registriert!");
                 }
             }
             else
             {
                 myplayer.Emit("SendErrorMessage", "Es existiert bereits ein Account mit dem eingegebenen Namen!");
             }
         }



         [ClientEvent("alttutorial:loginAttempt")]
         public void OnPlayerLogin(MyPlayer.MyPlayer myplayer, String name, String password)
         {
             if (Datenbank.IstAccountBereitsVorhanden(name))
             {
                 if (!myplayer.Eingeloggt && name.Length < 4 && password.Length < 4)
                 {
                     if (Datenbank.PasswortCheck(name, password))
                     {
                         Datenbank.AccountLaden(myplayer);
                         myplayer.Spawn(new AltV.Net.Data.Position(-425, 1123, 325), 0);
                         myplayer.Model = (uint)PedModel.Business01AMM;
                         myplayer.Eingeloggt = true;
                         myplayer.Emit("CloseLoginHud");
                         myplayer.SendChatMessage("{00c900}Erfolgreich eingeloggt!");
                     }
                     else
                     {
                         myplayer.Emit("SendErrorMessage", "Falsches Passwor!");
                     }
                 }
                 else
                 {
                     myplayer.Emit("SendErrorMessage", "Ungültige Eingaben, bitte korregieren");
                 }
             }
             else
             {
                 myplayer.Emit("SendErrorMessage", "Es wurde kein Account mit diesem Namen gefunden!");
             }
         } 
    }
}
