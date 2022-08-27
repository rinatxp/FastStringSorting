## Almost 100 times faster string comparer

### Benchmark's result:
|  Method |       Mean | Ratio |
|-------- |-----------:|------:|
| Method1 | 317.090 us |  1.00 |
| Method2 |   4.250 us |  0.01 |

Fast comparer doesn't use any functions or heap allocations.

### The string could be like this:

[some letters] + [double] + [some letters]

or

[some letters] + [double] + ['-' , ':' or ';'] + [double] + [some letters]

e.g. "Bn4.03Ha", "abb10.14-4aa"
