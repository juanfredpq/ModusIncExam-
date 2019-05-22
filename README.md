# ModusIncExam-
Modus interview repository
This is a test

In order to run the testscripts you have execute the following steps:

1. Clone the following project https://github.com/NivNavick/trxer.git , once you got it, please compile it with VS2017. 
2. Create a folder in C:\Program Files (x86) like "TrxerConsole" and then copy the bin folder that the project generated after the compiled process.

3. Clone the project https://github.com/juanfredpq/ModusIncExam-.git
4. Compile it once you have it in your local environment.
5. Open a Developer Command Prompt for VS 2017
6. Using MSTest.exe tool, we are going to execute the testscripts using the following lines:

"C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\mstest" /testcontainer:"C:\Users\<YOUR USER>\source\ModusLite\e2e\ModusIncExam-\ModusInc\ModusInc\bin\Debug\ModusInc.dll" /resultsfile:"C:\Users\<YOUR USER>\source\ModusLite\e2e\ModusIncExam-\ModusInc\ModusInc\bin\Debug\Result.trx"
"C:\Program Files (x86)\TrxerConsole\bin\Debug\TrxerConsole.exe"  "C:\Users\<YOUR USER>\source\ModusLite\e2e\ModusIncExam-\ModusInc\ModusInc\bin\Debug\Result.trx"

You will able to see the report in html
