namespace fsharpTopShelf

module Program =
    open Topshelf

    open fsharpTopShelf.Runners

    [<EntryPoint>]
    let main argv = 
        HostFactory.Run(fun host ->
        
            host.Service<TimerOutput>(Interop.init) |> ignore

            host.RunAsLocalSystem() |> ignore

            host.SetDescription "Example Fsharp Topshelf Host"
            host.SetDisplayName "fsharptest"
            host.SetServiceName "fsharptest"
        ) |> ignore
        0