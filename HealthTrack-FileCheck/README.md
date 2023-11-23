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
The easiest, and prettiest method is to open the project in visual studio and run in debug mode

To just run the project standalone, the release executable can be found in.

{Insert your repo directory here}\HealthTrack-FileCheck\HealthTrack-FileCheck\bin\Release\net6.0
From there https:localhost:5001 will be avable to access the page (though I belive css is blocked for a local run, so it will probably be ugly)


## Overall thoughts, Potential next steps
One thing I was not able to solve was how to refresh the update count without faking an async, that would be my first step.
Secondly I would then like to get the logic out of the blazor page and put it into it's own service, ideally with an interface that is injected in.
Finally, exploring webkit directory to see if it is possible to just get the folder name without having to upload the folder would increase usability.

The biggest issue is the all to all compairson problem that would need to be overcome if trying to parallelise to save processing time. 
(Though as explained in https://eprints.qut.edu.au/87374/, doing this in an efficient manner at scale isn't exacly trivial)