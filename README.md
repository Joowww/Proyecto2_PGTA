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
