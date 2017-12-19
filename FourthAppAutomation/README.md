# Hello

This repository is maintained by the Fourth App Team and contains the C# source code to our current automation effort,
spanning both Web and real Mobile Device testing.

## Things to note

We're building everything on **macOS** machines, with **Xamarin Studio** and on the **Mono Framework**. As our underlying
Automation Framework, build by the QA Architecture (formerly Tech QA) Team, works on all platforms, this ensures that our
code can be compiled and executed on Windows / macOS / Linux. 

In order to get everything set up properly for further development, follow the excellent guides on Confluence, [linked](https://fourthlimited.atlassian.net/wiki/display/EN/Setup+Mobile+Environment)
 [here](https://fourthlimited.atlassian.net/wiki/display/EN/Running+Mobile+Tests).

## Workflow

1. Clone repository
2. Creates a branch
3. Create/Update a Feature/Scenario or Fix a Bug
4. Have you finished?
   - NO 
	 -  Commit your work. 
	 -  Go to item 3 again
    - YES 
	  -  Master into your branch again in order to make sure there are no conflicts
	  -  Push to your remote branch
5. Create a Pull Request in GitHub
   - This should trigger Jenkins to create a job for the Pull Request where it will run the smoke tests in your branch
   - Assign one or more people to review your changes
6. Did the review AND tests passed?
   - NO	(Tests have failed)
	 -  Analyse error logs and fix
	 -  Push to your remote branch again
	 -  Jenkins should trigger the same PR job again
	 -  Go to item 6
   - NO	(Code reviewed not approved)
	 -  Make the required changes
	 -  Push yo your remote branch again 
	 -  Jenkins should trigger the same PR job again
	 -  Go to item 6
   - YES
	 -  Go to GitHub and click on "Merge Branch"
	 -  This should trigger Jenkins to run all your tests on master WITH your changes applied
