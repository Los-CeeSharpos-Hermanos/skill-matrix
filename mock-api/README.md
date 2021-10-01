# Skill Matrix Swagger Editor and Mock Api

The Swagger editor can be used to help the creation of _contracts_ (our JSON responses from the backend). 

The Mock API can be used to help with Contract First approach during development. It is able to host a fake server, so the frontend can use it as a base to build its features

## Usage

### Pre-requisite

- #### Docker and Docker Compose
  
  > Docker is an open platform for developing, shipping, and running applications. Docker enables you to separate your applications from your infrastructure so you can deliver software quickly. With Docker, you can manage your infrastructure in the same ways you manage your applications. By taking advantage of Docker’s methodologies for shipping, testing, and deploying code quickly, you can significantly reduce the delay between writing code and running it in production.
  
  > Compose is a tool for defining and running multi-container Docker applications. With Compose, you use a YAML file to configure your application’s services. Then, with a single command, you create and start all the services from your configuration.

##### Setting up Docker and Docker Compose 

It is advised to follow the Docker documentation to install it: 
- [Windows](https://docs.docker.com/desktop/windows/install/)
- [Ubuntu](https://docs.docker.com/engine/install/ubuntu/) 
- [Mac](https://docs.docker.com/desktop/mac/install/)

### Swagger Editor

Navigate to mock-api/swagger-editor folder and run the following commands from a terminal:

- 1: `docker compose build` (this command just need to be used in your first run)

- 2: `docker compose up`

- 3: Access `http://localhost:8080/` and you will be able to see the editor and the resulting Swagger page:

  ![image](https://user-images.githubusercontent.com/53683786/135634979-38a09b30-3c7c-483c-bddd-658e5788d64e.png)
  
  **Obs.:** The default port is **8080**, it can be changed in the docker-compose.yml file, located in the swagger-editor folder.
  
Now, you can modify and customize your APIs contracts using the Swagger Editor on the left. This will result in changes to the swagger page on the right.

You can also Save, import and export swagger files using the File menu, located in the header of the page. You can convert this code to other standards in the Edit menu.

By clicking on the Generate Server tab, it is possible to generate sample backend applications based on the code on the editor. This is a very useful tool, there are many technologies available and the generated code will reflect the specifications of your swagger.yml code. Like the Generate Server tab, it is possible to auto generate code through the Generate Client tab, the difference is that here, the focus is frontend technologies.

More about Swagger Editor: https://hub.docker.com/r/swaggerapi/swagger-editor/
 
 ### Swagger Mock Api
 
 Navigate to mock-api/swagger-mock-api folder and run the following commands from a terminal:

- 1: `docker compose build` (this command just need to be used in your first run)

- 2: `docker compose up`

- 3: Your mock sever is running. Its routes are the ones described in the swagger.yml file located inside this folder. Using your brownser or an API testing tool like [Postman](https://www.postman.com/), it is possible to make requests to this server. It will always generate responses describided in the swagger.yml file with random values. Perfect for testing!
  ![image](https://user-images.githubusercontent.com/53683786/135637802-3178df0b-d5d6-44c7-b01e-22cfdb41e921.png)
  
   **Obs.:** The default port is **8001**, it can be changed in the docker-compose.yml file, located in the swagger-mock-api folder.
   
   More about Swagger Mock API: https://hub.docker.com/r/palo/swagger-api-mock/
   
   ##### IMPORTANT: Enabling docker resources file sharing

To properly use the Swagger Mock API, you should enable Resources File Sharing on Docker. The following guide will show how to do it this:

- 1: On Docker Desktop click on the Cog icon to go to settings

    ![image](https://user-images.githubusercontent.com/53683786/135643959-82069d46-7c8d-4d9b-a710-72981e2c2701.png)
    
- 2: On the side menu, click on resources:

    ![image](https://user-images.githubusercontent.com/53683786/135644104-54b63bb5-dec6-49d2-afdc-45a05f805f83.png)

- 3: On Resources sub menu, click on File Sharing:
    
    ![image](https://user-images.githubusercontent.com/53683786/135644437-bd710231-18fc-4d47-8d1d-e6d753ad9837.png)

- 4: ### **Click on the plus blue icon and add the folder with the swagger.yml file (typically on mock-api\swagger-mock-api). If you preffer, you can select a parent folder, that way docker can access any file in this folder and its children.**
   
### Tip

If you are usind **Docker Desktop**, after you have run the container for the first time (`docker compose up`), by using the start command, it is possible to start it directly in this application. If a container is running it will appears in green, stopped containers icons are grey. You can also stop and delete containers here.

![image](https://user-images.githubusercontent.com/53683786/135640533-e0eb8cda-ee35-4890-959b-37615209322f.png)


