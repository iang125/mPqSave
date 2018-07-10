echo off
"%~dp0mPqSave.exe" p "%~dp0savekey" i "%1" "%1_new"
if %errorlevel% neq 0 pause
