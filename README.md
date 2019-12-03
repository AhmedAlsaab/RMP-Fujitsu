# RunMyProcess AR Project

RunMyProcess aims to provide service to organisations so that they can monitor what is going on in their departments.
Run my process has organisations registered to them and those organisations can create their project.
When an organisation creates a project it has processes that needs to be completed in order to be done and
each process has steps that has to be done. This application enables organisation manager to see what a department
is having failing processes. Application displays information on failing steps when a specific process is selected.
Manager than can contact with the person that is responsible for the failure to keep the project going.


## Getting Started

You can fork the project and start working on it or you can create a branch and follow working guidelines to contribute to the project.

## Prerequisites

* Unity

* Vuforia

* Visual Studio (Extra but useful.)

* Internet connection is required to request API data. (Run the Application.)

## Loading the project into Unity

1. Find the FujitsuScene file. This is normally located in team-3-ar-project-fujitsu\Unity\Fujitsu AR Project\Fujitsu Unity Project\Assets after cloning the project

2. Double click the FujitsuScene file to boot up Unity and load the project in

3. When loading in, project may indicate compatability issues, this is related to the Unity version you may be running at the time, this is normal and proceeding should be fine

## File Information

1. **Scripts are found under Unity/Fujitsu AR Project/Assets/Scripts Folder.**

2. Processdetailinserter.cs is assigned to define how processes and steps are created for Marketing Campaign.

3. MarketingFair.cs is assigned to define how processes and steps are created for Marketing Fair.

4. API given in APIFlow is used to define projects.

5. ProcessPages.cs is used to count number of processes for next and previous list button in Processdetailinserter.cs

6. ProcessPagesFair.cs is used to count number of processes for next and previous list button in MarketingFair.cs

7. ScreenShotUtility.cs and Snapshot.cs is used for taking snapshots and generation of gallery.

8. ProjectHealth.cs and ProjectScreen.cs is used to generate initial page that displays project health and selection of project.

9. **Test folder** in Scripts folder contains all the Tests available.

10. **./Assets/Resources/Prefabs folder contains all the prefabs used to generate display runtime.**

11.  Step.prefab is used for generation of step buttons and pop up.

12. Process Item.prefab is used to generate process button and container.

13.  Process Details General.prefab is generated runtime in Process item to and is where steps are generated.

14. Item image.prefab is used to generate gallery items (Saved snapshots)

15. Help Screen.prefab is used in scene to display help screen.

16. GalleryScreen.prefab is used in scene and is where Item image.prefab are generated when snapshots are taken.

17. **Prefabs folder within the Assets folder contains prefabs for project selection screen generation.**

18. ProjectButton.prefab is used in initial project selection screen to generate project selection buttons.

19. StatusCode.prefab is used in initial project selection screen to display status code.

20. StatusCodeButton.prefab is used in initial project selection screen to display status code.

21. StatusDataContainer.prefab is used in initial project selection screen to is where project buttons are generated in.



## Files related to Interaface 2.0

* APIfilter.cs implements functionality to store data from each API link given as an Array, allowing the developer to access data from any link through array indexes.

* ProjectHealth.cs fetches data from the API and performs calculations to produce a Radial Bar that shows the failure rate for each respective project within the targetted department.

* ProgressBar.cs populates a bar chart on the main menu screen that shows the cumulative state of the whole department.

* UIManager.cs adapts the DoTween library to transition selected items out and in of the main-veiw.

* ProcessDetailInserter.cs contains modified changes that relate to the realignment of certain prefabs along with detailed code segments that introduce open and close features for the processes that are created.

* ProjectScreen.cs contains modified changes that ultimately allow for the production of a bar chart to represent a department's overall state.


## Deployment
Project needs to be loaded into Unity in order to launch. 
When project is loaded guidelines attached can be followed to deploy on any device.

* *Computer:*

Press play button in order to see the application working.


* *Android:*

> https://unity3d.com/learn/tutorials/topics/mobile-touch/building-your-unity-game-android-device-testing


* *iOS: (Requires Mac and Xcode)*

> https://unity3d.com/learn/tutorials/topics/mobile-touch/building-your-unity-game-ios-device-testing


## Testing

In Unity go to Scripts folder and then Tests to see the test scripts available.
To run tests use Unity test runner. First go to Window > General > Test Runner and then to Play Mode testing
Clicking run all should run all the tests and clicking the messages should display information on the tests run.

Source: 

> https://docs.unity3d.com/Manual/testing-editortestsrunner.html



## Contributing

Please see contributions.md file for more information on team agreement.


## Authors

Ahmed Alsaab

Arda Karaderi

Joshua Teague

Daniel Jones


    

