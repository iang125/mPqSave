echo off
"%~dp0mPqSave.exe" p "%~dp0savekey" s "%1" "%1_modified" "%~dp0items.csx" "%~dp0tickets.csx"
if %errorlevel% neq 0 pause
