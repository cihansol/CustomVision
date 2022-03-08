# CustomVision Docker Service POC
Custom Vision Service

## Requirements

* [Docker Desktop](https://www.docker.com/products/docker-desktop) ([WSL 2](https://docs.docker.com/desktop/windows/wsl/))
* [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)

## Setup Instructions (Windows)

1. Make sure Docker is running and it's in your PATH Environment Variable.
2. Export your own model docker image from [Custom Vision](https://www.customvision.ai/) or use the [provided demo model](https://github.com/cihansol/CustomVision/releases/download/Release/1514101266af4aca92dcfdee24bec30f.DockerFile.Linux.zip) and put it into the `\Docker` directory.
3. Either drag and drop the .zip package onto the `DragNDropRunWindows.bat` or open a powershell window in the `\Docker` directory and type: `ExtractBuildRun.ps1 1514101266af4aca92dcfdee24bec30f.DockerFile.Linux.zip` where `1514101266af4aca92dcfdee24bec30f.DockerFile.Linux.zip` is the name of the model package file.
4. After it builds and runs it will display `* Running on http://172.17.0.2:80/ (Press CTRL+C to quit)`. This will be the internal address the server is running at, it can be accessed locally at `http://127.0.0.1/image`
5. To terminate the service in the console window press `CTRL+C`

## Usage
1. Build the solution CustomVision.sln
2. Make sure to check that the `samples` directory exists in the output folder
3. Run the demo project `CustomVisionDemo`
4. Observe the output predictions based on the sample images.
