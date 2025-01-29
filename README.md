# Barricadr

![image](https://github.com/user-attachments/assets/1d95f2b2-b2f4-482d-92b2-674ddf322f75)

*Barricadr* is a simple Windows Forms app (written in VB.NET), that lets you quickly generate firewall block/allow rules for an entire directory tree.

This is especially useful for blocking games you don't want going online, or allowing game servers you *do* want to go online.

# Usage

Launch the app, pick a directory, and click one of the buttons to assign firewall rules. Read the help text in the app for more information.

Barricadr requires administrative permissions to function, and will ask for them on startup.

# Requirements

* Windows 7 or later
* [.NET Framework 4.7.2](https://support.microsoft.com/en-us/topic/microsoft-net-framework-4-7-2-offline-installer-for-windows-05a72734-2127-a15d-50cf-daf56d5faec2)
* Presumably an English-language install of Windows, Barricadr interacts and parses the output of `netsh advfirewall` in English (Patches welcome!)

# Acknowledgements

Inspired by [o-Zi-Yu/Windows-Firewall-Rule-Manager](https://github.com/o-Zi-Yu/Windows-Firewall-Rule-Manager/) and [Official-KEX/Firewall-Script](https://github.com/Official-KEX/Firewall-Script) - I wanted a GUI version where I didn't have to move batch files around, so that's what I made!

# License

Barricadr is licensed under the GNU General Public License v3.0:

    Barricadr - Barricade a directory tree from the outside world 
    Copyright (C) 2025 xdpirate

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
