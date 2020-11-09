# ArchimydesTest
This is the ASP.NET WebApi solution for the archimydes test. The apis are written in C# . The database is SQL Server. Unit tests are written using Moq and Nunit Framework. 


The database is created in SQL Server and the database name is Archimydes

The mdf and ldf files for the database and zipped and kept in database folder


The api's are created using asp.net web api , sql server and entity framework database first 

The models are extracted from the service layer 

Unit tests for the models are written using nunit framework 

Integration tests are written using nunit and moq framework. 

The user can signup and login and create user stories

user can create the stories, retrive the stories created by him after login 

the jwt token should be passed in the header authroization 

Admin can get all the stories created by all users 

admin can edit the stories and reject the stories 

Passwords are encrypted and on user signup each user is assigned a jwt token geenrated using jwt nuget package 

the jwt token is validated on each request to update the stories by both user and admin 


Api to create user for both admins and users

Post request 
https://localhost:44373/api/SignUp/

body formdata {
     "FirstName":"justin",
     "LastName":"nancy",
     "Email":"justin123@gmail.com",
     "Password": "password123",
     "Role":"User"
}


Api response { "User successfully created"  } 

Api for Login User 
https://localhost:44373/api/Login/ - Post request 

body {
     "Email":"justin123@gmail.com",
     "Password": "passsword123"
}

Api response

 {
    "Email": "justin123@gmail.com",
    "UserId": 1,
    "Token": "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InBhbmR1Y2hpbm5hQGljbG91ZC5jb20iLCJwYXNzd29yZCI6IjV5S2lERjNXczZmaUlhRlpLb2V6eWszNHhSYXF0R0EyVXVGTjYzT1k2U0U9In0.ERTFqtK9VMGsXZ-ZswF1x8osi33kdq2vTRI-Y7KLABo",
    "Role": "user",
    "FirstName": "justin",
    "LastName": "nancy"
}


Api to create story 

Post request 
https://localhost:44373/api/UserStory/

body 
{
     "Summary":"Create a signup when ever you want page",
     "Description":"Hello",
     "Status":"Rejected",
     "Type":"Medimum",
     "Complexity":"Medium",
     "EstimatedTime":"2020-12-08 18:42:10.6500000"
}


api response - "User story created"


Api to Get all stories 
https://localhost:44373/api/UserStory/

resposne 

[
    {
        "UserStoryID": 1,
        "UserId": 2,
        "Summary": "Create a signup page",
        "Status": null,
        "Description": "Hello",
        "Type": "Medimum",
        "Complexity": "Medium",
        "EstimatedDateTime": "2020-12-08T18:42:10.65"
    },
    {
        "UserStoryID": 2,
        "UserId": 3,
        "Summary": "Create a signup page",
        "Status": null,
        "Description": "Hello",
        "Type": "Medimum",
        "Complexity": "Medium",
        "EstimatedDateTime": "2020-12-08T18:42:10.65"
    },
    {
        "UserStoryID": 3,
        "UserId": 3,
        "Summary": "Create a signup page",
        "Status": null,
        "Description": "Hello",
        "Type": "Medimum",
        "Complexity": "Medium",
        "EstimatedDateTime": "2020-12-08T18:42:10.65"
    },
    {
        "UserStoryID": 4,
        "UserId": 3,
        "Summary": "Create a signup when ever you want page",
        "Status": "Rejected",
        "Description": "Hello",
        "Type": "Medimum",
        "Complexity": "Medium",
        "EstimatedDateTime": "2020-12-08T18:42:10.65"
    },
    {
        "UserStoryID": 5,
        "UserId": 1,
        "Summary": "Create a signup when ever you want page",
        "Status": "Rejected",
        "Description": "Hello",
        "Type": "Medimum",
        "Complexity": "Medium",
        "EstimatedDateTime": "2020-12-08T18:42:10.65"
    }
]

api to update user story 

put request - https://localhost:44373/api/UserStory/

response 
  {
        "UserStoryID": 5,
        "UserId": 1,
        "Summary": "Create a signup when ever you want page",
        "Status": "Rejected",
        "Description": "Hello",
        "Type": "Medimum",
        "Complexity": "Medium",
        "EstimatedDateTime": "2020-12-08T18:42:10.65"
    }
