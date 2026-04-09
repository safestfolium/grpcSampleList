# gRPC Sample List

A .NET Framework 4.5 Visual Studio solution demonstrating a gRPC server with IP-based whitelist access control, built with WinForms UI.

## Prerequisites

- Visual Studio 2015 or later
- .NET Framework 4.5
- `nuget.exe` on your PATH (download from https://www.nuget.org/downloads)
- Windows OS (WinForms + native gRPC DLLs)

## Quick Start

```bat
build.bat        # restore NuGet packages, build solution, copy native DLLs
run_server.bat   # launch the gRPC server (WinForms)
run_client.bat   # launch the gRPC client (WinForms)
```

## Architecture

```
GrpcWhitelistSample.sln
├── GrpcShared      (Class Library, net45)
│   ├── Proto/hello.proto          — service definition
│   ├── Generated/Hello.cs         — protobuf message classes
│   ├── Generated/HelloGrpc.cs     — gRPC service stubs
│   └── WhitelistStore.cs          — thread-safe whitelist + history store
│
├── GrpcServer      (WinForms WinExe, net45)
│   ├── Core/WhitelistInterceptor  — gRPC server interceptor (enforces whitelist)
│   ├── Services/GreeterService    — SayHello implementation
│   ├── GrpcServerHost             — starts/stops the gRPC server on port 50051
│   ├── Forms/MainForm             — main window: status + access history
│   ├── Forms/GrpcSettingsForm     — whitelist settings UI
│   └── Forms/AddClientDialog      — dialog to pick/enter an IP to whitelist
│
└── GrpcClient      (WinForms WinExe, net45)
    ├── Forms/ClientForm           — UI to call SayHello, displays response + log
    └── Program.cs
```

## How to Test

1. Run `run_server.bat` — the server starts on port 50051.
2. Open **gRPC Settings** in the server window.
3. Choose **"Allow only whitelisted clients"** and add `127.0.0.1`.
4. Run `run_client.bat` — enter a name and click **Send SayHello**.
5. A successful response appears. If your IP is not whitelisted, you get a `PERMISSION_DENIED` error.

## grpcurl Test

```bash
grpcurl -plaintext -d '{"name":"World"}' localhost:50051 hello.Greeter/SayHello
```

## How the Whitelist Works

- **WhitelistStore** is a thread-safe singleton that persists settings to `whitelist_config.json`.
- On each incoming gRPC call, **WhitelistInterceptor** extracts the client IP from `context.Peer` (format: `ipv4:1.2.3.4:port`).
- If whitelist is **disabled** → all clients are allowed, attempt is recorded as Allowed.
- If whitelist is **enabled** → only IPs in the allowed list pass through; others receive `PERMISSION_DENIED`.
- Every attempt (allowed or denied) is recorded in the in-memory history, visible in the server UI and in the **Add Client** dialog.
- The default state is **whitelist enabled** (active). You can switch modes from **gRPC Settings**.

---

# ListHandleSample

Same IP-whitelist gRPC WinForms server, but using **proto-mode**: the `Grpc.Tools` NuGet package drives `protoc` automatically at build time to generate `Hello.cs` and `HelloGrpc.cs` from `Proto/hello.proto`. No hand-written generated stubs — the `.proto` file is the single source of truth.

## Prerequisites (ListHandleSample)

- **Windows** (WinForms)
- **.NET Framework 4.5** or later runtime
- **MSBuild** (Visual Studio 2013+ or [Build Tools](https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2022))
- **NuGet CLI** — place `nuget.exe` in `ListHandleSample\` or on `PATH`

## Project Structure (ListHandleSample)

```
ListHandleSample/
├── ListHandleSample.csproj      Classic MSBuild project (net45, WinExe)
│                                 Imports Grpc.Tools.props + Grpc.Tools.targets
│                                 <Protobuf Include="Proto\hello.proto" GrpcServices="Both" />
├── packages.config              Includes Grpc.Tools 2.46.6 (developmentDependency)
├── build.bat                    Build script
├── Proto/
│   └── hello.proto              gRPC service definition (source of truth)
│                                 ↳ C# stubs are generated HERE at build time by protoc
├── Core/
│   ├── WhitelistStore.cs        Thread-safe singleton: whitelist state + JSON persistence
│   └── WhitelistInterceptor.cs  gRPC server interceptor for IP enforcement
├── Services/
│   └── GreeterService.cs        Greeter service implementation
├── Forms/
│   ├── MainForm.cs/.Designer.cs         Main window
│   ├── GrpcSettingsForm.cs/.Designer.cs Settings dialog
│   └── AddClientDialog.cs/.Designer.cs  Add-client dialog
├── GrpcServer.cs                Background gRPC server thread
├── Program.cs                   Entry point
└── Properties/
    └── AssemblyInfo.cs
```

> **Key difference**: there is no `Generated/` folder. `Grpc.Tools` runs `protoc` + `grpc_csharp_plugin` at build time; the generated `.cs` files land in `obj\` and are automatically included in compilation.

## Build (ListHandleSample)

```batch
cd ListHandleSample
build.bat
```

## How proto-mode works

```xml
<!-- top of .csproj — declares the Protobuf item type -->
<Import Project="packages\Grpc.Tools.2.46.6\build\Grpc.Tools.props" />

<!-- Proto file — protoc generates Hello.cs + HelloGrpc.cs during BeforeBuild -->
<ItemGroup>
  <Protobuf Include="Proto\hello.proto" GrpcServices="Both" />
</ItemGroup>

<!-- bottom of .csproj — runs protoc, adds generated files to Compile -->
<Import Project="packages\Grpc.Tools.2.46.6\build\Grpc.Tools.targets" />
```

## NuGet Packages (ListHandleSample)

| Package | Version | Purpose |
|---------|---------|---------|
| `Grpc.Core` | 2.46.6 | gRPC server/client runtime for .NET Framework |
| `Grpc.Core.Api` | 2.46.6 | gRPC abstractions |
| `Grpc.Tools` | 2.46.6 | `protoc` + `grpc_csharp_plugin` — **build-time only** |
| `Google.Protobuf` | 3.21.12 | Protobuf serialization |
| `Newtonsoft.Json` | 13.0.3 | JSON config persistence |
