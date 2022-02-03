# CBP SDK
A simple SDK that allows for the creation of plugins for [CBP Launcher](https://github.com/MHLoppy/CBP-Launcher).

### Usage
1) Create a C# class library using .NET Framework (4.7.2 is what the SDK uses - I have no idea what compatibility that implies for other versions or even .NET core).
2) Download or build the CBP SDK dll. Add a reference to the CBP SDK dll in your project.
3) In your class library's class, add a using statement that references the SDK (`using CBPSDK;`).
4) Inherit from the CBP SDK. (`public class ClassName : IPluginCBP`)
5) Provide the required 5 public strings and 4 public bools.
6) Provide the required 4 public void functions (each of these should expect two string overloads, but they're not forced to use them).
7) Build your DLL, then publish it as part of a RoN:EE mod on the Steam Workshop. CBP Launcher automatically finds compatible DLLs in a user's Workshop files.

### Strings/bools:
* **PluginTitle**, **PluginDescription**, **PluginAuthor**, and **PluginVersion** are all simple strings that are used to populate the UI with information about the plugin for the user.
* **CBPCompatible** refers to compatibility with the CBP mod itself. Mods which have balance/gameplay changes are an example of incompatible mods (`= false`) which would need to be unloaded in order to use CBP.
* **DefaultMultiplayerCompatible** in many respects can be logically considered a subset of `CBPCompatible`. This bool is for whether using the plugin can cause multiplayer incompatibility (OoS) if not used by all players in a lobby. Directly modifying sound.xml is an example of a plugin that would report `false`. Adding an updated balance.xml file to the game via the local mods folder, or directly modifying the existing balance.xml file are examples of a plugins that should report `true`.
* **IsSimpleMod** refers to whether the plugin has a single, simple function (e.g. just loads/unloads a local mod `= true`), or if it has its own separate functionality (`= false`).
* **LoadResult** is optionally used to display/log a message after plugins are loaded / unloaded etc (current implemention in the plugin loader is not set in stone). It is the only property that is not read-only. It can be populated with an error message if an error occurs during loading, or a confirmation of successful loading if no error occurred. It can also optionally be left null, in which case successful loading is assumed, but explicitly modifying the value based on the result of other functions is recommended.
* **CheckIfLoaded** should run a check to dynamically check whether the plugin is loaded or not (and this should persist between sessions if no new load/unload actions are taken). A simple way of doing this is to create a text file in `Rise of Nations/CBP` that stores a bool, then read and edit that file as required. This function SHOULD NOT use UI interrupts such as MessageBox.

### Functions:
* **DoSomething** is executed when the plugin is detected (CBP Launcher scans the user's Workshop mod folders for compatible plugins). It's recommended that DoSomething includes CheckIfLoaded. DoSomething is also a good place to declare paths such as the mod's Workshop folder. This function SHOULD NOT use UI interrupts such as MessageBox except on its first-time run sequence.
* **LoadPlugin** and **UnloadPlugin** are used for loading and unloading the plugin respectively. For simple mods, this may just mean copying or deleting mod files respectively.
* **UpdatePlugin** can be used by simple mod loaders to keep local mod files up to date. For plugins not requiring this functionality, the implemented function can be empty.

The two strings provided to all four void functions are the user's RoN Workshop mods folder and the user's RoN local mods folder. You're free to use or ignore these as you see fit, but when writing the functions they must include two string overloads even if you don't use them.

### Plugin Examples
* GUI: [CBP Rules.xml Editor Plugin](https://github.com/MHLoppy/CBP-RE-Plugin)
* GUI: [CBP Sound.xml Editor Plugin](https://github.com/MHLoppy/CBP-SE-Plugin)
* MessageBox GUI only: [CBP Player Colors/Numbers Overlay Plugin](https://github.com/MHLoppy/CBP-PCN-Plugin)
* MessageBox GUI only: [CBP Rise of Humankind Plugin](https://github.com/MHLoppy/CBP-RoH-Plugin)
