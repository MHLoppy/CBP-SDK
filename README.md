# CBP SDK
A simple SDK that allows for the creation of plugins for [CBP Launcher](https://github.com/MHLoppy/CBP-Launcher).

### Usage
1) Create a C# class library using .NET Framework (4.7.2 is what's been vetted; I'm unsure on compatibility with other versions).
2) Download or build the CBP SDK dll. Add a reference to the CBP SDK dll in your project.
3) In your class library's class, add a using statement that references the SDK (`using CBPSDK;`).
4) Inherit from the CBP SDK. (`public class ClassName : IPluginCBP`)
5) Provide the required 4 strings and 3 bools.
6) Provide the required 3 void functions (each of these should expect two string overloads, but they're not forced to use them).

* **CBPCompatible** refers to compatibility with CBP mod itself. Mods which have balance/gameplay changes are an example of incompatible mods which would need to be unloaded in order to use CBP.
* **IsSimpleMod** refers to whether the plugin is just a mod requiring installation in the local mods folder (`= true`), or if it has its own separate functionality (`= false`).
* **DoSomething** is executed when the plugin is detected (CBP Launcher scans the user's Workshop mod folders for compatible plugins). It's recommended that DoSomething includes CheckIfLoaded. DoSomething is also a good place to declare paths such as the mod's Workshop folder.
* **LoadPlugin** and **UnloadPlugin** are used for loading and unloading the plugin respectively. For simple mods, this may just mean copying or deleting mod files respectively.
* **CheckIfLoaded** should provide some kind of persistence about whether the mod is loaded or not. A simple way of doing this is to create a text file in `Rise of Nations/CBP` that stores a bool, then read and edit that file as required.

The two strings provided to all three void functions are the user's RoN Workshop mods folder and the user's RoN local mods folder. You're free to use or ignore these as you see fit, but when writing the functions they must include two string overloads even if you don't use them.

### Examples
* [CBP Rise of Humanity Plugin](https://github.com/MHLoppy/CBP-RoH-Plugin)
