# Implementation of StrawberryShake 13 for Unity 2022.1
## Setup
- The project includes the package StrawberryShake.Server and all dependencies.
  - All dependency packages of StrawberryShake.Server (e.g.: strawberryshake.core, ...) are where possible as NET.Standart 2.1 DLL and otherwise as NET.Standart 2.0 DLL.
  - The link.xml file makes sure that none of the packages are striped by Unity [Unity - Manual: Managed code stripping](https://docs.unity3d.com/Manual/ManagedCodeStripping.html).
- The GraphQL backend URL and the auto generated file (ConferenceClient.Client.cs) origin from an [external console project](https://github.com/firedrill-gmbh/StrawberryShake_13_Console).

## Main Issues
- The StrawberryShake.Server package itself does not work as some DLLs can't be loaded. It also contained many duplicated DLLs, which is not supported by Unity. Because of this all folders in strawberryshake.server\13.0.0-preview.80\tools\ except de\ where removed and some .DLL in strawberryshake.server\13.0.0-preview.80\tools\ where set to "excluded from all platforms".
- After running 'dotnet new tool-manifest', Unity will crach when you hit play. This might be a bug in Unity because it was not possible to revert this by just removing the tool-manifest. I had to remove the temporary folders to get rid of the chrashes.

## Limitation of Unity
Some limitations of Unity which mith be problematic to get StrawberryShake run directly in Unity
- Unity generates its .csproj files.
- Unity supports only max C# 9.0 https://docs.unity3d.com/2022.1/Documentation/Manual/CSharpCompiler.html.
- The packages were copied by hand from my local nuget package cache as the custom unity tools for getting nuget packages all hat their issues. Future version of Unity will support nuget but this is not coming some time in 2023/2024 [Unity and .NET, what’s next?](https://blog.unity.com/technology/unity-and-net-whats-next).
