using System.Threading;

using Externalio.Other;

namespace Externalio.Managers
{
    internal class Reader
    {
        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(1);

                Structs.LocalPlayer.Base = MemoryManager.ReadMemory<int>((int)Structs.Base.Client + Offsets.dwLocalPlayer);
                Structs.LocalPlayer_t localPlayerStruct = MemoryManager.ReadMemory<Structs.LocalPlayer_t>(Structs.LocalPlayer.Base);
                Structs.LocalPlayer.LifeState = localPlayerStruct.LifeState;
                Structs.LocalPlayer.Health = localPlayerStruct.Health;
                Structs.LocalPlayer.Dormant = localPlayerStruct.Dormant;
                Structs.LocalPlayer.Flags = localPlayerStruct.Flags;
                Structs.LocalPlayer.MoveType = localPlayerStruct.MoveType;
                Structs.LocalPlayer.Team = localPlayerStruct.Team;
                Structs.LocalPlayer.ShotsFired = localPlayerStruct.ShotsFired;
                Structs.LocalPlayer.CrosshairID = localPlayerStruct.CrosshairID;
                Structs.LocalPlayer.Position = localPlayerStruct.Position;
                Structs.LocalPlayer.AimPunch = localPlayerStruct.AimPunch;
                Structs.LocalPlayer.VecView = localPlayerStruct.VecView;

                if (Settings.Trigger.Enabled)
                {
                    Structs.Enemy_Crosshair.Base = (int)Structs.Base.Client + Offsets.dwEntityList + (Structs.LocalPlayer.CrosshairID - 1) * 0x10;
                    Structs.Enemy_Crosshair_t crosshairStruct = MemoryManager.ReadMemory<Structs.Enemy_Crosshair_t>(MemoryManager.ReadMemory<int>(Structs.Enemy_Crosshair.Base));
                    Structs.Enemy_Crosshair.Health = crosshairStruct.Health;
                    Structs.Enemy_Crosshair.Dormant = crosshairStruct.Dormant;
                    Structs.Enemy_Crosshair.Team = crosshairStruct.Team;
                }

                Structs.ClientState.Base = MemoryManager.ReadMemory<int>((int)Structs.Base.Engine + Offsets.dwClientState);
                Structs.ClientState_t clientStateStruct = MemoryManager.ReadMemory<Structs.ClientState_t>(Structs.ClientState.Base);
                Structs.ClientState.GameState = clientStateStruct.GameState;
                Structs.ClientState.ViewAngles = clientStateStruct.ViewAngles;
                Structs.ClientState.MaxPlayers = clientStateStruct.MaxPlayers;
            }
        }
    }
}
