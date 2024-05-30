type Fraction =
    { Numerator: int64
      Denominator: int64 }

let rec gcd a b =
    match b = 0L with
    | true -> a
    | false -> gcd b (a % b)

let createFraction : int64 -> int64 -> Fraction =
    fun n d ->
        let gcdVal = gcd n d
        { Numerator = n / gcdVal
          Denominator = d / gcdVal }

let valueFraction : Fraction -> float =
    fun f ->
        float f.Numerator / float f.Denominator

let add : Fraction -> Fraction -> Fraction =
    fun a b ->
        createFraction 
            (a.Numerator * b.Denominator + b.Numerator * a.Denominator) 
            (a.Denominator * b.Denominator)
let mult : Fraction -> Fraction -> Fraction =
    fun a b ->
        createFraction 
            (a.Numerator * b.Numerator) 
            (a.Denominator * b.Denominator)

let equal : Fraction -> Fraction -> bool =
    fun a b ->
        a.Numerator * b.Denominator = a.Denominator * b.Numerator

let negative : Fraction -> Fraction =
    fun f ->
        createFraction (-f.Numerator) f.Denominator

let (+) = add
let (==) = equal
let (-) = fun a b -> add a (negative b)
let (*) = mult
let (/) = fun a b -> mult a (createFraction b.Denominator b.Numerator)


// main
let f1_10 = createFraction 1L 10L
let f2_10 = createFraction 2L 10L
let f3_10 = createFraction 3L 10L

printfn $"{add f1_10 f2_10}"
printfn $"{f3_10}"

printfn $"{equal f3_10 (add f1_10 f2_10)}"         // True
printfn $"{0.3 = valueFraction (add f1_10 f2_10)}" // True

printfn "%.30f" (valueFraction (add f1_10 f2_10)) // 0.299999999999999988897769753748
printfn "%.30f" (valueFraction f3_10)             // 0.299999999999999988897769753748
printfn "%.30f" 0.3                               // 0.299999999999999988897769753748


printfn $"{f3_10 == f1_10 + f2_10}"                // True
printfn $"{f2_10 == f3_10 - f1_10}"                // True
printfn $"{0.06 = valueFraction (f2_10 * f3_10)}"  // True
printfn $"{0.5 = valueFraction (f1_10 / f2_10)}"   // True
