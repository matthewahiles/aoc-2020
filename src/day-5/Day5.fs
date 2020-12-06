module AOC.Day5

open System.IO
open System.Text

let translateBinary b =
    match b with
    | 'F'
    | 'L' -> '0'
    | _ -> '1'

let buildBinaryRepresentation =
    List.fold (fun s v -> (translateBinary v) :: s)

let joinList l =
    List.fold (fun (sb: StringBuilder) (v: char) -> sb.Append(v)) (StringBuilder()) l
    |> fun x -> x.ToString()

let parseSeatFragment root =
    buildBinaryRepresentation root
    >> List.rev
    >> joinList
    >> int

let rowRoot = [ '0'; 'b'; '0' ]
let columnRoot = [ '0'; '0'; '0'; '0'; '0'; 'b'; '0' ]

let parseSeat v =
    let row =
        parseSeatFragment rowRoot (List.take 7 v)

    let column =
        parseSeatFragment columnRoot (List.skip 7 v)

    row * 8 + column

let data = File.ReadLines("./src/day-5/input.txt")

let test () =
    let solution =
        Seq.map (Seq.toList >> parseSeat) data
        |> Seq.sort
        |> Seq.pairwise
        |> Seq.find (fun x ->
            let (a, b) = x
            a + 2 = b)
        ||> fun x _ -> x + 1

    printfn "%A" solution
