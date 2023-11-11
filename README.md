# Unofficial LW Example mod (based on Visual Studio Community 2022, netcoreapp3.1)
This serves as a template for LogicWorld mods, featuring a full VS22 (Microsoft Visual Studio Community 2022, **not** VSCode) project setup, but this can most likely be adapted by other C# IDEs to be able to use it on linux. Furthermore, an IDE (e.g. VS22) is not strictly needed, although it can be very convenient to use one. If you do decide to use one you need to install it first.


# Important information
This first section contains all of the important information to get you started. If you choose a mod loading priority that is non-zero, please read the corresponding section `A word on mod loading priorities` below.

## Directory structure
The top level contains the sln file along with some git stuff. Then, there exists one folder per project, of which we, currently, have exctly one.
In this there are the bin and object folders (which are just C# build and intermediate build folders), along with the .csproj file which contains dll references.
Additionally this folder also contains your main mod folder (which is what you would put into the GameData folder to install your mod. Or you could use a symbolic link as described below).
This contains the following things in this case (but this is not an exhaustive list):
- `components/` -- this contains the component definitions
    - `ExampleComponent.succ`
- `languages/` -- this contains localizations
    - `English/`
        - `English.succ`
    - `German/`
        - `German.succ`
- `src/` -- this contains the c# sources
    - `server/` -- this contains our code
        - `ExampleComponent.cs`
        - `Loader.cs`
- `manifest.succ` -- this contains metadata about the mod

## Filling out the required info
1. In the LwExampleMod.csproj file there is a field `<ModAuthor>YOUR_NAME_OR_ALIAS_WITHOUT_SPACES</ModAuthor>`. Replace the contents with something that you want to be recognized as, without spaces. If possible, the first letter should be uppercase.
2. Replace `YOUR_NAME_OR_ALIAS_WITHOUT_SPACES` in all files. (You can perform a simple search-and-replace operation, or do it manually as it is always at the top of the file)
3. Rename project files and folders:
    Close VS22 if you had it open and replace the text `LwExampleMod` in the following file and folderanmes with something that you like:
    - `/LwExampleMod.sln`
    - `/LwExampleMod/LwExampleMod.csproj`
    - `/LwExampleMod/` (this is a folder, indicated by the trailing slash)
    - `/LwExampleMod/ExampleMod/` (the sub-folder does not have to match name-wise, but there is no reason why they should not match)
    Additionally, open up the former `LwExampleMod.sln` and now replace the text `LwExampleMod`, with what you decided to go with (in three places)

    Furthermore, you most likely want to rename the component, specifically `ExampleComponent` to something else. To do this, replace the text `ExampleComponent` inside the file `/LwExampleMod/ExampleMod/src/server/ExampleComponent.cs` (and also in this filename) with something that you like. This should start with an uppercase letter, and contain no spaces. If you follow the C# naming convention, each new word should start with an uppercase letter (still no spaces though, or compilation will fail).
    Perform this same filename+content replacement for `/LwExampleMod/ExampleMod/components/ExampleComponent.cs`, and also replace `ExampleComponent` in all `languages/*/*.succ` files.

## A word on mod loading priorities
If you have performed the replacement steps, you should have seen the warning on the topic of mod loading priorities. A higher priority means that a mod is loaded first. Mods have needlessly used very high priorities in the past, which then makes replacing the vanilla modloader difficult. If you release a mod, it will most likely be possible that some mod needs to load before ALL others, including yours. Therefore you should not choose a priority higher than, or equal to 90. Conversely. Some mods might need to load after ALL mods. Therefore also do not choose a priority that is less than, or equal to -90. To be honest almost all mods should work totally fine when choosing a priority of 0. If your mod then needs to load before a specific other mod, choose a priority slighly higher than the other priority (e.g. one or two larger). If you need to choose a priority of 90+, it is likely worth discussing that on the official (LogicWorld Discord server)[https://discord.gg/NaXhtFbA2h] in #modding to avoid conflicts.

# Supplemental information

This project uses netcoreapp3.1 as a runtime as this seems to work well for both client and server. You can of course change this, as it does not really matter, as logicworld compiles the code anyway if you provide sources.
If you instead opt to compile dlls, you should choose .net standard 2.0 or even 1.0 such that this works on both client and server (You may have to do some trial and error in this case).

This template was created and tested for 0.91.1 (but likely will also work with newer versions).

## Symlinks
For easy deploying you can create a symbolic link that creates a symlink at `LW_INSTALL_DIRECTORY/GameData/LwExampleMod/` which points to `/LwExampleMod/ExampleMod/`, such that LogicWorld thinks there is a folder containing your mod folder, while this is actually still sitting in your VS project folder. Very convenient.

## Dependency inclusion
One the main reasons why to use an IDE in this case is to get autocompletion suggestions. For this, you will need to add LogicWorld client and server DLLs which contain the types that you want to use.
To add this, rightclick Dependencies, 

![image](https://github.com/GHXX/LogicWorld-ExampleMod/assets/5289076/0ab3f04e-5c6c-4891-a13f-1f08101bd9c6)

and then click on `Add Project Reference...` (or alternatively something that sounds similar). 

![image](https://github.com/GHXX/LogicWorld-ExampleMod/assets/5289076/21f787ff-4d11-4de3-a090-ea5c2a623a14)

This will then bring up this window:

![image](https://github.com/GHXX/LogicWorld-ExampleMod/assets/5289076/a7e2384b-62f9-4546-bf48-0fffeddc8da9)

You can then click on "Browse" on the left side which may or may not list the dll you want to add (To add it you check the checkbox). If your dll is not listed (which is the case very likely), you want to click `Browse...` on the bottom and then simply select it from your LogicWorld installation directory.
Due to the fact that the csproj already has a few references defined (which may be invalid, depending on your directory locations), you may want to remove these pre-existing ones.


# Result
![image](https://github.com/GHXX/LogicWorld-ExampleMod/assets/5289076/9dfa797f-388e-4920-9a45-d003bb737a4a)
![image](https://github.com/GHXX/LogicWorld-ExampleMod/assets/5289076/8c96b140-b50f-49a0-a35c-76fbd6a2ff84)


# License
As far as the license of this goes, feel free to use this code in parts or in full, without any need to attribute credits, for any kind of use, free of charge. This, of course, however does not come with any kind of warranty or any fitness guarantees. In other words 'you use it at your own risk'.
