[<EntryPoint>]
let main argv =
    
    let renderedHtml = HtmlTemplates.myTemplate "World"
    printfn "The rendered html document: \n\n%s\n" renderedHtml
    
    0 // return an integer exit code
