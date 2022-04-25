# rcm-automation
UI/API Automation for RCM

RCM automation tests will be run either locally inside Visual Studio or as part of the 'testing' segment of a CI/CD pipeline.

In order to run tests locally inside Visual Studio after pulling the latest 'rcm-automation' repo from GitHub:

'Build > Build Solution' in order to download required packages and verify solution is good.

Open 'Test Explorer' by clicking 'Test > Test Explorer'. You should see 'RCM' as the parent test, and children such as 'Calls' and 'Claims'.

Right-click the test/category and select Run/Debug to run the test(s).
