using System.Threading;

using Externalio.Other;
using Externalio.Managers;

namespace Externalio.Features
{
    internal class Radar
    {
        public static void Run()
        {
            while (true) 
            {
                Thread.Sleep(50);

                if (!Checks.IsIngame) continue;

                int maxPlayers = Structs.ClientState.MaxPlayers;

                byte[] entities = MemoryManager.ReadMemory((int)Structs.Base.Client + Offsets.dwEntityList, maxPlayers * 0x10);

                for (int i = 0; i < maxPlayers; i++) 
                {
                    int cEntity = Math.GetInt(entities, i * 0x10);

                    Structs.Enemy_t cEntityStruct = MemoryManager.ReadMemory<Structs.Enemy_t>(cEntity);

                    if (cEntityStruct.Spotted 
                        || !cEntityStruct.Health.IsAlive() 
                        || cEntityStruct.Team.IsMyTeam() 
                        || cEntityStruct.Dormant) continue;

                    MemoryManager.WriteMemory<int>(cEntity + Offsets.m_bSpotted, 1);

                    Thread.Sleep(150);
                }
            }
        }
    }
}
