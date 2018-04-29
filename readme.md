# DartStatistics
Small Tool to get a rough estimation how complex a Dart project is.

Execute in the folder that you want to  examine. It will process all files in the folder and subfolders.

It outputs the number of

* all lines of the project
* lines that contain source code 
* characters of code
* classes

Lines containing only comments are not counted as code and character count stops as soon a `//` is encountered.

I know this gives only a very rough estimation of complexity but might be helpful to compare different solutions to the same problem.

The executable is contained in the root of this repository so you don't have to have VS to build it. 

