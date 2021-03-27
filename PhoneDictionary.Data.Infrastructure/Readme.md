# Migration use:

## Move to directory of migrations
cd .\PhoneDictionary.Data.Infrastructure\

## Execute migration command:
dotnet ef migrations add <Migration_Name> -s ..\PhoneDictionary.API\

### Update database for start-up project *(if needed)
dotnet ef database update -s ..\PhoneDictionary.API\
