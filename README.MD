# Escapeegy

## How to get started

The following steps assume you have cloned the repository locally. 
If you didn't clone the repository yet, here you go:
```
git clone git@github.com:JonasOelke/escapeegy.git
```

Ideally you use [GitHub with an SSH Key](https://docs.github.com/en/authentication/connecting-to-github-with-ssh). 
It makes life a lot easier when cloning, pushing and pulling repositories. 

## Tools to use and their versions 
### Unity 2021.3.11f LTS 
It's crucial that we all use the same Unity Version. 
Using any different Version should always be a team decision that everyone is aware of and has agreed. 
In general one should use the latest LTS version available. If you feel we are missing necessary functionality 
that a non-lts version provides, we should consider changing to a non-lts version. 
But if there isn't any good reason to do so, we should always stick to the LTS version. 

### Github Desktop
If you do not know all the git commands, you can use [GitHub Desktop](https://desktop.github.com/) to manage your local repository.
It's a nice GUI that makes it easy to commit, push and pull changes. 
You can also use the git gui in your IDE of choice, but it's nice to have a backup.

### Git Large File Storage (LFS)
To manage binary files like images, audio and video files and other assets we use [Git Large File Storage (LFS)](https://git-lfs.github.com/).
It's a git extension that allows us to store large files in a separate repository. You need to install it to be able to work with the project.
Install it with 
```
git lfs install
```
You can find more installation instructions [here](https://git-lfs.github.com/).

### JetBrains Rider 2022.x
For developing C#-Files it's recommend to use JetBrains Rider. 
The version doesn't really matter, but try to use 2022.1 or above. 

You can still use Visual Studio Code if you feel more comfortable using it, 
but its easier to help each other if we used all the same tools. 

### Rider Plugins

#### CSharpier
To enforce a consistent code style, we use the CSharpier Plugin. 
Using it ensures we are consistent with our code style and avoids unnecessary code changes. 
After installing the plugin make sure to enable it in the settings. You can find the settings under 
```
Tools -> CSharpier -> Run on save
```

See more: [https://plugins.jetbrains.com/plugin/18243-csharpier](https://plugins.jetbrains.com/plugin/18243-csharpier)

#### SonarLint
SonarLint is a plugin that helps us to write better code. It lints our code and gives us hints on how to improve it.
We should always try to fix all the issues SonarLint reports.
See more: [https://plugins.jetbrains.com/plugin/7973-sonarlint](https://plugins.jetbrains.com/plugin/7973-sonarlint)

#### GitHub Copilot
This plugin is still in beta, but it's really cool (most of the lines in this README are written by Copilot).
It speeds up our development by suggesting code snippets. 
See more: [https://plugins.jetbrains.com/plugin/17224-github-copilot](https://plugins.jetbrains.com/plugin/17224-github-copilot)

## Develop and Debug on your real Android Device
Ensure your device is connected to your computer via USB. 
Then open the Unity Project and go to `File > Build Settings...`.
In the Build Settings window, select `Android` and in the `Run Device` dropdown select your device.

If your device is not listed, you need to enable USB Debugging on your device.
For guidance on how to do that, see [https://developer.android.com/studio/debug/dev-options](https://developer.android.com/studio/debug/dev-options)
