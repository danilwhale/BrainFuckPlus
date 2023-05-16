# Basics
Brainfuck is defined as 'BF' and Brainfuck+ as 'BF+' to read easier
## Commenting (BF+ ONLY)
Comments are defined by `'`, there's no multiline comments, sadly.
```
' This is a comment!
' And it will explain what code does
```
## Calculations
You can make calculations in BF by using `+` and `-`. `+` increments current cell (address) by 1, and  `-` decrements current cell by 1.
```
' Add 5 to ADR0
+++ ++
' Substracts 1 from ADR0
-
' Add 2 to ADR0
++

' ADR0 now have 6
```
## Indexes
In most of time, you need to change current cell index, for example for loops. `<` moves index back (same as `index - 1`) and `>` moves index forwards (`index + 1`)
```
' Add 5 to ADR0
+++ ++
' Substracts 1 from ADR0
-
' Add 2 to ADR0
++

' ADR0 now have 6

' Go to ADR1 and set it to 4
> ++++
' Go back to ADR0
<
```
## Loops
To simplify code, you can use loops. For example, loops are used in `helloworld.bfp` example. Loop will start if current cell value not zero, goes in. Loop will end if current cell value IS zero.
```
' Create ADR0 and set it's value to 4
++ ++

' Loop will iterate 4 times, and ADR1 will have value of 32 (4 iterations * 8 per iteration)
[
    ' Add 8 to ADR1
    > ++++ ++++
    ' Substract 1 from ADR0
    < -
]
```
## I/O
(sure I/O will happen only in console, not in file lol)
You can print current character to console by `.` (ex. 72 = H). Getting input from user (1 character-only) by `,` .
```
' Set 4 to ADR0, so we'll have 4 iterations of loop
++++

[
    ' Add 8 to ADR1
    > ++++ ++++
    ' Subtract 1 from ADR0
    < -
]

' Print '!' to console (because '!' have value of 32 in ASCII table, and we done 4 iterations, each one added 8)
>.
```