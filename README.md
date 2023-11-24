# Duplicate file finder


## Task Details 
Develop a blazor server application.

Take a directory path input from the web ui and recursively scan the path find all duplicate files under the starting folder.
Duplicates checking should include by name and contents (using checksum/hash/other mechanism).  Ideally progress/counts should be displayed during the scan.

### Additional notes
* A zip file containing some sample directories can be downloaded from : https://healthtrackstorage.blob.core.windows.net/public/DuplicateTestExamples.zip
* Task is intended to take less than 4 hours. You can highlight areas/edge cases your development hasn't covered 
 or where future development should focus.  This timing assumes you have a prefered development environment setup/configured.
* Task can be submitted as either a zip file or link to gitlab/github project (or another source control provider).
* .net/C# preferred.
* The project should include build/run instructions.


## How to Run
The easiest, and prettiest method is to open the project in visual studio and run in debug mode.

Note, if the project settings have not transfered in the git upload, you will need to start both the Solution.RestAPI and the HealthTrack-FileCheck solutions.

The hosting of the API is setup currently as https://localhost:7012, if this conflicts on your machine you will need to change both the project settings for the api project, and the injection in the healthtrack-filecheck program.cs file.

A very small selection of tets have been completed in the Solution.Tests folder. There is a lot to test here, but I confirmed the two positive tests of reading file and data duplicates. Further tests would include the "both" data and file itendical, plus the negative tests of confirming files that don't match shoudn't.



## Overall thoughts, Potential next steps
One thing I would like to have done was add the progress bar. This had been started with the IProgressReaderWriter interface and implimentation. The quick hacky solution would have been write to a json file the progress, with a unique guid provided on buttonclick of the process in the UI. A more sustainable solution would be to mirror the pattern followed by azure functions (a log progress tracker).
