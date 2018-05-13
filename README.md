# Realtime Spectrograph
Listens to your default recording device (microphone or StereoMix) and creates a 2d time vs. frequency plot where pixel values are relative to frequency power (in a linear or log scale). This example is not optimized for speed, but it is optimized for simplicity and should be very easy to learn from.

* This project forked from repository consisting group of project. All others project from source repository removed. 
* Reworked parth of code, that sets palette of spectrogram. 
* Changed UI.

* Based on <a href='https://github.com/swharden/Csharp-Data-Visualization/tree/master/projects/18-01-11_microphone_spectrograph'>this project</a>
* This examples uses [naudio](https://github.com/naudio/NAudio) library to access the sound card

![](spectrograph.gif)
