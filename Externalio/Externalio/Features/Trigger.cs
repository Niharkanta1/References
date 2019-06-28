using System;
using System.Threading;

using Externalio.Other;

namespace Externalio.Features
{
    internal class Trigger
    {
        public static void Run()
        {
            while (true) 
            {
                Thread.Sleep(1);

                if (!Convert.ToBoolean((long)Globals.Imports.GetAsyncKeyState(Settings.Trigger.Key) & 0x8000) 
                    || !Checks.IsIngame 
                    || !Structs.LocalPlayer.Health.IsAlive()
                    || !Structs.Enemy_Crosshair.Health.IsAlive()
                    || !Structs.Enemy_Crosshair.Team.HasTeam()
                    || Structs.Enemy_Crosshair.Team.IsMyTeam()
                    || Structs.Enemy_Crosshair.Dormant) continue;

                if (Settings.Trigger.Delay > 0) Thread.Sleep(Settings.Trigger.Delay);

                Globals.Imports.mouse_event(Mouse.MOUSEEVENTF_LEFTDOWN | Mouse.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
        }
    }
}
