@echo off
echo === gRPC Whitelist Sample - Build Script ===
echo [1/3] Restoring NuGet packages...
nuget restore GrpcWhitelistSample.csproj -PackagesDirectory packages
if errorlevel 1 ( echo ERROR: NuGet restore failed. & pause & exit /b 1 )
echo [2/3] Building...
msbuild GrpcWhitelistSample.csproj /p:Configuration=Release /nologo /v:minimal
if errorlevel 1 ( echo ERROR: Build failed. & pause & exit /b 1 )
echo [3/3] Copying native gRPC DLLs...
xcopy /Y /Q packages\Grpc.Core.2.46.6\runtimes\win\native\*.dll bin\Release\
echo === Build succeeded! Run: bin\Release\GrpcWhitelistSample.exe ===
pause
