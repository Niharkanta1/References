﻿namespace Externalio.Other
{
    internal class Settings
    {
        public struct OtherControls
        {
            public static int LoadConfig = Keyboard.VK_F5;
            public static int SaveConfig = Keyboard.VK_F4;

            public static int ToggleBunnyhop = Keyboard.VK_F6;
            public static int ToggleTrigger = Keyboard.VK_F7;
            public static int ToggleGlow = Keyboard.VK_F8;
            public static int ToggleRadar = Keyboard.VK_F9;
            public static int ToggleAimbot = Keyboard.VK_F10;
            public static int ToggleChams = Keyboard.VK_F11;
        }

        public struct Radar
        {
            public static bool Enabled = true;
        }

        public struct Bunnyhop
        {
            public static bool Enabled = true;
            public static int Key = Keyboard.VK_SPACE;
        }

        public struct Trigger
        {
            public static bool Enabled = true;
            public static int Key = Keyboard.VK_MENU;
            public static int Delay = 0;
        }

        public struct Chams
        {
            public static bool Enabled = true;

            public static bool Enemies = true;
            public static float Enemies_Color_R = 255f;
            public static float Enemies_Color_G = 255f;
            public static float Enemies_Color_B = 255f;
            public static float Enemies_Color_A = 255f;

            public static bool Allies = false;
            public static float Allies_Color_R = 255f;
            public static float Allies_Color_G = 255f;
            public static float Allies_Color_B = 255f;
            public static float Allies_Color_A = 255f;
        }

        public struct Glow
        {
            public static bool Enabled = true;
            public static int PlayerColorMode = 0;
            public static bool FullBloom = true;

            public static bool Snipers = true;
            public static float Snipers_Color_R = 155;
            public static float Snipers_Color_G = 89;
            public static float Snipers_Color_B = 182;
            public static float Snipers_Color_A = 255;

            public static bool Rifles = true;
            public static float Rifles_Color_R = 52;
            public static float Rifles_Color_G = 152;
            public static float Rifles_Color_B = 219;
            public static float Rifles_Color_A = 255;

            public static bool MachineGuns = true;
            public static float MachineGuns_Color_R = 52;
            public static float MachineGuns_Color_G = 73;
            public static float MachineGuns_Color_B = 94;
            public static float MachineGuns_Color_A = 255;

            public static bool MPs = true;
            public static float MPs_Color_R = 46;
            public static float MPs_Color_G = 204;
            public static float MPs_Color_B = 113;
            public static float MPs_Color_A = 255;

            public static bool Pistols = true;
            public static float Pistols_Color_R = 236;
            public static float Pistols_Color_G = 240;
            public static float Pistols_Color_B = 241;
            public static float Pistols_Color_A = 255;

            public static bool Shotguns = true;
            public static float Shotguns_Color_R = 230;
            public static float Shotguns_Color_G = 126;
            public static float Shotguns_Color_B = 34;
            public static float Shotguns_Color_A = 255;

            public static bool C4 = true;
            public static float C4_Color_R = 231;
            public static float C4_Color_G = 76;
            public static float C4_Color_B = 60;
            public static float C4_Color_A = 255;

            public static bool Grenades = true;
            public static float Grenades_Color_R = 241;
            public static float Grenades_Color_G = 196;
            public static float Grenades_Color_B = 15;
            public static float Grenades_Color_A = 255;

            public static bool Enemies = true;
            public static float Enemies_Color_R = 192;
            public static float Enemies_Color_G = 57;
            public static float Enemies_Color_B = 43;
            public static float Enemies_Color_A = 255;

            public static bool Allies = false;
            public static float Allies_Color_R = 39;
            public static float Allies_Color_G = 174;
            public static float Allies_Color_B = 96;
            public static float Allies_Color_A = 255;
        }

        public struct Aimbot
        {
            public static bool Enabled = true;
            public static float Fov = 10f;
            public static int Bone = 8;
            public static float Smooth = 15f;
            public static bool RecoilControl = true;
            public static float YawRecoilReductionFactory = 2f;
            public static float PitchRecoilReductionFactory = 2f;
            public static bool Curve = false;
            public static float CurveY = 0.5f;
            public static float CurveX = 10f;
        }
    }
}
