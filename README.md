# Coding-Challenge
The following should take approximately 2 hours. If you find that you are not going to complete all the requirements in that time, note where and how you would have addressed them in the code. You will also have an opportunity to discuss these points.
The template code to get you started is located at https://github.com/clark-marketplace/Coding-Challenge

#### PLEASE NOTE: You may need to install .NET Core 3.1 sdk if you don’t already have it – you may also need to use VS 2017 or higher (free versions are available for both).
Please download this code, complete the exercise, and then upload to your own repository.

**The Problem**: Design a web based mailing list application. The following requirements are relatively simple, but the application should be designed so that it could be used as the basis for a more complete implementation. In other words, use sound design patterns and coding practices.
Requirements:
1.	Provide a simple html page in which a user can enter the following. The page merely needs to be functional and does not need to be styled in any way.
    *	Last Name
    *	First Name
    *	Email
2.	When the user submits this data, the input should be validated against the following rules. Any validation errors should be presented to the user.
    *	First Name cannot be empty
    *	Last Name cannot be empty
    *	Email must be a valid email address.
    * If all validation succeeds, a confirmation page should be displayed which tells the user the data was received by the system.
3.	All data submitted in this way must be saved, but only for the duration of the application’s run. It does not need to survive a restart of the application. However, in your design consider that this application will ultimately have to save this data to a persistent datastore.
4.	A REST endpoint must be provided to retrieve all mailing list entries. This endpoint should take 2 optional parameters:
5.	Last name- if specified, only records with this last name are returned
6.	Ascending/Descending flag which indicates how to sort records. If not specified, default behavior is to sort ascending. Records should be sorted by last name. Where last names are equal, records should be sorted by first name.
7.	At least one automated test must be provided which tests one of your .net components.
8.	Security is not required for this exercise.

Optional:

1.	Add additional tests
2.	Implement appropriate design patterns or principles such as dependency injection

