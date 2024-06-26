﻿# ApplicationFormTask

# Application Usage and Integration Guide

This guide provides detailed instructions on how to run the application, get responses from the API, and integrate the API endpoints with the frontend UI.

## Running the Application

### Prerequisites

1. **Azure Cosmos DB Account**: Ensure you have an active Azure Cosmos DB account.
2. **Connection String**: Obtain the connection string from your Azure Cosmos DB account.
3. **Database and Container**: Ensure the database (`ApplicationFormDB`) and container (`Categories`) are set up in your Azure Cosmos DB account.

### Setup

1. **Clone the Repository**:
    ```sh
    git clone https://github.com/your-repo/application.git
    cd application
    ```

2. **Install Dependencies**:
    Ensure you have [.NET SDK](https://dotnet.microsoft.com/download) installed. Then, install the necessary dependencies:
    ```sh
    dotnet restore
    ```

3. **Configuration**:
    Update the `appsettings.json` file with your Cosmos DB connection string:
    ```json
    {
      "CosmosDb": {
        "Account": "https://<your-account>.documents.azure.com:443/",
        "Key": "<your-account-key>",
        "DatabaseName": "ApplicationFormDB",
        "ContainerName": "Categories"
      }
    }
    ```

### Build and Run the Application

1. **Build the Application**:
    ```sh
    dotnet build
    ```

2. **Run the Application**:
    ```sh
    dotnet run
    ```

3. **Access the Application**:
    Open your web browser and navigate to `http://localhost:5000`.

## Using the API

### API Endpoints

The application exposes several API endpoints. Here are the key endpoints and how to use them:

1. **Get All Categories**:
    - **Endpoint**: `GET /api/categories`
    - **Description**: Fetches all categories from the database.
    - **Response**: A JSON array of category objects.

2. **Get Category by ID**:
    - **Endpoint**: `GET /api/categories/{id}`
    - **Description**: Fetches a category by its ID.
    - **Response**: A JSON object of the category.

3. **Create a New Category**:
    - **Endpoint**: `POST /api/categories`
    - **Description**: Creates a new category.
    - **Request Body**: A JSON object with category details.
    - **Response**: The created category object.

4. **Update a Category**:
    - **Endpoint**: `PUT /api/categories/{id}`
    - **Description**: Updates an existing category by its ID.
    - **Request Body**: A JSON object with updated category details.
    - **Response**: The updated category object.

5. **Delete a Category**:
    - **Endpoint**: `DELETE /api/categories/{id}`
    - **Description**: Deletes a category by its ID.
    - **Response**: A success message or status code.

### Example Requests

#### Fetch All Categories
```sh
curl -X GET http://localhost:5000/api/categories
```

#### Fetch Category by ID
```sh
curl -X GET http://localhost:5000/api/categories/{id}
```

#### Create a New Category
```sh
curl -X POST http://localhost:5000/api/categories -H "Content-Type: application/json" -d '{"name": "New Category"}'
```

#### Update a Category
```sh
curl -X PUT http://localhost:5000/api/categories/{id} -H "Content-Type: application/json" -d '{"name": "Updated Category"}'
```

#### Delete a Category
```sh
curl -X DELETE http://localhost:5000/api/categories/{id}
```

## Integrating API Endpoints with Frontend UI

To integrate the API endpoints with your frontend UI, follow these steps:

### Fetching Data

1. **Fetch All Categories**:
    ```javascript
    fetch('http://localhost:5000/api/categories')
        .then(response => response.json())
        .then(data => {
            // Use the data to update your UI
            console.log(data);
        });
    ```

2. **Fetch Category by ID**:
    ```javascript
    const categoryId = 'your-category-id';
    fetch(`http://localhost:5000/api/categories/${categoryId}`)
        .then(response => response.json())
        .then(data => {
            // Use the data to update your UI
            console.log(data);
        });
    ```

### Creating Data

1. **Create a New Category**:
    ```javascript
    const newCategory = { name: 'New Category' };
    fetch('http://localhost:5000/api/categories', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newCategory)
    })
    .then(response => response.json())
    .then(data => {
        // Use the data to update your UI
        console.log(data);
    });
    ```

### Updating Data

1. **Update a Category**:
    ```javascript
    const updatedCategory = { name: 'Updated Category' };
    const categoryId = 'your-category-id';
    fetch(`http://localhost:5000/api/categories/${categoryId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(updatedCategory)
    })
    .then(response => response.json())
    .then(data => {
        // Use the data to update your UI
        console.log(data);
    });
    ```

### Deleting Data

1. **Delete a Category**:
    ```javascript
    const categoryId = 'your-category-id';
    fetch(`http://localhost:5000/api/categories/${categoryId}`, {
        method: 'DELETE'
    })
    .then(response => {
        if (response.ok) {
            // Update your UI to reflect the deletion
            console.log('Category deleted');
        }
    });
    ```

By following these instructions, you can successfully run the application, interact with the API, and integrate the API endpoints with your frontend UI to create a seamless user experience.
