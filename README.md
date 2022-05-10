# rcm-automation
UI/API Automation for RCM

RCM automation tests will be run either locally inside Visual Studio or as part of the 'testing' segment of a CI/CD pipeline.


In order to run tests locally inside Visual Studio after pulling the latest 'rcm-automation' repo from GitHub:

1  'Build > Build Solution' in order to download required packages and verify solution is good.

2  Open 'Test Explorer' by clicking 'Test > Test Explorer'. You should see 'RCM' as the parent test, and children such as 'Calls' and 'Claims'.

3  Right-click the test/category and select Run/Debug to run the test(s).

PLEASE NOTE: Tests will most typically be run collectively as part of a suite (e.g., all tests, or just the Claims tests, etc.); however, if a test is run individually, be sure to specify any IDs the test is dependent upon in the NUnit 'TestCase' attribute (e.g., the API_Claims_ClaimEntityBag_GET_AllClaimEntityBags_Sort test needs the OaiClaimId); and be sure to remove the hard-coded ID when finished. The IDs are generated dynamically at the beginning of a test run in order to minimize false positives resulting from external events such as database refreshes.


In order to run the entire test suite from within the GitHub repo:

1  Click 'Actions'.

2  In the 'Workflow' section, click the 'RCM API/UI Automation' Workflow.

3  Click the 'Run Workflow' button. The user should see a 'Use workflow from' branch selector, and an 'environment' selector.

4  Click the build job to monitor progress.