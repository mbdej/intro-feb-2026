# Api Design for the MM Api

## Students / Student

### Adding MM
- Add 1 - 3 MMs to be explored the next day.

- Title (Developer Testing)
- Description (optional, more context for what your looking for)


// my go to fake variable names are "tacos" or other foods. Because I love those things and I'm chubby.
// my go to for dates and numbers is 42069 - because THAT IS MY BIRTHDAY, THE COOLEST THING ABOUT ME.
```http
POST https://localhost:7059/students/a42069/moments
Content-Type: application/json
Authorization: """"""

{
    "title": "HTTP",
    "description": "Jeff is a poopy head"
}

```

### Get a list of MM

A student needs a way to see the list of all their submitted MMs

### Remove an MM


### Edit an MM


## Instructor


### Get A List
Can get a list of all the students aggregated moments in a summary form so they can be addressed.


### Punt
Say "I don't want to lose this, but I promise I'll talk about it later"


## In HTTP - we have three things we can "design", and we have to figure out how to map a business process to these threee things.

- Resources - An importantant thingy we want to expose to the consumer of this service. They have names. At least one. And those are URIs.
    - https://mm.hypertheory-labs.dev/api/students/moments
        - the scheme - http | https
        - "mm.hypertheory-labs.dev" - known as the "origin" or sometimes the "authority".
        - /api/students/moments - "the path" (to the thing we want, the resource)



- Representations
    - what are you going to get from a resource, or send to a resource?
        - the web doesn't specify. Can be ANYTHING the client and the server agree on.
        - we are going to do our representations in JSON (a serialization format) 
- Methods 
    - GET, POST, PUT, DELETE

    - GET means "get" - I wanna see it. No "side effects"
    - POST means different things depending on the kind of resource - but on a "collection" resource it means something like:
        "Excuse me ma'am, I'd like you to consider taking this representation I am sending you and making part of your family"

    

