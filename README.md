# AlbumViewer using ASP.NET Core and Angular

This is a sample ASP.NET core application which uses Angular as Frontend. This consists of
1. List of Albums(**_Creator, Url of Amazon and Spotify, Album Descrption , Release Date_**)
2. List of Songs in Albums (**_SongName,Length_**). _You can add more songs in the list_
3. Artist -----Not Implemented__

# Core Features
1. Swagger Implementation view all API's
2. CORS Support
3. Global Exception Filter
4. Using Repository Pattern
5. AutoMapper for converting objects
6. Sqlite for data persistence

# Sample Screen

![image](https://user-images.githubusercontent.com/12517925/152788137-da293ca3-aa6f-4787-897c-e89221423387.png)

![image](https://user-images.githubusercontent.com/12517925/152788390-c1b10e09-772b-4949-a71a-5129dad82427.png)

# How to Install and Run Locally
1. Clone the repo or download the repo

2. In the Base Solution folder just forst run following command
   ```
   cd <Base Solution Folder>
   dotnet restore
   ```
![image](https://user-images.githubusercontent.com/12517925/152789322-278f68c2-8c29-4bb6-b3cd-82163a78c59a.png)

3. Then change the directory to AlbumViewer and run below command
    ```
   cd AlbumViewer
   dotnet run
   ```
![image](https://user-images.githubusercontent.com/12517925/152789529-f95b41ce-3e05-4b3e-99da-a244e47c78d2.png)

4. Open the https://localhost:5001/ for viewing angular application

5. Open the https://localhost:5001/swagger/index.html for viewing all the independent API's




**Please note while running the code, it will automatically seed some of the data in Sqlite.**
