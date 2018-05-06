## Setup guide:
Once you've compiled this project, there are two configuration steps that will be necessary in order to get the application to work:
1. Follow the "Step 1: Turn on the Drive API" instructions in [Google's reference docs](https://developers.google.com/drive/v3/web/quickstart/dotnet) and download the client secret json file to your bin directory.
2. Create an app.settings.config file in your bin directory. You can do this by starting up the application, going to "application settings", and selecting "Save current configuration".
3. As of this writing, the remote root and game directories need to be added manually. On your Google Drive, create a folder anywhere named "carousel-save-states". For each game you'd like to add, create a subdirectory in this remote save states directory.

## Demo:
![Alt Text](https://github.com/millsja/carousel/blob/master/docs/carousel-demo.gif?raw=true)
