### TODO

- App.config / Login - Dynamically change between multiple potential users, defined in the App.config
- "Given I log in with well-connected credentials" step
- Modify all MainPage.WaitForSidePanel to just one, other .WaitFor.
- Change README.md to perfectly define workflow, including how to contribute to the CHANGELOG.md & TODO.md.

### FIXME

-

### NOTES

- It will be *_expected_* from now that steps which perform granular actions will have dynamic waits as their first method. This means that methods which perform granular actions will _not_ have waits at the end of their definitions.