# VehicleAllocation 

Setup 
------------------------------
- Modify app.settings.json file with proper sql connection string to database server 
- Rebuild the solution ( in case nuget restoration problem try to clean the solution first) 
- Run the project in debug mode or in terminal window by extecuting 'VehicleAllocation.Api.exe' from build folder

------------------------------
Execttion of the endpoints 

- Use Postman or othe tool to send post request 

The are 3 availabel endpoints:

POST to  /parking - body structure 

        {
            "VehicleReg": "",
            "VehicleType": ""
        }

POST to /parking/exit = body structure 

        {
            "VehicleReg": ""
        }

GET to /parking 


------------------------------
SAMPLE Database

With first request execution database will be seeded with sample data 
 - Total parking spaces set in the seed is 19 with some already occupied 
 - 9 car spaces is already taken with VehicleReq 'Registration1' up to 'Registration9' with different timeIn  

 ------------------------------
 Assumptions for the project 
 1. Car with VehicleReg can only be set once - no other car with the same VehicleReq is allowed unless it is first deallocated
 2. No more than 19 cars in total is allowed (limit of spaces) 


