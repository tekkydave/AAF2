AAF2 Release 2.1.1
======================
This requires the Ascom platform 6.1 to be installed first from the Ascom website (http://ascom-standards.org/)

The two components are:

1) A windows installer program (AAF2Setup.msi)

It will install: 
- The Ascom driver for the focuser. This is a windows COM object which should be registered by the installer. 
- A command-line test program, AAF2Test that just reports the focuser version (#V command) from the arduino. 
- A GUI client program, FocusAAF2 that allows full control of the focuser. This is also a work in progress.

2) An Arduino sketch (AAF2.ino)
- This needs to be uploaded to the Arduino in your focuser.

See the Wiki section of this project for detailed build instructions.

Changes in Version 2.1.1
------------------------
Hopefully I have fixed the issue with the COM object not being automatically registered.

Changes in Version 2.1.0
------------------------
Changes to look of FocusAAF2 test program:
	- Buttons now display the number of steps they action up/down.
	- Some colour added to make it less boring.

Version 2.0.0
-------------
Initial Release