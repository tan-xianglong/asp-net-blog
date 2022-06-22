# Blog
## Overview
This is a portfolio project showcasing a blog that is built on both MVC and REST API designs. The whole application is built using ASP.NET Core 5.0 with MS SQL as the persistant database. It also has Create, Read, Update and Delete features.

To demonstrate the working knowledge of MVC and API designs, the front end and back end of the blog are split into 2 projects. The front end is design with ASP.NET Core MVC Web App. The MVC Web App then comsume data from ASP.NET Core 5 REST API. The designs follow the onion architecture with separation of concerns and inversion of control principles in mind.

Unit testing is implemented on both MVC and API. The comment feature of the blog were added using Test Driven Development (TDD) approach.

## Languages
- C#
- HTML
- CSS
- JavaScript

## Frameworks
- ASP.NET 5.0 Core
- JQuery
- Bootstrap
- Xunit
- NSubstitute

## Tools
- Visual Studio 2022
- MS SQL Server 2019 (LocalDB)
- Thunder Client

## First Look
### Homepage & Navbar
- The homepage shows a list of blog posts that are organised into pages (pagination).
- The navbar allows users to navigate to various parts of the blog (Posts and Contacts).

![Home page](https://user-images.githubusercontent.com/41245694/175060063-2cf4cbdd-574b-467a-8a4f-61b3b4cfee02.png)

### Blog post index and post details
- The index page allows user to search the blog post titles and posts are organised into pages. User can also create blog posts.
- The post details page allows user to read, edit and delete the post.
- User can also post comments and delete it

![Blog index page](https://user-images.githubusercontent.com/41245694/175062991-ece9e163-87aa-4eb3-aef8-4310c1288c5c.png)
![Blog post detail page](https://user-images.githubusercontent.com/41245694/175063297-48d352da-20df-42e6-85e2-47be95e1c5b6.png)

### Contact Me & Contact List
- The Contact Me page allows user to leave the contact details in a form
- The Contact List page allows user to retrieve all contact details in a table and delete them if needed.

![Contact Me page](https://user-images.githubusercontent.com/41245694/175064089-81787386-e7f5-40fd-b836-31144a13c354.png)
![Contact list page](https://user-images.githubusercontent.com/41245694/175064263-e479c67a-a070-469b-8711-5679ed6c9558.png)

## Files structure
The solution is organised into 5 different projects and library classes
1. Blog (MVC Web App)
2. WebAPI (REST API)
3. Data (Data related assets - Entities model, Migrations, DbContext, Repositories)
4. Domain (Utilities and business logic classes)
5. BlogTest (Unit Testing)

Please note that Data and Domain library classes are separated from the projects so that the assets can be shared between the projects without affecting each other if one project is being retired.
