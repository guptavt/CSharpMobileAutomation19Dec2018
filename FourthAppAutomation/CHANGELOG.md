# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [Unreleased]
### Added/Changed/Deprecated/Removed/Fixed/Security

### Added
- .feature / Step Definition / Page Objects for Notifications -- A

### Changed
- App.config contains two accounts to be used. Currently, change between the two is done _by hand_.
- All steps that perform actions will be implied, from now on, to _first wait_ so that their action can finish. These same steps will not have wait times as their last action.

### Fixed
- Google Chrome will now go into full-screen mode on all OS, with `--kiosk` mode. (.config change)



## [0.0.1] - 2017-??-??
### Added
- Login -- A
- Logout -- A
- Connected Apps -- A

[Unreleased]: https://github.com/fourth/FourthEngageWebMobileAutomation/compare/US28504-Notifications-A
[0.0.1]: https://github.com/fourth/FourthEngageWebMobileAutomation/commit/72b8e9eabe7f09b9b566d6180870b67fc920683a
