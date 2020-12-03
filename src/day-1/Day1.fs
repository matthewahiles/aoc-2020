module AOC.Day1

open System.IO
open FSharp.Collections

let rec comb n l =
    match n, l with
    | 0, _ -> [ [] ]
    | _, [] -> []
    | k, (x :: xs) -> List.map ((@) [ x ]) (comb (k - 1) xs) @ comb k xs

let solve l n v =
    comb n l
    |> List.find (fun x -> List.sum x = v)
    |> Seq.fold (*) 1

let data = File.ReadLines("./src/day-1/input.txt")

let test () =
    printfn "%i" (solve (Seq.toList data |> List.map int) 3 2020)