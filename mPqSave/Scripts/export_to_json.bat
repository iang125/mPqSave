echo off
"%~dp0mPqSave.exe" p "%~dp0savekey" x "%1" "%1.export.json"
if %errorlevel% neq 0 pause
