using System;
using System.Threading;

using Externalio.Other;
using Externalio.Managers;

namespace Externalio.Features
{
    internal class Bunnyhop
    {
        public static void Run()
        {
            while (true) 
            {
                Thread.Sleep(1);

                if (!Convert.ToBoolean((long)Globals.Imports.GetAsyncKeyState(Settings.Bunnyhop.Key) & 0x8000) 
                    || !Checks.IsIngame 
                    || !Structs.LocalPlayer.Health.IsAlive()
                    || !Checks.CanBunnyhop) continue;

                MemoryManager.WriteMemory<int>((int)Structs.Base.Client + Offsets.dwForceJump, 5);

                Thread.Sleep(15);

                MemoryManager.WriteMemory<int>((int)Structs.Base.Client + Offsets.dwForceJump, 4);
            }
        }
    }
}
