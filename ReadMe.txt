## Synopsis
This is Domain's code challenge sample code for detecting properties that already exist in our database.

The main requirement was implementing IPropertyMatcher interface and apply different policies based on
the agency code of properties.


## Notes about how to use code :

The main class that handles all the required logic in the spec is : PropertyMatchContext

According to the Strategy Pattern there should be a SetStrategy() method and a Strategy field in this class
but I assumed that we want to create just 1 PropertyMatchContext object and call its IsMatch method many
times and possibly in different threads in parallel. So I embeded the setting and running the strategy
both in the IsMatch() method. So that consumers just need to create an instance of the context and just call
its IsMatch() method.

var context=new PropertyMatchContext();
foreach( ... )
{
	var isUpdate = context.IsMatch(agencyProp,databaseProp);
	...
}


## Assumptions made :
 
- Comparisons are supposed to be case-insensitive
- Duplicate Whitespaces should be ignored
- Name and addresses should be trimmed before comparing
- IsMatch method is going to be called many times so I tried to avoid throwing exceptions
  and just returned false to avoid performance issues



## Tests

Tests are just for sample and they could be more comrehensive to cover more possible errors
I could have used NUnit but I thought its better not to have any NuGet dependencies for
this sample.

If you are using VS Test explorer group the tests by class for better visibility over tests.
