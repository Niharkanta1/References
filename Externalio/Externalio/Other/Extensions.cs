using System;
using System.Linq;
using System.Drawing;
using System.Numerics;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;

using Externalio.Managers;

namespace Externalio.Other
{
    internal class Extensions
    {
        public static DateTime AssemblyCreationDate()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.MinorRevision * 2);
        }

        public static void Information(string text, bool newLine)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if (newLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Error(string text, int sleep, bool closeProc)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(text);

            Thread.Sleep(sleep);

            if (closeProc) Environment.Exit(0);
        }

        internal class Other
        {
            public static Vector3 GetBonePos(int entity, int targetBone)
            {
                int boneMatrix = MemoryManager.ReadMemory<int>(entity + Offsets.m_dwBoneMatrix);

                if (boneMatrix == 0) return Vector3.Zero;

                float[] position = MemoryManager.ReadMatrix<float>(boneMatrix + 0x30 * targetBone + 0x0C, 9);

                if (!position.Any()) return Vector3.Zero;

                return new Vector3(position[0], position[4], position[8]);
            }

            public static int GetClassID(int id)
            {
                int classID = MemoryManager.ReadMemory<int>(id + 0x8);
                int classID2 = MemoryManager.ReadMemory<int>(classID + 2 * 0x4);
                int classID3 = MemoryManager.ReadMemory<int>(classID2 + 1);
                return MemoryManager.ReadMemory<int>(classID3 + 20);
            }
        }

        internal class Colors
        {
            public static Color FromHealth(float percent)
            {
                if (percent < 0 || percent > 1) return Color.Black;

                int red, green;

                red = percent < 0.5 ? 255 : 255 - (int)(255 * (percent - 0.5) / 0.5);
                green = percent < 0.5 ? (int)(255 * percent) : 255;

                return Color.FromArgb(red, green, 0);
            }
        }

        internal class Proc
        {
            public static bool IsWindowFocues(Process procName)
            {
                IntPtr activatedHandle = Globals.Imports.GetForegroundWindow();

                if (activatedHandle == IntPtr.Zero) return false;

                Globals.Imports.GetWindowThreadProcessId(activatedHandle, out int activeProcId);

                return activeProcId == procName.Id;
            }

            public static Process WaitForProcess(string procName)
            {
                Process[] process = Process.GetProcessesByName(procName);

                Information($"> waiting for { procName } to show up", false);

                while (process.Length < 1)
                {
                    Information(".", false);

                    process = Process.GetProcessesByName(procName);

                    Thread.Sleep(250);
                }

                Console.Clear();

                return process[0];
            }

            public static void WaitForModules(string[] modules, string procName)
            {
                List<string> loadedModules = new List<string>(modules.Length);

                Information($"> waiting for { modules.Count() } module(s) to load", false);

                Process[] process;

                while (loadedModules.Count < modules.Length)
                {
                    Information(".", false);

                    process = Process.GetProcessesByName(procName);

                    if (process.Length < 1) continue;

                    foreach (ProcessModule module in process[0].Modules)
                    {
                        if (modules.Contains(module.ModuleName) && !loadedModules.Contains(module.ModuleName))
                        {
                            loadedModules.Add(module.ModuleName);

                            switch (module.ModuleName)
                            {
                                case "client.dll":
                                    Structs.Base.Client = module.BaseAddress;
                                    break;
                                case "engine.dll":
                                    Structs.Base.Engine = module.BaseAddress;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    Thread.Sleep(250);
                }

                Console.Clear();
            }
        }
    }
}
