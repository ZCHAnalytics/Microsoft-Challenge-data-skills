![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/c8262937-518a-4eec-a1f8-78da7235bb6c)

## Insert and delete documents

Create an Azure Cosmos DB for NoSQL account
Import the Microsoft.Azure.Cosmos library into a .NET script
Run a script to create menu-driven options to insert and delete documents.
dotnet run

This is a very simple program. It will display a menu with five options as show below. Two options to insert a predefined document, two to delete a predefined document, and an option to exit the program.

1) Add Document 1 with id = '0C297972-BE1B-4A34-8AE1-F39E6AA3D828'
2) Add Document 2 with id = 'AAFF2225-A5DD-4318-A6EC-B056F96B94B7'
3) Delete Document 1 with id = '0C297972-BE1B-4A34-8AE1-F39E6AA3D828'
4) Delete Document 2 with id = 'AAFF2225-A5DD-4318-A6EC-B056F96B94B7'
5) Exit


1) Add document 1
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/9f18bf33-d2e2-4d69-9bea-65b48865728e)

If I try to add the same document again, I get error code 409 (Conflict) as the document with this ID already exists.
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/f944e9e9-fce5-44a0-8a21-ed652f4724c6)

CreateDocument - line 64 of Program.cs file `CreateDocument(container)`
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/71c815e5-a680-45ec-8d7f-ba50184e382f)

## Add Error handling 
Add code for error handling for 403 and 409 exceptions and rerun the project build and creating the same document twice:
We get 409 error as expected
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/1d4a9cbd-daa3-4ac1-b2b0-eb2a5e0510af)


## Add Error handling for common communication types of exceptions
There are three common communication type of exceptions: 429, 503, and 408 or too many request, service unavailable, and request time out respectively. 


