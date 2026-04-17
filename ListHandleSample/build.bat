@echo off
echo === ListHandleSample - Build Script ===

echo [1/3] Restoring NuGet packages (includes Grpc.Tools with protoc)...
nuget restore ListHandleSample.csproj -PackagesDirectory packages
if errorlevel 1 ( echo ERROR: NuGet restore failed. & pause & exit /b 1 )

echo [2/3] Building (Grpc.Tools auto-generates C# from Proto\hello.proto)...
msbuild ListHandleSample.csproj /p:Configuration=Release /nologo /v:minimal
if errorlevel 1 ( echo ERROR: Build failed. & pause & exit /b 1 )

echo [3/3] Copying native gRPC DLLs...
xcopy /Y /Q packages\Grpc.Core.2.46.6\runtimes\win\native\*.dll bin\Release\

echo.
echo === Build succeeded! ===
echo Run: bin\Release\ListHandleSample.exe
echo.
echo NOTE: Proto-mode is active. To regenerate C# stubs manually from the .proto file,
echo       run msbuild again or modify Proto\hello.proto — Grpc.Tools handles code
echo       generation automatically during the build via protoc.
pause
