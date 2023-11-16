

Initial: 
add-migration "Initial Migration" -StartupProject PhoneNumberChecker.Web.Server -Project PhoneNumberChecker.Data.Access -Context DataContext
```
To add further migrations, modify the data entities, then run the add-migration commands again, eg
```
add-migration "Modified XYZ" -StartupProject PhoneNumberChecker.Web.Server -Project PhoneNumberChecker.Data.Access -Context DataContext

```
creating / updating database
Update-Database -StartupProject PhoneNumberChecker.Web.Server -Project PhoneNumberChecker.Data.Access -Context DataContext