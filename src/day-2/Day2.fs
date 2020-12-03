module AOC.Day2

open System.IO

type PwCheck =
    { Lower: int
      Higher: int
      Letter: char
      Password: string }

let formatData (s: string) =
    let p = s.Split [| ' ' |]
    let lowerUpper = p.[0].Split [| '-' |]
    let letter = p.[1].[0]
    let pw = p.[2]
    { Lower = int lowerUpper.[0]
      Higher = int lowerUpper.[1]
      Letter = letter
      Password = pw }

let checkPw p =
    let letterCount =
        Seq.filter ((=) p.Letter) p.Password |> Seq.length

    letterCount <= p.Higher && letterCount >= p.Lower

let checkPw2 p =
    p.Password.[p.Lower - 1] = p.Letter
    <> (p.Password.[p.Higher - 1] = p.Letter)



let data = File.ReadLines("./src/day-2/input.txt")

let test () =
    let formatted = Seq.map formatData data

    let solution =
        (Seq.map checkPw2 formatted
         |> Seq.filter id
         |> Seq.length)

    printfn "%A" solution

