using System;
using System.Collections.Generic;

using Externalio.Other;
using Externalio.Features;
using Externalio.Managers;

namespace Externalio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"Externalio - Build ({ Extensions.AssemblyCreationDate() })";

            Globals.Proc.Process = Extensions.Proc.WaitForProcess(Globals.Proc.Name);

            Extensions.Proc.WaitForModules(Globals.Proc.Modules, Globals.Proc.Name);

            MemoryManager.Initialize(Globals.Proc.Process.Id);

            List<string> outdatedSignatures = Offsets.ScanPatterns();

            if (outdatedSignatures.Count > 0) 
            {
                foreach (string sig in outdatedSignatures) Extensions.Error($"> Outdated Signature: { sig }", 0, false);

                Console.ReadKey();

                Environment.Exit(0);
            }

            Config.Load();

            /* Temp */
            Extensions.Information("---------------------------------------------]", true);
            Extensions.Information("[TempMessage] Config Save:     F4", true);
            Extensions.Information("[TempMessage] Config Load:     F5", true);
            Extensions.Information("---------------------------------------------]", true);
            Extensions.Information("[TempMessage] Toggle Bunnyhop: F6", true);
            Extensions.Information("[TempMessage] Toggle Trigger:  F7", true);
            Extensions.Information("[TempMessage] Toggle Glow:     F8", true);
            Extensions.Information("[TempMessage] Toggle Radar:    F9", true);
            Extensions.Information("[TempMessage] Toggle Aimbot:   F10", true);
            Extensions.Information("[TempMessage] Toggle Chams:    F11", true);
            Extensions.Information("---------------------------------------------]", true);

            ThreadManager.Add("Watcher", Watcher.Run);
            ThreadManager.Add("Reader", Reader.Run);

            ThreadManager.Add("Bunnyhop", Bunnyhop.Run);
            ThreadManager.Add("Trigger", Trigger.Run);
            ThreadManager.Add("Glow", Glow.Run);
            ThreadManager.Add("Radar", Radar.Run);
            ThreadManager.Add("Aimbot", Aimbot.Run);
            ThreadManager.Add("Chams", Chams.Run);

            ThreadManager.ToggleThread("Watcher");
            ThreadManager.ToggleThread("Reader");

            if (Settings.Bunnyhop.Enabled) ThreadManager.ToggleThread("Bunnyhop");
            if (Settings.Trigger.Enabled) ThreadManager.ToggleThread("Trigger");
            if (Settings.Glow.Enabled) ThreadManager.ToggleThread("Glow");
            if (Settings.Radar.Enabled) ThreadManager.ToggleThread("Radar");
            if (Settings.Aimbot.Enabled) ThreadManager.ToggleThread("Aimbot");
            if (Settings.Chams.Enabled) ThreadManager.ToggleThread("Chams");
        }
    }
}
