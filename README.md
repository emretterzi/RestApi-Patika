## RESTful API for Products

This simple RESTful API provides basic CRUD operations for managing products. It includes endpoints for listing, retrieving by ID, creating, updating, and deleting products. Additionally, a specific endpoint for listing products based on a name query parameter is provided.

### Endpoints

- **List Products**
  - **Endpoint:** `GET /api/products`
  - **Description:** Retrieve the list of all products.
  - **Example Response:**
    ```json
    [
        {
            "id": 1,
            "name": "Product 1",
            "description": "Description 1",
            "price": 19.99
        },
        {
            "id": 2,
            "name": "Product 2",
            "description": "Description 2",
            "price": 29.99
        },
        {
            "id": 3,
            "name": "Product 3",
            "description": "Description 3",
            "price": 39.99
        },
        {
            "id": 4,
            "name": "Product 4",
            "description": "Description 4",
            "price": 49.99
        }
    ]
    ```

- **Get Product by ID**
  - **Endpoint:** `GET /api/products/{id}`
  - **Description:** Retrieve a specific product by its ID.
  - **Example Response:**
    ```json
    {
        "id": 1,
        "name": "Product 1",
        "description": "Description 1",
        "price": 19.99
    }
    ```

- **Create Product**
  - **Endpoint:** `POST /api/products`
  - **Description:** Create a new product.
  - **Example Request Body:**
    ```json
    {
        "name": "New Product",
        "description": "Description for the new product",
        "price": 59.99
    }
    ```
  - **Example Response:**
    ```json
    {
        "id": 5,
        "name": "New Product",
        "description": "Description for the new product",
        "price": 59.99
    }
    ```

- **Update Product**
  - **Endpoint:** `PUT /api/products/{id}`
  - **Description:** Update an existing product.
  - **Example Request Body:**
    ```json
    {
        "name": "Updated Product",
        "description": "Updated description",
        "price": 39.99
    }
    ```
  - **Example Response:**
    ```json
    {
        "id": 3,
        "name": "Updated Product",
        "description": "Updated description",
        "price": 39.99
    }
    ```

- **Delete Product**
  - **Endpoint:** `DELETE /api/products/{id}`
  - **Description:** Delete a product by its ID.
  - **Example Response:** No content (204 No Content).

- **List Products by Name**
  - **Endpoint:** `GET /api/products/list?name={name}`
  - **Description:** List products filtered by a partial or complete product name.
  - **Example Response:**
    ```json
    [
        {
            "id": 1,
            "name": "Product 1",
            "description": "Description 1",
            "price": 19.99
        },
        {
            "id": 2,
            "name": "Product 2",
            "description": "Description 2",
            "price": 29.99
        }
    ]
    ```

- **Patch Product**
  - **Endpoint:** `PATCH /api/products/{id}`
  - **Description:** Update specific properties of an existing product.
  - **Example Request Body:**
    ```json
    {
        "name": "Updated Product Name",
        "price": 45.99
    }
    ```
  - **Example Response:** No content (204 No Content).

### Example Usage

#### Create Product (POST)

```http
POST /api/products
Content-Type: application/json

{
    "name": "New Product",
    "description": "Description for the new product",
    "price": 59.99
}
```

#### Update Product (PUT)

```http
PUT /api/products/5
Content-Type: application/json

{
    "name": "Updated Product",
    "description": "Updated description",
    "price": 39.99
}
```

#### Patch Product (PATCH)

```http
PATCH /api/products/5
Content-Type: application/json

{
    "name": "Updated Product Name"
}
```

Feel free to adjust the examples to match your specific use case.
