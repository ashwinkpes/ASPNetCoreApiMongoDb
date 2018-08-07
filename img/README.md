# Endpoints actions

> These endpoints and responses are just for demonstration purposes.

Some basic endpoints with GET/POST/DELETE requests

## Signup new user

```plaintext
POST | http://localhost:5000/api/users/signup
```

![Signup](https://raw.githubusercontent.com/Flysenberg/ASPNetCoreApiMongoDb/master/img/signup.PNG)

## Signin existing user

```plaintext
POST | http://localhost:5000/api/users/signin
```

![Signin](https://raw.githubusercontent.com/Flysenberg/ASPNetCoreApiMongoDb/master/img/signin.PNG)

## Get user info

```plaintext
GET | http://localhost:5000/api/users/{id}
```

![GetUserById](https://raw.githubusercontent.com/Flysenberg/ASPNetCoreApiMongoDb/master/img/getUser.PNG)

## Get user posts

```plaintext
GET | http://localhost:5000/api/users/{id}/posts
```

![GetUserPostsByUserId](https://raw.githubusercontent.com/Flysenberg/ASPNetCoreApiMongoDb/master/img/getUserPosts.PNG)

## Add new post

```plaintext
POST | http://localhost:5000/api/users/{id}/posts
```

![AddNewPost](https://raw.githubusercontent.com/Flysenberg/ASPNetCoreApiMongoDb/master/img/postPost.PNG)

## Delete user

```plaintext
DELETE | http://localhost:5000/api/users/{id}
```

![DeleteUserAccount](https://raw.githubusercontent.com/Flysenberg/ASPNetCoreApiMongoDb/master/img/deleteUser.PNG)
