#r "nuget: BigRational, 1.0.0.7"

open System.Numerics

// Strict evaluation
let a = BigRational 0.1
let b = BigRational 0.2
let c = a + b


printfn "%A" a     // 0.10000000000000000555111512312578…
printfn "%A" b     // 0.20000000000000001110223024625156…
printfn "%A" (a+b) // 0.30000000000000001665334536937734…
printfn "%A" c     // 0.30000000000000001665334536937734…
printfn "%A" (c = a+b)              // true
printfn "%A" (c =  BigRational 0.3) // false
