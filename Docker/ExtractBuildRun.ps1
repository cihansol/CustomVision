#Azure CustomVision Docker Script
#https://github.com/cihansol
param ($dockerPackageName)
if ($dockerPackageName -eq $null) {
$dockerPackageName = read-host -Prompt "Please enter the package zip name" 
}

$runningName = "cvl-$(get-date -f yyyy-MM-dd-HHmmss)"
$imageDir = ".\image"
$dockerFilePath = "$imageDir\Dockerfile"

# Clean up
if (Test-Path -Path $imageDir) {
    Remove-Item -Recurse -Force $imageDir
}

# Extract the Custom Vision image data
Write-Host "[1] Extracting docker image package."
Expand-Archive -Force -Path $dockerPackageName -DestinationPath ".\image"


# Build the image
$env:DOCKER_SCAN_SUGGEST = 'false'
if (-Not (Test-Path -Path $dockerFilePath)) {
    Write-Host "Unable to find the required docker file."
    return
}
Write-Host "[2] Building docker image."
Push-Location $imageDir
docker build . -t custom-vision-local
Pop-Location


# Run
Write-Host "[3] Running build.."
docker run -a STDOUT -a STDERR -i -t --rm --name $runningName -p80:80 custom-vision-local


