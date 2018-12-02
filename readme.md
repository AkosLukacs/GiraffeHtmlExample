
# Set up the project

## Create a new F# console project

> dotnet new console -lang F# -o src/GiraffeHtmlService

## Add paket
Download the latest [paket bootstrapper](https://github.com/fsprojects/Paket/releases/latest) and save it to `.paket` folder. Follow the [instructions](https://fsprojects.github.io/Paket/paket-and-dotnet-cli.html) here about setting up Paket.

## Add GiraffeViewEngine

Add GiraffeViewEngine to your `paket.dependecies` file
```
group Main
    storage none
    source https://api.nuget.org/v3/index.json
    nuget FSharp.Core
    github giraffe-fsharp/Giraffe src/Giraffe/GiraffeViewEngine.fs
``` 

Create `src/GiraffeHtmlService/paket.references` and add this:
```
group Main
    FSharp.Core
    File: GiraffeViewEngine.fs
```    

At this point, just check that everything is ok:

Run `Paket: Install` in VS code

> dotnet run --project .\src\GiraffeHtmlService\

And you should see `Hello World from F#!` in the console!

# Creating your HTML template

Add a new file called `HtmlTemplates.fs` in `src/GiraffeHtmlService`:
```fsharp
module HtmlTemplates

open Giraffe.GiraffeViewEngine

let myTemplate name = 
    html [] [
        body [] [
            div [] [
                str (sprintf "Hello %s!" name)
            ]
        ]
    ]
    |> renderHtmlDocument
```

Add the file to your fsproj above your Program.fs:
```xml
    <Compile Include="HtmlTemplates.fs" />
    <Compile Include="Program.fs" />
```


And call it from program.fs:
```fsharp
[<EntryPoint>]
let main argv =
    
    let renderedHtml = HtmlTemplates.myTemplate "World"
    printfn "The rendered html document: \n\n%s\n" renderedHtml
    
    0 // return an integer exit code
```    

And now you should see the HTML output in the console.