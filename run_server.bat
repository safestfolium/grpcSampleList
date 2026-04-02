@echo off
echo === Starting gRPC Server ===
echo.

:: Check if exe exists
if not exist "GrpcServer\bin\Release\GrpcServer.exe" (
    echo ERROR: GrpcServer.exe not found.
    echo Please run build.bat first.
    echo.
    pause
    exit /b 1
)

:: Check if native gRPC DLLs exist, copy if missing
if not exist "GrpcServer\bin\Release\grpc_csharp_ext.x64.dll" (
    echo [INFO] Native gRPC DLLs not found in Release folder, copying now...
    xcopy /Y /Q "packages\Grpc.Core.2.46.6\runtimes\win\native\*.dll" "GrpcServer\bin\Release\"
    if errorlevel 1 (
        echo ERROR: Failed to copy native gRPC DLLs.
        echo Make sure you ran build.bat successfully first.
        pause
        exit /b 1
    )
    echo [INFO] Native DLLs copied successfully.
    echo.
)

echo Starting GrpcServer.exe ...
echo (If the window closes immediately, run this bat from a cmd window to see the error)
echo.
GrpcServer\bin\Release\GrpcServer.exe
if errorlevel 1 (
    echo.
    echo ERROR: GrpcServer.exe exited with an error (exit code %errorlevel%).
    echo Common causes:
    echo   1. Missing native DLL: grpc_csharp_ext.x64.dll
    echo   2. Port 50051 already in use
    echo   3. Missing .NET Framework 4.5
    echo.
    pause
)