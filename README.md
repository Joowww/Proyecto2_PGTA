# ASTERIX CAT048 DECODER
This document explains the functionality of the ASTERIX CAT048 Decoder software, its main features, and how the different parts of the code are integrated to process, visualize, and export air traffic data.

<em>Group members: Alejandro Curiel Molina, Marina Martín Ferrer, Jose Carlos Martínez Conde, Joel Moreno de Toro, Èrica Parra Moya, Paula Valle Bové, Mireia Viladot Saló</em>.

## 1. General Description of the Software
The ASTERIX CAT048 Decoder is an application developed in C# to decode ASTERIX data from category 048. The software enables:
### 1.1 Decoding and Exporting
- Decoding ASTERIX CAT048 messages.
- Altitude correction based on QNH for altitudes below 6000 feet, applying standard atmospheric pressure.
- Exporting decoded data to CSV format.
### 1.2 Data Filtering
- Application of data filters and combinations of them.
    - Filter to remove "pure blanks" fixed transponders.
    - Geographic filter to restrict data to specific latitude and longitude ranges.
    - Altitude filter to eliminate flights above 6000 feet.
    - Filter to remove "on ground" flights.
### 1.3 Simulation
- Real-time visualization of trajectories on a map.
- Simulation of positions at 1-second intervals.
- Real-time adjustment of simulation speed.
- Map provider change.
- **Extra functionality:** Allows the input of two target identifications to simultaneously display the trajectories of two planes and calculate the distance between them on each antenna rotation.

## 2. Installation
### 2.1 Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/6.0) or higher.
- Clone this repository and open it in a C# compatible development environment (e.g., Visual Studio or Visual Studio Code).
### 2.2 Cloning the repository

```bash
git clone https://github.com/Joowww/Proyecto2_PGTA.git
cd Proyecto2_PGTA
```
### 2.3 Dependencies
The main dependencies of this project are:
- **Accord** (Version 3.8.0): Library for image processing, machine learning, statistical analysis, etc.
- **Accord.Math** (Version 3.8.0): Extension of Accord.NET for mathematical operations.
- **VisioForge.DotNet.Core.Redist.Base.x64** (Version 15.10.22): Library for video and multimedia manipulation.
- **Zen.Barcode.Rendering.Framework** (Version 3.1.10729.1): Library for generating barcodes in .NET.

This project uses NuGet to manage dependencies. After cloning the repository, make sure to restore all necessary dependencies by running the following command in the terminal or command line from the project folder:
```bash
dotnet restore
```
## 3. User Manual and Usage Guide
**1. Welcome Menu**: The welcome menu includes a dropdown with several buttons. There is an “About Us” button that displays the names of the group members as well as their institutional email addresses. Next, there is a “Settings” button. Clicking this button allows you to customize the appearance of the application. You can switch the form’s theme between dark mode and light mode. Finally, there is the “Help” button, which is mentioned at the end of the manual.
