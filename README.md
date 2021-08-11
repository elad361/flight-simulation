# flight-simulation
**read me**
i'v implement the simulator by using MVVM Architectural pattern.
my classes:
#view
* **MainWindow** nevigation window to the HomePage
* **HomePage** here you can feed path to the csv which include the flight data and port to the FG
* **SimulationWindow** contain appearance of the plane controllers and a few more data. It also contain control bar of the simulation itself.
* **ReadingFail** basicly this window will be shown whenever an error occurs
* **AnomallyWindow* * was suposed to be the window to show the anommalies.

#model
* **MyClient** inhert "Client" interface and used as server to the FG.
* **ControllsStatus** incharge of making sure the controlers shows the current situation
* **FlightData** mostley incharge of reading the files and saving them as we want
* **GraphModel** incharge of setting the graph

in order to compile and run the app:
* firstly we should put all the given codeFiles in the same folder
* I used poxy files so we should download the following libraries and save them in folder called "bin" with all the other files: "OxyPlot.Wpf", "OxyPlot.Core" (already included in the given code, no need to download)
* download .net framework its free ( .NET Framework Version 4.5.2 ) or try other sites also
Install .net framework
* Open cmd
* set path of cmd by using (set path="") command.
* generally: C:\Windows\Microsoft.NET\Framework\v4.0.30319
* now go to the folder (by using cmd) in which you save the c# file.
* now enter csc *.cs in cmd.
* now if you set correct path and your coding is correct then a .exe file is created run that file on cmd.

[link for UML](https://raw.githubusercontent.com/elad361/flight-simulation/main/UML.png)

[link for video](https://github.com/elad361/flight-simulation/blob/main/zoom_0.mp4)
