#r "nuget: MathNet.Numerics, 6.0.0-beta1"
#r "nuget: MathNet.Numerics.FSharp, 5.0.0"

open MathNet.Numerics

// Lazy evaluation
let a = 1N / 10N
let b = 2N / 10N
let c = a + b


printfn "%A" a     // 1/10N
printfn "%A" b     // 1/5N
printfn "%A" (a+b) // 3/10N
printfn "%A" c     // 3/10N
printfn "%A" (c = a+b)                       // true
printfn "%A" (BigRational.ToDouble c =  0.3) // true
