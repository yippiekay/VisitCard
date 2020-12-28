FOR CORRECT START !!! 

1) For connect no database need to run docker container by next command:

For Linux: sudo docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=YourSTRONG!Passw0rd' -p 1401:1433 --name db -d microsoft/mssql-server-linux:2017-latest

For Windows: docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=YourSTRONG!Passw0rd' -p 1401:1433 --name db -d mcr.microsoft.com/mssql/server

2) Run Angular by next command:

ng serve --host 127.0.0.1
