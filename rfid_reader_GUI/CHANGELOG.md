# Changelog - RFID Reader

All notable changes to this project and libraries will be documented in this file.

## [0.0.2] - 2023-06-11
### Added:
- added LIB class RFID_reader - include: main class to connect with SP and second with commands (all available commands are supported)

### Changed:

### Fixed:
- Serial Port support - now object of _spc is created correctly in class RFID_reader

### Known Issues:

### Deleted:

*******************************************************************************************************************************

## [0.0.1] - 2023-06-04
### Added:
- combobox with a serial port list - with a solution which is preventing to show Bluetooth COM ports on the list
- button Connect - it works correctly
- SerialPortController class - it's a basic version, but works correctly
- button Add a card - sends a command "dk" to the reader and turn on adding card procedure - works OK

*******************************************************************************************************************************