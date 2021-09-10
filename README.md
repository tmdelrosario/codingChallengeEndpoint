# codingChallengeEndpoint
create a list of transaction endpoint that returns JSON format

OVERVIEW
I created an API that returns an account balance and a list of payment of the user (date, amount, status) and sorted by the latest date. 
E.G. 
- account balance: 25000.00
- payment list:
--  date: 9/10/2021
--  amount: 2500.00
--  status: PENDING,,
--  date: 9/9/2021
--  amount: 3500.00
--  status: CLOSED
  
HOW TO RUN
- open project solution
- run program with Visual Studio
- You can call the API thru .../api/values/{number id}

EXAMPLE ID WITH DATA
/api/values/1
/api/values/2

FLOW
- call the API function
- get all the payments with the specific user id
- get the account balance of the user id
- put the data model into object
- return object to JSON format

DATA USED:
- Local DB
- Tables with stored procedure and Entity Framework calling on API
- You can manipulate the data thru local db server in visual studio (insert tblUser first before inserting to tblPayment table)

TECHNOLOGIES USED:
- Visual Studio 2019
- SQL DB
- Web API
- Internet Browser

PATTERNS USED:
MVC Patter

SECURITIES:
- Used stored procedure then use Entity Framework for more secure when doing SQL queries. It's easier to track changes to the database though a single point of access, controlled by your applications, rather than through any number of interfaces.
