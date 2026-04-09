@echo off
echo === gRPC Whitelist Sample - Build ===

echo [1/3] Restoring NuGet packages...
nuget restore GrpcWhitelistSample.sln -PackagesDirectory packages
if errorlevel 1 ( echo ERROR: NuGet restore failed. & pause & exit /b 1 )

echo [2/3] Building solution...
msbuild GrpcWhitelistSample.sln /p:Configuration=Release /nologo /v:minimal
if errorlevel 1 ( echo ERROR: Build failed. & pause & exit /b 1 )

echo [3/3] Copying native gRPC DLLs...
xcopy /Y /Q packages\Grpc.Core.2.46.6\runtimes\win\native\*.dll GrpcServer\bin\Release\
xcopy /Y /Q packages\Grpc.Core.2.46.6\runtimes\win\native\*.dll GrpcClient\bin\Release\

echo.
echo === Build succeeded! ===
echo Run server: run_server.bat
echo Run client: run_client.bat
pause
