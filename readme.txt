AAF2 Release 2.4.0
======================
This requires the Ascom platform 6.1 to be installed first from the Ascom website (http://ascom-standards.org/)

The 3 project components are:

1) A windows installer program (AAF2Setup.msi)

It will install: 
- The Ascom driver for the focuser. This is a windows COM object which should be registered by the installer. 
- A command-line test program, AAF2Test that just reports the focuser version (#V command) from the arduino. 
- A GUI client program, FocusAAF2 that allows full control of the focuser. This is also a work in progress.

Note: If you have a previous version of AAF2 installed then uninstall it first before installing the latest version.

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

Changes in Version 2.4.0
------------------------
Enhancements:
* The Arduino sketch has the following changes:
   - Amended to step the motor in single half-steps not 8 per unit. (One unit is a single step from the driver/application's point of view).
     The number of half-steps to execute per unit of movement is set in MOTOR_STEPS_PER_DRIVER_STEP
	 Set this to 8 (default) to keep the existing behaviour. If you want finer movement lower it as required (may need some experimentation).

   - Moved user-configurable parameters to a single block at top of code for easier location / modification
   - Reduced number of read/write operations to/from EEPROM. This should lengthen the life of the EEPROM storage.
   - Reduced no of calls to clear the output pins in loop()
   - Some general code and structure tidying

* The Ascom Driver has the following changes:
   - Driver Registration should now work correctly (woohoo). The Setup project has had the correct Registry entries added.

   - The trace files are now created in the 'Trace' directory which is a sub-directory of the installation directory. The directory is created
     automatically during installation so no more creating it manually. The location is stored in the Registry so the Driver can access it.

   - The 'Trace on' option in the Ascom Chooser dialog is now unset automatically when the Driver exits. If you need to trace the Driver during
     normal use you will need to tick it every time you use the Driver. This is to save the disk filling up if you forget to turn it off.


Changes in Version 2.3.0
------------------------
Enhancements:
* The Arduino now saves it's current position in EEPROM (non-volatile memory). It will remember the position it was at between
  focuser and client application restarts / disconnects. The chooser dialog has been modified to enable you to override the initial
  starting position if required.
* Some users in countries other than the UK reported issues with the temperature not being interpreted correctly due to the use
  of a dot as the decimal separator. This has been removed and the Arduino now returns the temperature in 100ths of a degree (no decimal).
  The driver has been updated to divide by 100 prior to returning the value to the calling client program. Windows should put
  the correct decimal separator in the value according to the PC's international settings.
  I have also blocked the reading of the 1-wire temperature sensor whilst the motor is moving as it interferes with smooth movement.
  During movement it will return the last read value. When the motor is not moving it will re-read the sensor. This is because many
  client applications seem to read it every second which seems excessive. The FocusAAF2 test program now also reads every second for testing.

Bug fixes:
* Changed some int variables to unsigned int
* Fixed a minor bug in the motor hi/lo speed detection - it was only working in one direction.

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