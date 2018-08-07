# Endpoints actions

> These endpoints and responses are just for demontration purposes.

Some basic endpoints with GET/POST actions

## Signup with a new account

```plaintext
POST | http://localhost:5000/api/users/signup
```

![Signup](signup.png)

## Signin with existing account

```plaintext
POST | http://localhost:5000/api/users/signin
```

![Signin](signin.png)

## Get user's info

```plaintext
GET | http://localhost:5000/api/users/{id}
```

![GetUserById](getUser.png)

## Get user's posts

```plaintext
GET | http://localhost:5000/api/users/{id}/posts
```

![GetUserPostsByUserId](getUserPosts.png)

## Add new post

```plaintext
POST | http://localhost:5000/api/users/{id}/posts
```

![AddNewPost](postPost.png)
