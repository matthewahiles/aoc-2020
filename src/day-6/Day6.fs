module AOC.Day6

open System.IO

let solve1 (v: string) =
    Array.sumBy
        (Seq.filter (fun v -> v <> '\n')
         >> Seq.distinct
         >> Seq.length)
        (v.Split "\n\n")

let solve2 (v: string) =
    v.Split "\n\n"
    |> Array.sumBy (fun g ->
        g.Split [| '\n' |]
        |> Array.map Set.ofSeq
        |> Array.fold Set.intersect (set (seq { 'a' .. 'z' }))
        |> fun (x: Set<char>) -> x.Count)

let data =
    File.ReadAllText("./src/day-6/input.txt")

let test () =
    let solution = solve2 data
    printfn "%A" solution
