## Retakes Formatting
A tool that helps with formatting excel files to be suitable for VA retakes in Voice Processing.

## Motivation
This tool was developed specifically for [Skywind Project](https://tesrskywind.com)
 which is a total conversion mod that is remaking the 2002 game The Elder Scrolls III: Morrowind in the more modern Skyrim: Special Edition engine.


It formats the NPCs lines sheet to make it easier for filecutters and voice processing team to work with and creates another sheet for retakes to give voice actors easier layout for reading lines.

## Dependencies
- [Epplus](https://github.com/EPPlusSoftware/EPPlus) : enables reading and writing Excel files using the Office Open XML format (xlsx), without the need of interop.
- [ILMerge](https://github.com/dotnet/ILMerge): for embedding the dll files into a single executable .

## Screenshots

The main form which is a simple one for just choosing the script file:
![image](https://user-images.githubusercontent.com/39552203/90322662-2be81400-df57-11ea-8f5c-5d5d66711b0b.png)

#### The script before applying the formatting:

![image](https://user-images.githubusercontent.com/39552203/90322658-24c10600-df57-11ea-81f8-2e9be452dd0a.png)

#### After applying the formatting:
Base Sheet:
![image](https://user-images.githubusercontent.com/39552203/90322663-31ddf500-df57-11ea-91a4-12b90e0db09b.png)

Reformatted Sheet:

![image](https://user-images.githubusercontent.com/39552203/90322667-360a1280-df57-11ea-824a-8354608a0a83.png)
