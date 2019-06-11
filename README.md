# welcome_reality_fashion_MXR

Experimental AR-Kinect body tracking thing from 3rd Mixed Reality Fashion workshop in Prague 2019.

The aim of this project is to further investigate possible ways for users to "Wear Pixels". This is done by superimposing digital garments onto a user in an Augmented Reality or Mixed Reality setting, in realtime. 

Is it possible, practical or even desirable to wear digital garments? Can the experience ever be high quality given limitations of realtime body tracking and cloth physics with currently available technology?

# Consists of two separate Unity projects:

HowToWearItClient - (aka Client) Make a build of the project for Android and install it on a mobile device. Optionally place the mobile in an AR or VR headset. When the app starts, login to the photon name server but do not host a game. Instead wait until the HowToWearItKinect (aka server) has logged in and created a room/game. Once this is done, join the room/game.

HowToWearItKinect - (aka Server). Connect a Kinect v2 device to your Windows 10 laptop, making sure to install all the necessary drivers. Open HowToWearItKinect project in Unity and open the DemoAsteroids-LobbyScene. Play in the editor, and once playing, log into the Photon server. Host a game or join a random room. Then wait for the client to connect to the same room. This is so the server is always player 1, as it needs to be in order to send the Kinect data correctly. Finally, set both client and server to ready and start the game.

The server will then send the Kinect data to the client, using Photon's Observable Object class to move the position of the joins as the Kinect sees them. Point the Kinect device at the user who has the client on their mobile device. The user will then see an avatar of their self moving on the client corresponding to their own movements.

# Roadmap

- VR tracking so avatar of user stays in place (in the real world) when user turns head.
- Rig 3D model avatar to kinect bones etc
- Preview on server screen, so people watching can actually see what the user sees on the client / in the AR headset
- Custom network solution (c# sockets?) to avoid need for Photon. Sshould reduce latency when both client & server on same LAN?
- Multiplayer / supports multiple users.
- Clothes & avatar at user's position, so users are able to see themselves when they look down, as well as see their virtual avatar
- Nail down pipeline for getting clothes from Clo3D (or similar) into Unity, with cloth physics.
- Possible Hololens or other AR headset integration
- Realtime pose estimation using phone camera on client. I.e. no need to have Kinect to track body movement.





