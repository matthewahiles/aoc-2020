module Main =
  open System

let translateVert b =
  match b with
  | 'F' -> '0'
  | _ -> '1';;

open AOC.Day5
[<EntryPoint>]
let main argv =
  test() |> ignore
  0 // return an integer exit code