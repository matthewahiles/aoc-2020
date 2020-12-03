module AOC.Day3

open System.IO

let rec solve right down step (total: uint64) (arr: char [,]) =
    if step * down >= 323 then
        total
    else
        match arr.[step * down, ((step * right) % 31)] with
        | '.' -> solve right down (step + 1) total arr
        | _ -> solve right down (step + 1) (total + 1UL) arr

let data = File.ReadLines("./src/day-3/input.txt")

let test () =
    let area = array2D data // [y, x]
    let solution1 = solve 3 1 0 0UL area
    let solution2 = solve 1 1 0 0UL area
    let solution3 = solve 5 1 0 0UL area
    let solution4 = solve 7 1 0 0UL area
    let solution5 = solve 1 2 0 0UL area
    printfn
        "%i"
        (solution1
         * solution2
         * solution3
         * solution4
         * solution5)
