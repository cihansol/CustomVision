@echo off
cd /d "%~dp0"
Powershell.exe -executionpolicy remotesigned -File ExtractBuildRun.ps1 %1
pause