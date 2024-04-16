![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/b90ef4c2-c04d-4369-bb5d-bf2a4ae61d0e)


## Author a stored procedure
In Azure Data Explorer, add and then execute a new stored procedure 'createDoc': 

```js
function createDoc() {
  var context = getContext();
  var container = context.getCollection();
  var doc = {
    name: 'first document',
    categoryId: 'demo'
  };
  container.createDocument(
    container.getSelfLink(),
    doc
  );
}
```

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/bca24e7a-ec92-437c-ac4e-351a32080014)

## Implement best practices for a stored procedure

First, the stored procedure assumes that it will always have time to complete the operation and doesn't check the return value of the createDocument method to ensure it has enough time. 
Second, the stored procedure assumes that all documents are successfully inserted without checking or throwing any potential error messages. 
Finally, the stored procedure doesn't return the newly created document as the HTTP response for the request that originally invoked the stored procedure. 
You will make these three changes to the stored procedure to implement common best practices.

Edit the stored procedure file to add error-handling: 

```js
function createDoc(title) { // Define a function called `createDoc` that takes a parameter `title`
  var context = getContext(); 
  var container = context.getCollection();
  var doc = { // Create a new document `doc` with properties `name` (set to the value of title parameter) and `categoryId` (set to 'demo')
    name: title, 
    categoryId: 'demo'
  }
  var accepted = container.createDocument( // Store the result of the method invocation in a variable named `accepted`
    container.getSelfLink(), // Method returns the self-link URI of the current resource within the Cosmos DB container
    doc, // The document object to be created in the container
    // Add a third parameter that is a function that takes in error and newDoc parameters, checks if the error is null, and sets the newDoc to the response body of the stored procedure
    (error, newDoc) => {
      if (error) {
        throw new Error(error.message);
      } else {
        context.getResponse().setBody(newDoc);
        }
    }
  );
  if (!accepted) return // Check the value of the accepted variable and return the method if it is not true
}
```
After the stored procedure executed successfully, the newly created document was returned as a response for the original HTTP request:

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/ef28fa09-ed31-4969-a85e-18ec79bbb72f)

## Query documents

A simple SQL query that returns all items where `categoryId is equivalent to `demo`:

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/eee5a43d-ce53-4d19-a651-83c9ec337673)
