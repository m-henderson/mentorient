# Mentorient
a web applicataion for landlords to manage tenants, properties, and parts. 

# About
this project is very new and is great for first time or long time contributors. The application is running on a subdomain of azurewebsites.net until we get an application that is usable. Right now, there is some functionality but a lot of work lef todo. 
When the community sees fit (the community is you and I) then I will go ahead  and route the main domain name to the application so that consumers can start using the application. 

# Contributing
1. fork the application 
2. clone the app to your commputer `git clone https://github.com/your-user-name/mentorient`
3. run `git remote add upstream https://github.com/mentorient/mentorient`
4. make sure you are on the master branch and run `git pull --rebase upstream master`. This will make sure you are up-to-date with the main repo. 
5. Create a branch, fix or add something, commit your code, then create a pull request. 

# Running on Dev Machine
1. cd into the folder that contains mentorient.csproj
2. `dotnet restore`
3. `dotnet ef database update`
4. `dotnet run`

I have CI/CD setup on the server. so, if your pull request is merged, the server will test the build then push the code to production. 
If you have anyquestions feel free to create an issue. 
