run this in package manager console to update model with your local data base
--------------------------------------------------------------------------------
Scaffold-DbContext {Conection string} Microsoft.EntityFrameWorkCore.SqlServer -outputdir Models -context schoolDbContext -contextdir Data -DataAnnotations -Force



change connection string in your appsettings.json to your local conn string
---------------------------------------------------------------------------------