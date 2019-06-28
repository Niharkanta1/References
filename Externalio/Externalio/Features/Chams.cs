using System;
using System.Threading;

using Externalio.Other;
using Externalio.Managers;

namespace Externalio.Features
{
    internal class Chams
    {
       public static void Run()
       {
            while (true)
            {
                Thread.Sleep(1000);

                if (!Checks.IsIngame) continue;

                for (int i = 0; i < Structs.ClientState.MaxPlayers; i++)
                {
                    int cEntity = MemoryManager.ReadMemory<int>((int)Structs.Base.Client + Offsets.dwEntityList + (i - 1) * 16);
                    Structs.Enemy_t cEntityStruct = MemoryManager.ReadMemory<Structs.Enemy_t>(cEntity);

                    if (!cEntityStruct.Health.IsAlive() 
                        || cEntityStruct.Dormant 
                        || !cEntityStruct.Team.HasTeam()) continue;

                    if (Settings.Chams.Enemies && !cEntityStruct.Team.IsMyTeam())
                    {
                        Structs.clrRender_t clrRenderStruct = new Structs.clrRender_t()
                        {
                            r = Convert.ToByte(Settings.Chams.Enemies_Color_R),
                            g = Convert.ToByte(Settings.Chams.Enemies_Color_G),
                            b = Convert.ToByte(Settings.Chams.Enemies_Color_B),
                            a = Convert.ToByte(Settings.Chams.Enemies_Color_A)
                        };

                        MemoryManager.WriteMemory<Structs.clrRender_t>(cEntity + Offsets.m_clrRender, clrRenderStruct);
                    }
                    
                    if (Settings.Chams.Allies && cEntityStruct.Team.IsMyTeam())
                    {
                        Structs.clrRender_t clrRenderStruct = new Structs.clrRender_t()
                        {
                            r = Convert.ToByte(Settings.Chams.Allies_Color_R),
                            g = Convert.ToByte(Settings.Chams.Allies_Color_G),
                            b = Convert.ToByte(Settings.Chams.Allies_Color_B),
                            a = Convert.ToByte(Settings.Chams.Allies_Color_A)
                        };

                        MemoryManager.WriteMemory<Structs.clrRender_t>(cEntity + Offsets.m_clrRender, clrRenderStruct);
                    }

                    Thread.Sleep(50);
                }
            }
        }
    }
}
