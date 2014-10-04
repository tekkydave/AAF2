AAF2 Release 2.2.0
======================
This requires the Ascom platform 6.1 to be installed first from the Ascom website (http://ascom-standards.org/)

The 3 project components are:

1) A windows installer program (AAF2Setup.msi)

It will install: 
- The Ascom driver for the focuser. This is a windows COM object which should be registered by the installer. 
- A command-line test program, AAF2Test that just reports the focuser version (#V command) from the arduino. 
- A GUI client program, FocusAAF2 that allows full control of the focuser. This is also a work in progress.

2) An Arduino sketch (AAF2.ino)
- This needs to be uploaded to the Arduino in your focuser.

3) Two Arduino Libraries that support the 1-wire and Temperature Sensor functions used by the sketch. 
   You will need to install these in order to compile and upload the sketch even if you don't intend to connect a temperature sensor.
   The libraries are in the Files section of this site along with the other files.
   - OneWire.zip
   - DallasTemperature.zip

   Note that the focuser will still work without the temperature sensor attached but it will always give a temperature reading of 0C.

   If you are unsure about how to install Libraries see the instructions here: http://arduino.cc/en/Guide/Libraries
   Under the section 'Automatic installation' there are clear instructions on how to install the library zip files via the Arduino IDE.
   Install the two libraries before trying to Compile & Upload the sketch to your Arduino device.

See the Wiki section of this project for detailed build instructions.

Changes in Version 2.2.0
------------------------
Implemented Temperature Sensing.
Arduino Sketch - Implemented C# command. Uses 1-wire DS18B20. New functionality requires two Libraries.
  Ascom Driver - Implemented Ascom Temperature property.

Changes in Version 2.1.3
------------------------
Implemented the Ascom Halt function.
Added new Arduino sketch command Innnn#. This allows an initial position nnnn to be set. A textbox has been added to the
chooser properties so initial position can be set by user. Position is remembered between disconnect/connect.

Changes in Version 2.1.2
------------------------
Changes to prevent negative positions:
Arduino Sketch - This has been updated to have a start position of 1000.
  Ascom Driver - This has been amended so negative positions cannot be achieved.

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