![alt text](https://github.com/varolomer/RevitModelessForms/blob/master/ExternalEventsWinForm/Assets/Github/Banner.png)

# Revit Modeless Forms
This is a tutorial repository based on RevitSDK's modeless form example with interlocking mechanism to handle the commands in a single Event Handler instance. The Event Handler object has another object called RevitRequests where it determines which command will be run when the Event Handler is called from Revit External Event.

### Creating a Wall
![alt text](https://github.com/varolomer/RevitModelessForms/blob/master/ExternalEventsWinForm/Assets/Github/CreateRandomWall.gif)

### Creating Random Walls
![alt text](https://github.com/varolomer/RevitModelessForms/blob/master/ExternalEventsWinForm/Assets/Github/BatchWalls.gif)

## Why External Events?
Revit external events gives us the the chance to drive revit from an external process and the chance to have Modeless Forms. Normally, when we use the commands that implement IExternalCommand, the command has a procedural flow and then returns Result object immediately after its job is done. However, with raising and handling external events we have much more flexibility on how our program and UI works.

## Limitations
Due to the reason that the library is writtten for beginners and in a very basic scenario, this way of dealing with External Events have some limitations:

- Arguments cannot be passed from UI to event handler and vice versa
- When the command has a functionality where it will keep Revit busy for a while, the UI gets unresponsive
- It is not suitable for Asyncronous Pattern. No Task-Based approach
- Since there is no chance to update UI, progress bar information cannot be passed.

As an important addition, it is extremely tedious to pass event handlers and events to UI instance especially when there will be many External Events. To take care of this issue, there are much better approaches to deal with events like abstract classes which wrap the events properly. To keep this library simple for beginners, this kind of approaches are ignored. There will be another repository for these more advanced approaches.


## Notes
This library is written for beginners. The variable names are long-written, the code-flow is simplified.
