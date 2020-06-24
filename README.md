This repo consists of two projects:

	1. PhoneBookAPI:
		An ASP.NET Core(V3.1) C# Web API (Preferred IDE: Visual Studio for Mac)
		The Phone Book API creates a SQL Lite Database (V3) file on start up which is used as the data store that the API persists.

	2. PhoneBook:
		A web client written with Vue.js (Preferred IDE: IntelliJ)


Setup Guide

API Setup:
	1. Open the project and install relevant nugget packages.
	2. Run the API and make note of your localhost URL including your port (usually https://localhost:8080 - but dependent)


Application Setup:
	1. Open the project and run the npm install command


Setup to have the application talking to your local API:
	1.Configure the client to call your local API by updating the API configuration:
		2.1 Locate the config.js file within PhoneBook/src
		2.2 Within the function, update var URL ='http://localhost:5001/' value, to your local running Web API. Do not change any other API URLs.


Running the application:
	1. Ensure your API is running (your database should have been created on start up in API setup)
	2. Within the application IDE, run the command npm run dev to run the application
	3. The application page should display in your browser with a phone book and list of contacts

Encountered CORS errors?
	1. CORS has been enabled on the API within the dependency injection container, however I still ran into CORS issues and installed a chrome extension to bypass these issues. Obviously not ideal in the real world, but for this app it will do:
		Extension - https://chrome.google.com/webstore/detail/cors-unblock/lfhmikememgdcahcdlaciloancbhjino?hl=en
	If you do use this extension, please remember to double check your API URL as your port could have been update after install.
	Also remember to remove it from your Dev machine once done :)


In addition to what I have provided, the following are all TODO's for real world development, but due to time constraints did not make it in to this app:
	1. Unit testing on both the API and the application.
	2. Proper SQL DB management with SQL scripts (stored crocs, functions, database creation etc)
	3. Error handling
	4. Logging and Metrics
	5. CORS working
	6. Documentation
