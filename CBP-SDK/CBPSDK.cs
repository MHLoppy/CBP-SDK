/* This Source Code Form is subject to the terms of the Mozilla Public
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
        string PluginDescription { get; }
        bool IsSimpleMod { get; }//is the mod/plugin basically just the loading mechanism for a simple RoN mod which just needs to have files copied (true), or is it more like a mini-program (false)

        void DoSomething(string workshopModsPath, string localModsPath);
        bool CheckIfLoaded();//must persist between sessions;
        void LoadPlugin(string workshopModsPath, string localModsPath);
        void UnloadPlugin(string workshopModsPath, string localModsPath);
    }
}
