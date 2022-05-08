![GitHub forks](https://img.shields.io/github/forks/brianreville/OSBookReviewWepApi?style=for-the-badge)
![GitHub contributors](https://img.shields.io/github/contributors/brianreville/OSBookReviewWepApi?style=for-the-badge)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/brianreville/OSBookReviewWepApi?style=for-the-badge)

[![Build and deploy .NET Core application](https://github.com/brianreville/OSBookReviewWepApi/actions/workflows/bookreview2022.yml/badge.svg)](https://github.com/brianreville/OSBookReviewWepApi/actions/workflows/bookreview2022.yml)

# OSBookReviewWepApi

Open Source Web App and Api for Book Review .Net Maui appilcation for College Project

## Project Overview

### Overall Project Architecture Diagram

![Screenshot](OSProjectDiagram.png)

### Wep Api Structure - (Diagram and Text Explaination)(TBC)

### Data Access Library -

Please see associated repository
[OS Data Access Library](https://github.com/brianreville/OSDataAccessLibrary)

### .Net MAUI

Please see associated repository
[OS Book Review .NET MAUI App ](https://github.com/brianreville/OSBookReviewMAUI)

### Web API Unit Testing Project
Please see associated repository
[OS Book Review Tests  ](https://github.com/brianreville/OSBookReviewTests)

### Database Structure - (ERM Image Displayed Below)

ERM Diagram
![Screenshot](ERMDiagram.PNG)

Database Set-Up Script and Stored Procedure Files saved in SampleDB Folder 
Sample Dataset Stored in SampleDB Folder for Upload to Database when Set Up Script Completed

### Additional Sources

Database Dataset - Sample Dataset Taken from Kaggle and then adjusted to fit designed db
[Kaggle Dataset](https://www.kaggle.com/arashnic/book-recommendation-dataset)

## How to run the project in the Developement Enviorment

1. Visual Studio 2022 Preview is required to run the complete solution correctly. [Visual Studio 2022 PREVIEW](https://visualstudio.microsoft.com/fr/vs/preview/)
2. Create a folder that contains the three different repositories
3. Open this folder, that you just created, with Visual Studio 2022 Preview. It should look like this : ![](https://user-images.githubusercontent.com/62793491/161441208-d83e5603-0785-42d4-923e-2f9308ed80d0.png)
4. To open run of the three projects, click on the project you want and click on the `.sln` file ![](https://user-images.githubusercontent.com/62793491/161441244-45d3a28d-c77f-4183-a69c-3151ee81be6d.png)

## Testing 
Unit Testing has been implemented on the project and current implemented on the BookReviewController . 
The repository for the Unit Testing project can be found here. [Unit Testing Repo](https://github.com/brianreville/OSBookReviewTests) 

Test Result Image 
![image](https://user-images.githubusercontent.com/49170791/167315494-a3251d72-56ed-4819-9774-c1a491f0efcb.png)


## Useful Links
Microsoft Azure Getting Started Page
[Azure Tutorial](https://azure.microsoft.com/en-us/get-started/#learning-resources) 

Microsoft Tutotiral on Web Api
[.Net 6.0 Tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)

Tim Corey Creating a Web Api with Authentication using JWT
[Tim Cory Youtube](https://www.youtube.com/watch?v=_LdiqQ13NBo) 

Jason Watmore Tutorial on Creating a .net 6 Wep API
[Jason Watmore Tutorial](https://jasonwatmore.com/post/2022/02/04/net-6-minimal-api-tutorial-and-example)
