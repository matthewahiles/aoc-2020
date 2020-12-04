module AOC.Day4

open System.IO
open System.Text.RegularExpressions

let isValid (p: string) =
    let hasCid = p.Contains "cid"
    let pieces = p.Split [| ' '; '\n' |] |> Seq.length
    match (hasCid, pieces) with
    | (true, 8) -> true
    | (false, 7) -> true
    | _ -> false

let validateByr v = v >= 1920 && v <= 2002
let validateIyr v = v >= 2010 && v <= 2020
let validateEyr v = v >= 2020 && v <= 2030

type Height =
    | Inches of int
    | Centimeters of int
    | None

let parseHgt (n: string) =
    let isInches = n.Contains "in"
    let isCentimeters = n.Contains "cm"
    let num = n.Substring(0, n.Length - 2)
    match (isInches, isCentimeters) with
    | (true, _) -> Inches(int num)
    | (_, true) -> Centimeters(int num)
    | _ -> None


let validateHgt v =
    match parseHgt v with
    | Inches v' -> v' >= 59 && v' <= 76
    | Centimeters v' -> v' >= 150 && v' <= 193
    | None -> false

let validateHcl v = Regex.IsMatch(v, @"^#[a-f0-9]{6}$")

let validateEcl v =
    match v with
    | "amb"
    | "blu"
    | "brn"
    | "gry"
    | "grn"
    | "hzl"
    | "oth" -> true
    | _ -> false

let validatePid v = Regex.IsMatch(v, @"^\d{9}$")

let validateField (f: string) =
    let p = f.Split [| ':' |]
    match p.[0] with
    | "byr" -> validateByr (int p.[1])
    | "iyr" -> validateIyr (int p.[1])
    | "eyr" -> validateEyr (int p.[1])
    | "hgt" -> validateHgt p.[1]
    | "hcl" -> validateHcl p.[1]
    | "ecl" -> validateEcl p.[1]
    | "pid" -> validatePid p.[1]
    | _ -> false

let validatePassportFields (p: string) =
    let pieces = p.Split [| ' '; '\n' |]

    let totalValid =
        Array.filter validateField pieces |> Array.length

    totalValid = 7

let data =
    File.ReadAllText("./src/day-4/input.txt")

let test () =
    let d = data.Split "\n\n"

    let solution =
        Array.filter isValid d
        |> Array.filter validatePassportFields
        |> Array.length

    printfn "%A" solution
