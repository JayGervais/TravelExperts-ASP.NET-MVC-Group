# TravelExperts-ASP.NET-MVC-Group
Travel Experts Final Group Project for ASP.NET

Below are the guidelines followed for the following project:

Construct this page to enable the form data to be sent to an ASP.NET page that will verify the data and either re-display the form with appropriate error messages, or create acustomer record.

The database that will be used for this workshop is the SQL Server database that was loaded during the SQL Server database course.  The database will need a modification tostore the customer’s user-id and password which will enable them to log in later.

Validations that are required:
-verify that all required fields have been filled-in – business phone and email are optional since many of our customers are seniors who are retired and may not use email (one question you may want to ask the Travel Experts managers is whether it is likely that customers with the Internet skills to use a web browser to set up an account would not have an email address)
-check that the postal code has the correct format – we are not concerned about U.S. zip codes at present, but if you want to demonstrate how that could be done, please build it.
- ensure that the phone number is composed of numeric digits and has an area code
- ensure that the password has been entered twice and the entries are equal

At this point in the project, the agentID will be null when the customer record is created.  The customer will be assigned to an agent later.
