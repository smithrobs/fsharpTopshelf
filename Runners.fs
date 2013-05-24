namespace fsharpTopShelf

module Runners =
    open System
    open System.Timers
    open Topshelf

    type TimerOutput(timer : Timer) =
        new () = 
            let timer = new Timer()
            timer.Interval <- 1000.0
            timer.AutoReset <- true
            timer.Elapsed.Add(fun args ->
                let timeNow = DateTime.Now.ToString()
                printfn "It is %s and all is well" timeNow)
            TimerOutput(timer)
        member this.Start =
            printfn "Start"
            timer.Start()
        member this.Stop =
            printfn "Stop"
            timer.Stop()

    type Interop =
        static member init(svc : ServiceConfigurators.ServiceConfigurator<TimerOutput>) =
            svc.ConstructUsing(fun (name: string) -> new TimerOutput()) |> ignore
            svc.WhenStarted(fun (tc : TimerOutput) -> tc.Start) |> ignore
            svc.WhenStopped(fun (tc : TimerOutput) -> tc.Stop) |> ignore