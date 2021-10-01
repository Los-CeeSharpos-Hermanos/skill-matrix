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
  
Now, you can modify and customize your APIs contracts using the Swagger Editor on the left. This will result in changes to the swagger page on the right.

You can also Save, import and export swagger files using the File menu, located in the header of the page. You can convert this code to other standards in the Edit menu.

By clicking on the Generate Server tab, it is possible to generate sample backend applications based on the code on the editor. This is a very useful tool, there are many technologies available and the generated code will reflect the specifications of your swagger.yml code. Like the Generate Server tab, it is possible to auto generate code through the Generate Client tab, the difference is that here, the focus is frontend technologies.
 
 


