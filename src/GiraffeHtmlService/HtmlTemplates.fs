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