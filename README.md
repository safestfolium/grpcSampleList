# gRPC Sample List

A collection of **C# .NET Framework WinForms + gRPC** sample applications.

---

## Projects

| Folder | Description |
|--------|-------------|
| [`GrpcWhitelistSample`](#grpcwhitelistsample) | IP whitelist server — hand-written gRPC stubs (no protoc required) |
| [`ListHandleSample`](#listhandlesample) | IP whitelist server — **proto-mode** (`Grpc.Tools` auto-generates C# stubs from `.proto` at build time) |

---

# GrpcWhitelistSample

A complete **C# .NET Framework 4.0 WinForms + gRPC** sample application demonstrating IP whitelisting for gRPC server access control.

---

## Prerequisites

- **Windows** (WinForms requires Windows)
- **.NET Framework 4.0** or later runtime
- **MSBuild** (included with Visual Studio 2013+ or available via [Build Tools for Visual Studio](https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2022))
- **NuGet CLI** — Download `nuget.exe` from: https://dist.nuget.org/win-x86-commandline/latest/nuget.exe  
  Place it in `GrpcWhitelistSample\` folder or somewhere on your `PATH`.

---

## Project Structure

```
GrpcWhitelistSample/
├── GrpcWhitelistSample.csproj   Classic MSBuild project (net40, WinExe)
├── packages.config              NuGet package references
├── build.bat                    Build script
├── run.bat                      Launch script
├── Proto/
│   └── hello.proto              gRPC service definition
├── Generated/
│   ├── Hello.cs                 Hand-written protobuf message stubs
│   └── HelloGrpc.cs             Hand-written gRPC service stubs
├── Core/
│   ├── WhitelistStore.cs        Thread-safe singleton for whitelist state + JSON persistence
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

---

## Build

1. Open a **Command Prompt** in the `GrpcWhitelistSample\` directory.
2. Run the build script:

```batch
build.bat
```

This will:
1. Restore NuGet packages (`Grpc.Core 2.46.6`, `Google.Protobuf 3.21.12`, `Newtonsoft.Json 13.0.3`)
2. Build the project using MSBuild (Release configuration)
3. Copy native gRPC DLLs (`grpc_csharp_ext.x64.dll`, etc.) to `bin\Release\`

---

## Run

```batch
run.bat
```

Or directly:

```batch
bin\Release\GrpcWhitelistSample.exe
```

The gRPC server starts automatically on port **50051** in a background thread when the WinForms app launches.

---

## Architecture

### gRPC Server
- Uses **`Grpc.Core` 2.46.6** (supports .NET Framework 4.0 — does **not** require ASP.NET Core)
- Listens on `0.0.0.0:50051` (insecure/plaintext)
- Started in a background thread from `GrpcServer.Start()` called at app startup
- Implements the `hello.Greeter` service (`SayHello` RPC)

### Whitelist / Access Control
- **`WhitelistInterceptor`** intercepts every incoming gRPC call
- Extracts the client IP from `context.Peer` (format: `"ipv4:1.2.3.4:port"`)
- If whitelist is **disabled**: all clients are allowed
- If whitelist is **enabled**: only IPs in the allowed list are accepted; others receive `PermissionDenied`
- Every attempt (IP, timestamp, allowed/denied) is recorded in in-memory history

### WhitelistStore
- Thread-safe static class using `lock(_lock)`
- Persists `whitelistEnabled` and `allowedClients` to `whitelist_config.json` (next to the exe)
- Fires `StateChanged` event after every mutation so the UI can refresh

### WinForms UI
- **MainForm**: Shows whitelist status, gRPC port, and full access history (newest first)
- **GrpcSettingsForm**: Radio buttons for access mode + listbox of whitelisted IPs with Add/Remove
- **AddClientDialog**: Pick from access history or enter IP manually

---

## Testing with grpcurl

Install [grpcurl](https://github.com/fullstorydev/grpcurl) and test the server:

```bash
# Call SayHello (allowed client)
grpcurl -plaintext -d '{"name": "World"}' localhost:50051 hello.Greeter/SayHello

# Expected response (if allowed):
# { "message": "Hello, World! You are an authorized client." }

# Expected response (if blocked by whitelist):
# ERROR: Code: PermissionDenied
# Message: Client IP '127.0.0.1' is not whitelisted.
```

> **Tip**: By default the whitelist is **enabled**. Add `127.0.0.1` to the whitelist (via gRPC Settings) before testing locally with grpcurl.

---

## NuGet Packages

| Package | Version | Purpose |
|---------|---------|---------|
| `Grpc.Core` | 2.46.6 | gRPC server/client for .NET Framework |
| `Grpc.Core.Api` | 2.46.6 | gRPC abstractions |
| `Google.Protobuf` | 3.21.12 | Protobuf serialization |
| `Newtonsoft.Json` | 13.0.3 | JSON config persistence |
---

# ListHandleSample

Same IP-whitelist gRPC WinForms server as `GrpcWhitelistSample`, but using **proto-mode**: the `Grpc.Tools` NuGet package drives `protoc` automatically at build time to generate `Hello.cs` and `HelloGrpc.cs` from `Proto/hello.proto`. No hand-written generated stubs — the `.proto` file is the single source of truth.

---

## Prerequisites (ListHandleSample)

- **Windows** (WinForms)
- **.NET Framework 4.5** or later runtime
- **MSBuild** (Visual Studio 2013+ or [Build Tools](https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2022))
- **NuGet CLI** — place `nuget.exe` in `ListHandleSample\` or on `PATH`

---

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

> **Key difference from GrpcWhitelistSample**: there is no `Generated/` folder.
> `Grpc.Tools` runs `protoc` + `grpc_csharp_plugin` at build time; the generated `.cs`
> files land in `obj\` and are automatically included in compilation.

---

## Build (ListHandleSample)

```batch
cd ListHandleSample
build.bat
```

Steps performed by `build.bat`:
1. **NuGet restore** — downloads `Grpc.Core`, `Google.Protobuf`, `Grpc.Tools`, `Newtonsoft.Json`
2. **MSBuild** — `Grpc.Tools.targets` triggers `protoc` to generate C# from `Proto\hello.proto`, then compiles the project
3. **Copy native DLLs** — copies `grpc_csharp_ext.x64.dll` etc. to `bin\Release\`

---

## How proto-mode works

`Grpc.Tools` integrates into MSBuild via two imported targets files:

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

To update the service contract, simply edit `Proto\hello.proto` and rebuild — no manual code changes needed.

---

## NuGet Packages (ListHandleSample)

| Package | Version | Purpose |
|---------|---------|---------|
| `Grpc.Core` | 2.46.6 | gRPC server/client runtime for .NET Framework |
| `Grpc.Core.Api` | 2.46.6 | gRPC abstractions |
| `Grpc.Tools` | 2.46.6 | `protoc` + `grpc_csharp_plugin` — **build-time only** |
| `Google.Protobuf` | 3.21.12 | Protobuf serialization |
| `Newtonsoft.Json` | 13.0.3 | JSON config persistence |
