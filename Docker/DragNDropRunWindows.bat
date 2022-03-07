@echo off
Powershell.exe -executionpolicy remotesigned -File ExtractBuildRun.ps1 %1
pause