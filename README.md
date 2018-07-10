# mPqSave

This program will allow you to read and write Pokémon Quest save files.

Also support mobile version Pokémon Quest's save.

Pokémon Quest's save file is a single 512 KB file named `user`.

Thanks: [Thealexbarney](https://github.com/Thealexbarney/PqSave)

### Usage
````
Usage: mpqsave [[k key] | [p keyfile]] modeinput output [script1 (In script mode only)] [script2]...
  modes:
    k Key (string, mobile version need)
    p Key file (file, mobile version need)
    d Decrypt save (input: encrypted save,output: decrypted save)
    e Encrypt save (input: decrypted save,output: encrypted save)
    x Export save to JSON (input: encryptedsave, output: json)
    i Import save from JSON (input: json,output: encrypted save)
    s Script - Run scripts on an encrypted save(input: encrypted save, output: modified encrypted save)
  option k and p only need one
````

## User Scripts
User-provided C# scripts can be run to modify the save data.

Two examples have been provided:
- [Modify ticket count](mPqSave/Scripts/tickets.csx)
- [Set item counts to 999](mPqSave/Scripts/items.csx)

## Running on Linux or macOS

.NET Core can run mPqSave on Linux or macOS.
Make sure .NET Core is installed, open a terminal in the directory containing mPqSave and run the program with `dotnet mPqSave.dll`

## Building

#### Using Visual Studio 2017
1. Open `mPqSave.sln` in Visual Studio
2. Run `Build Solution`

If you do not have .NET Core 2.0 or higher installed, Visual Studio will give an error saying that the `netcoreapp2.0` build failed.
The .NET Framework 4.6 build should still succeed if this happens.

#### Using the .NET Core SDK

1. Install the [.NET Core SDK](https://www.microsoft.com/net/download/windows)
2. Open a command prompt in the directory containing `mPqSave.sln`
3. Run `dotnet build -f netcoreapp2.0`

If you have the .NET Framework 4.6 Targeting Pack installed the .NET Core SDK will also build the program for .NET Framework 4.6.

