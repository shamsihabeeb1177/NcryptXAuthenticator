Components

shamsihabeeb1177/NcryptXAuthenticator (github.com) - API Controller and Auth server shamsihabeeb1177/NcryptXProxy-Updated (github.com) - Reverse Proxy Module. shamsihabeeb1177/NcryptX-Radius-Server (github.com) - Skeleton Project for Radius server

Please note that the code uploaded and marked as public is not the etire code, it is just a skeleton project, if you need access to the entire code please contact me at shamsihabeeb@gmail.com

All the above code is written in c# with the asp.net core 6.0, MVC and Entity Framework core frameworks. I am re-coding the reverse proxy module in rust as it provides better memory management. I shall update the link for the repo for the same as soon as it is ready. Radius server is developed in NodeJS and will be deployed as a service.

Below are high level details and status of the project that I am currently working on,

NcryptX is a comprehensive on-premises solution which aims to provide multifactor authentication solution to the Outlook and Mobile email clients. This solution was developed as currently there is a challenge in providing the MFA for email clients unless the customer wishes to go to the cloud, The solution would be ideal for the organizations that are restricted by the respective governing authorities to have a cloud based environment or to send data to cloud.

This solution has about 3 components to it:

NcryptX Reverse Proxy
NcryptX API controller and Auth server
SQL Database
Traffic Flow:

User opens outlook which uses MAPI over http to connect to the exchange server
The autodiscover file is issued to the outlook client post regular authentication, which contains all the connection details of different protocol the client would use
outlook client checks for the MAPI address to connect to.
When the request is received for the MAPI protocol the NcryptX reverse proxy module inspects the http request for the headers which include the username and the device ID which is unique to all outlook clients.
The NcryptX Proxy then Makes an API call to the NcryptX API controller.
The API Controller checks in the database for the username and device id if it is present, if not present, it makes a DB entry for the username and device id in the db and sends out a an sms to the user with the login link for the NcryptX portal to enable the Outlook Device to be able to send or receive emails.
User Logs in to the NcryptX Portal which takes him to the NcryptX API controller and Auth server, logs in with the MFA and enables his device, upon enabling device the NcryptX server makes a db entry to allow the user. (Note - if push method is configured, the user receives a push either to allow or reject the device)
The next time outlook client makes requests to sync email or send email the NcryptX Proxy module would check the API controller , If allowed it would cache the request, create a session and allow the user to pass thru from proxy to the exchange lb and then to the exchange server.
The similar process would be applied for EWS, OAB and Active Sync protocol.

This code is an MVP which has no refactoring and has a lot of static entries, it was done for testing purposes and the test yielded good results. This code would be further enhanced to have a GUI for configuration/ Audit / reporting etc.

Further Enhancements:

Considering the success of the above, I have considered developing this as a complete MFA and SSO solution with the below concept.

NcryptX Authentication server can be used as an MFA solution regardless of its outlook and mobile client capabilities. Integrations to this server could be done VIA API or Radius server (The skeleton code for radius server is ready and is built using nodejs. the radius server is tested using the ntradping utility and has worked successfully) alternatively it could also be integrated VIA API (This is still in the development phase) where other solutions would call the authenticate API of NcryptX and provide username and password in json, or xml format, the server would provide a result output if the authentication is successful which can be used by the target systems to authenticate the users) Methods of authentication: Google Authenticator - Developed and tested Microsoft Authenticator - Developed and tested SMS - Developed and tested. Push - In development FIDO tokens and other hardware tokens - In development. AD connector is developed, and the user database is synced from the AD or local DB can be used
SAML IDP for OIDC and SAML Authentication and authorization - This is now developed and under testing.
Flow:

Target system offloads its authentication to NcryptX

Target System integrates with NcryptX via radius or via API

If request is received on the radius server, the radius server parses the request and gets the username, password and makes an internal API call to the authenticate API, and the authenticate API runs its code and provides a response, based on the response Radius-Accept or Radius-Reject is sent. If a request is received directly on the authenticate API it runs the internal code and provides the appropriate response.

Based on the response returned the target system makes a decision.

Use NcryptX Reverse Proxy as a shield to applications that do not support api or radius integration (legacy apps) or even to use this as a second factor first sort of a solution where the user needs to allow access to the webpage.

for example - an organization which has a lot of applications hosted on the internet would find this solution appropriate.

Concept/ Idea:- (This is yet to be developed)

1)Spawn an instance of the reverse proxy code used for exchange but without the validation as different type of validation would be used here. 2)user enters the url to access the web application which is hosted behind the NCryptX reverse proxy 3)a blank html page is provided to the user with just a pop up to enter the username. This protects the external web applications that are hosted on the internet from recon. User enters the username, and the proxy gets the username and checks for the url the user is trying to access and validates if the user has access to the application either by checking its manual definitions or by checking an AD group. if the user does not have access, throws an error "No access" and if the user has access it would then send a push notification to the user to allow access if it is him who is trying to access, upon allowing the access the session is cached and is allowed to the landing page of the external application which could have its native authentication configured and then the user enters the username and password and logs in. This process would also enable to track the entire web activity done by the user and this data could be used further to develop other modules for audit purposes etc.

Components and their development progress

NcryptX Reverse proxy for exchange - done and tested however it needs more enhancement, i am currently refactoring the code and writing it in Rust. The current version is written in c# and is deployed as an IIS app, The NcryptX Proxy updated repo has the code required to validate an outlook client, activesync and ews is tested but the component needs some more enhancement, so it is not yet added to the repo.

NcryptX API Module - almost completed api security to be added.

NcryptX Auth server : TOTP - done and tested HOTP - to be developed EOTP - In progress Radius - tested but needs enhancement and some workflow alterations. API - In process. Admin GUI - Inprogress / Half Done AD Connector - Done and tested.

NcryptX IDP server for sso : Developed, Testing in progress.
