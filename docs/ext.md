# BrainFkPlus.Extension
This extension adds 5 new operators
## Math
Now, there's more than only `+` and `-`. We now have `*` (multiplication) and `/` (division)! 
As BF doesn't have cool syntax like C# or C/C++, `*` or `/` does operations using formula: `current = current * next` or `current = current / next`
```
' Set ADR0 to 2
++
' Set ADR1 to 4
>++ ++

' Multiply 2 by 4 (ADR0 * ADR1)
<*
' ADR0 now have 8

' Divide 8 by 4 (ADR0 / ADR1)
/
' ADR0 now have 2
```
## I/O
What could be already easier than `.` and `,`? <br/>
Extension also adds `_` (print value), `;` (new line/endl), `?` (print current index). Purpose for these operators are debugging
```
' Add 4 to ADR0
++++
' Print it and place \n
_; ' Output: 4
?; ' Output: 0
```