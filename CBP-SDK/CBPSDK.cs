﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBPSDK
{
    public interface IPluginCBP
    {
        string PluginTitle { get; }
        string PluginVersion { get; }
        string PluginAuthor { get; }
        bool CBPCompatible { get; }//is the plugin/mod compatible with CBP itself? if not, CBP will have to be unloaded to run the mod
        bool DefaultMultiplayerCompatible { get; }//in many ways a subset of CBPCompatible (should never be true if CBPCompatible is false, but in rare cases the reverse is possible): if only one player is using the mod, would multiplayer OoS?
        string PluginDescription { get; }
        bool IsSimpleMod { get; }//is the mod/plugin basically just the loading mechanism for a simple RoN mod which just needs to have files copied (true), or is it more like a mini-program (false)
        string LoadResult { get; set; }


        void DoSomething(string workshopModsPath, string localModsPath);//cannot do UI interrupts (e.g. messagebox)
        bool CheckIfLoaded();//must persist between sessions; cannot do UI interrupts (e.g. messagebox)
        void LoadPlugin(string workshopModsPath, string localModsPath);
        void UnloadPlugin(string workshopModsPath, string localModsPath);
        void UpdatePlugin(string workshopModsPath, string localModsPath);
    }
}
