Go here:  http://justblogging.azurewebsites.net/

Azure is awesome.. I might switch to using it for my major project.
I chose to make a generic blog because my project last semester kinda sucked.
I started from a template that had User login out of the box, and then implemented
the blogging functionality and hooked in to the user creation and user login to
write entries into the database that I set up. 

The database has 2 tables, User table and Entry table. The two tables are linked by
UserId. Each user can have as many Blog entries as they wish. In RouteConfig.cs I routed 
the integer after the Index action on the Blog controller to be the UserId and wrote 
several database access methods to get the data from the database, store new users to
the database, and store blog entries to the database. I followed a Service Stack pattern
for database access.