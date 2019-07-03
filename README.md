# Twitch_Halo5_Stats
Twitch Extension that will show Halo 5 stats for a broadcaster/player. 

## What's in this sample
This video-overlay Extension allows Broadcasters to enter their Xbox Gamertag in the configuration page, and have their Halo 5 statistics shown to viewers on the overlay. 
It utilizes the [Configuration Service](https://dev.twitch.tv/docs/extensions/building/#configuration-service) to store and retrieve the Broadcaster's Xbox Gamertag. 
It communicates with the [Public Halo 5 API](https://developer.haloapi.com/) to get stats for the entered gamertag. 
It verifies the Twitch JWT to verify the request is coming from the Extension.
The backend is written in C# as a Web API project. 
The frontend is written in Javascript. 

## Focal Points
- Using C# to build your EBS
- How useful game APIs can be to the community, and how simple it is to enhance the game experience by utilizing these APIs.

## Recreating this on your own
There are many tutorials for setting up your own API via C# and Visual Studio. Below are the high level steps on setting up a similar project.
1. Register a [Halo 5 developer application](https://developer.haloapi.com/products)
2. Open up Visual Studio, and create a new "ASP.NET Web Application (.NET Framework)". Selecting "Web API" from the Template options, and selecting the "MVC" and "Web API" checkboxes. 
3. Create the data models needed by adding new C# Classes to the "Models" folder. These classes will define the structure of the data you'll be sending and receiving. See the "Models" folder of this project for reference. 
4. Create a new Web Controller by adding a new Controller under the Controllers folder. This new Controller will define your API endpoint and what it should do when contacted. See the "Controllers" folder of this project for reference. 
5. Add logic in Web Controller for getting data from the Halo 5 API. See the file "Halo5Controller.cs" in this project for reference. 
6. Press the Play button in Visual Studio to spin up your local API server . For the sake of the first test, recommend selecting Microsoft Edge as the browser to open. 
7. Build your frontend :) See the files under the "Client" folder for reference. 
8. Register a new Extension on the [Twitch dev site](https://dev.twitch.tv/console/extensions/create). Fill out the Asset Hosting fields specific to your setup. 
9. Install and Activate the Extension on your channel. 
10. Spin up your server form Visual Studio again by clicking the Play button.
11. You should now be able to navigate to the Configuration page for the Extension, and to your Channel (while streaming and after entering your gamertag in the configuration page...) and see the Extension in action. 

## Praise for public Game APIs
Games that offer public APIs open up opportunities for the community to create awesome applications in relation to their game. Kudos to Halo 5 for offering a holistic API that's easy to work with. 

## Notes
- Some basic setup pieces are not included in the guide above. For example, setting up SSL Certs, accounting for CORS, etc. 
- This sample serves as a starting point, but please take proper considerations to ensure your EBS will scale and provide the best experience to users.
