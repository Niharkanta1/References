using System;
using System.Collections.Generic;

using Externalio.Managers;

namespace Externalio.Other
{
    internal class Offsets
    {
        public static List<string> ScanPatterns()
        {
            List<string> outdatedSignatures = new List<string> { };

            dwGlowObjectManager = MemoryManager.ScanPattern((int)Structs.Base.Client, "A1????????A801754B", 1, 4, true);
            {
                if (dwGlowObjectManager == 0) outdatedSignatures.Add("dwGlowObjectManager");

                Extensions.Information($"dwGlowObjectManager: 0x{ dwGlowObjectManager.ToString("X") }", true);
            }

            dwEntityList = MemoryManager.ScanPattern((int)Structs.Base.Client, "BB????????83FF010F8C????????3BF8", 1, 0, true);
            {
                if (dwEntityList == 0) outdatedSignatures.Add("dwEntityList");

                Extensions.Information($"dwEntityList: 0x{ dwEntityList.ToString("X") }", true);
            }

            dwClientState = MemoryManager.ScanPattern((int)Structs.Base.Engine, "A1????????33D26A006A0033C989B0", 1, 0, true);
            {
                if (dwClientState == 0) outdatedSignatures.Add("dwClientState");

                Extensions.Information($"dwClientState: 0x{ dwClientState.ToString("X") }", true);
            }

            dwForceJump = MemoryManager.ScanPattern((int)Structs.Base.Client, "8B0D????????8BD68BC183CA02", 2, 0, true);
            {
                if (dwForceJump == 0) outdatedSignatures.Add("dwForceJump");

                Extensions.Information($"dwForceJump: 0x{ dwForceJump.ToString("X") }", true);
            }

            dwLocalPlayer = MemoryManager.ScanPattern((int)Structs.Base.Client, "A3????????C705????????????????E8????????59C36A??", 1, 16, true);
            {
                if (dwLocalPlayer == 0) outdatedSignatures.Add("dwLocalPlayer");

                Extensions.Information($"dwLocalPlayer: 0x{ dwLocalPlayer.ToString("X") }", true);
            }

            dwRadarBase = MemoryManager.ScanPattern((int)Structs.Base.Client, "A1????????8B0CB08B01FF50??463B35????????7CEA8B0D", 1, 0, true);
            {
                if (dwRadarBase == 0) outdatedSignatures.Add("dwRadarBase");

                Extensions.Information($"dwRadarBase: 0x{ dwRadarBase.ToString("X") }", true);
            }

            Console.Clear();

            return outdatedSignatures;
        }

        public const Int32 m_ArmorValue = 0xB228;
        public const Int32 m_Collision = 0x318;
        public const Int32 m_CollisionGroup = 0x470;
        public const Int32 m_Local = 0x2FAC;
        public const Int32 m_MoveType = 0x258;
        public const Int32 m_OriginalOwnerXuidHigh = 0x316C;
        public const Int32 m_OriginalOwnerXuidLow = 0x3168;
        public const Int32 m_aimPunchAngle = 0x301C;
        public const Int32 m_aimPunchAngleVel = 0x3028;
        public const Int32 m_bGunGameImmunity = 0x3890;
        public const Int32 m_bHasDefuser = 0xB238;
        public const Int32 m_bHasHelmet = 0xB21C;
        public const Int32 m_bInReload = 0x3245;
        public const Int32 m_bIsDefusing = 0x3884;
        public const Int32 m_bIsScoped = 0x387C;
        public const Int32 m_bSpotted = 0x939;
        public const Int32 m_bSpottedByMask = 0x97C;
        public const Int32 m_dwBoneMatrix = 0x2698;
        public const Int32 m_fAccuracyPenalty = 0x32B0;
        public const Int32 m_fFlags = 0x100;
        public const Int32 m_flFallbackWear = 0x3178;
        public const Int32 m_flFlashDuration = 0xA2E8;
        public const Int32 m_flFlashMaxAlpha = 0xA2E4;
        public const Int32 m_flNextPrimaryAttack = 0x31D8;
        public const Int32 m_hActiveWeapon = 0x2EE8;
        public const Int32 m_hMyWeapons = 0x2DE8;
        public const Int32 m_hObserverTarget = 0x3360;
        public const Int32 m_hOwner = 0x29BC;
        public const Int32 m_hOwnerEntity = 0x148;
        public const Int32 m_iAccountID = 0x2FA8;
        public const Int32 m_iClip1 = 0x3204;
        public const Int32 m_iCompetitiveRanking = 0x1A44;
        public const Int32 m_iCompetitiveWins = 0x1B48;
        public const Int32 m_iCrosshairId = 0xB294;
        public const Int32 m_iEntityQuality = 0x2F8C;
        public const Int32 m_iFOVStart = 0x31D8;
        public const Int32 m_iGlowIndex = 0xA300;
        public const Int32 m_iHealth = 0xFC;
        public const Int32 m_iItemDefinitionIndex = 0x2F88;
        public const Int32 m_iItemIDHigh = 0x2FA0;
        public const Int32 m_iObserverMode = 0x334C;
        public const Int32 m_iShotsFired = 0xA2A0;
        public const Int32 m_iState = 0x31F8;
        public const Int32 m_iTeamNum = 0xF0;
        public const Int32 m_lifeState = 0x25B;
        public const Int32 m_nFallbackPaintKit = 0x3170;
        public const Int32 m_nFallbackSeed = 0x3174;
        public const Int32 m_nFallbackStatTrak = 0x317C;
        public const Int32 m_nForceBone = 0x267C;
        public const Int32 m_nTickBase = 0x3404;
        public const Int32 m_rgflCoordinateFrame = 0x440;
        public const Int32 m_szCustomName = 0x301C;
        public const Int32 m_szLastPlaceName = 0x3588;
        public const Int32 m_vecOrigin = 0x134;
        public const Int32 m_vecVelocity = 0x110;
        public const Int32 m_vecViewOffset = 0x104;
        public const Int32 m_viewPunchAngle = 0x3010;
        
        public const Int32 m_bDormant = 0xE9;
        public const Int32 m_clrRender = 0x70;

        public const Int32 dwClientState_ViewAngles = 0x4D10;
        public const Int32 dwClientState_State = 0x108;
        public const Int32 dwClientState_MaxPlayer = 0x310;

        public static Int32 dwGlowObjectManager = 0x0;
        public static Int32 dwEntityList = 0x0;
        public static Int32 dwClientState = 0x0;
        public static Int32 dwForceJump = 0x0;
        public static Int32 dwLocalPlayer = 0x0;
        public static Int32 dwRadarBase = 0x0;
    }
}
