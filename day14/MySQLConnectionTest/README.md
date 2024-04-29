## Setup mysql
```
docker pull mysql
docker run --name container_name -e MYSQL_ROOT_PASSWORD=db_pass -e MYSQL_DATABASE=db_name -p 3306:3306 -d mysql
```

## Test the connection
```
dotnet add package MySql.Data
dotnet run --connection-string "server=your_server_ip;user=your_user;password=your_password;database=your_database"
```