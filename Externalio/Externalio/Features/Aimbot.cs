using System;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Collections.Generic;

using Externalio.Other;
using Externalio.Managers;

using Math = Externalio.Other.Math;

namespace Externalio.Features
{
    internal class Aimbot
    {
        // TODO LIST:
        // -Visibility Check (Not that important)
        // -Weapon Check

        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(Settings.Aimbot.Smooth == 0f ? 1 : 45);

                if (!Convert.ToBoolean((long)Globals.Imports.GetAsyncKeyState(System.Windows.Forms.Keys.LButton) & 0x8000) 
                    || Convert.ToBoolean((long)Globals.Imports.GetAsyncKeyState(Settings.Trigger.Key) & 0x8000)
                    || !Checks.IsIngame
                    || !Structs.LocalPlayer.Health.IsAlive()) continue;

                int maxPlayers = Structs.ClientState.MaxPlayers;

                byte[] entities = MemoryManager.ReadMemory((int)Structs.Base.Client + Offsets.dwEntityList, maxPlayers * 0x10);

                Dictionary<float, Vector3> possibleTargets = new Dictionary<float, Vector3> { };

                for (int i = 0; i < maxPlayers; i++)
                {
                    int cEntity = Math.GetInt(entities, i * 0x10);

                    Structs.Enemy_t entityStruct = MemoryManager.ReadMemory<Structs.Enemy_t>(cEntity);

                    if (!entityStruct.Team.HasTeam() 
                        || entityStruct.Team.IsMyTeam() 
                        || !entityStruct.Health.IsAlive() 
                        || entityStruct.Dormant) continue;

                    Vector3 bonePosition = Extensions.Other.GetBonePos(cEntity, Settings.Aimbot.Bone);

                    if (bonePosition == Vector3.Zero) continue;

                    Vector3 destination = Settings.Aimbot.RecoilControl 
                        ? Math.CalcAngle(Structs.LocalPlayer.Position, bonePosition, Structs.LocalPlayer.AimPunch, Structs.LocalPlayer.VecView, Settings.Aimbot.YawRecoilReductionFactory,  Settings.Aimbot.PitchRecoilReductionFactory) 
                        : Math.CalcAngle(Structs.LocalPlayer.Position, bonePosition, Structs.LocalPlayer.AimPunch, Structs.LocalPlayer.VecView, 0f, 0f);

                    if (destination == Vector3.Zero) continue;

                    float distance = Math.GetDistance3D(destination, Structs.ClientState.ViewAngles);

                    if (!(distance <= Settings.Aimbot.Fov)) continue;

                    possibleTargets.Add(distance, destination);
                }

                if (!possibleTargets.Any()) continue;

                Vector3 aimAngle = possibleTargets.OrderByDescending(x => x.Key).LastOrDefault().Value;

                if (Settings.Aimbot.Curve)
                {
                    Vector3 qDelta = aimAngle - Structs.ClientState.ViewAngles;
                    qDelta += new Vector3(qDelta.Y / Settings.Aimbot.CurveY, qDelta.X / Settings.Aimbot.CurveX, qDelta.Z);

                    aimAngle = Structs.ClientState.ViewAngles + qDelta;
                }

                aimAngle = Math.NormalizeAngle(aimAngle);
                aimAngle = Math.ClampAngle(aimAngle);

                MemoryManager.WriteMemory<Vector3>(Structs.ClientState.Base + Offsets.dwClientState_ViewAngles, Settings.Aimbot.Smooth == 0f 
                    ? aimAngle
                    : Math.SmoothAim(Structs.ClientState.ViewAngles, aimAngle, Settings.Aimbot.Smooth));
            }
        }
    }
}