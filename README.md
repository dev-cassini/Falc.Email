# FALC Email Service #

## Development ##

### Entity Framework ###

#### Migrations ####

To add a new migration, run the following command from the infrastructure project directory:

```powershell
dotnet ef migrations add MIGRATION_NAME_HERE --output-dir .\Persistence\EntityFramework\Migrations\
```