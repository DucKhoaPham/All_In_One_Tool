@echo OFF
echo Stopping old service version...
net stop "AutoUploadFile"
echo Uninstalling old service version...
sc delete "AutoUploadFile"

echo Installing service...
sc create AutoUploadFile binPath= "D:\QI\Code\WorkerService\bin\Release\netcoreapp3.1\WorkerService.exe" DisplayName= "AutoUploadFile" start= auto
echo Starting server complete
pause