let
   fibonacci = (n) =>
      if      n = 0 then 0
      else if n = 1 then 1
      else @fibonacci(n-2) + @fibonacci(n-1)
in
  [
    #"fib( 3)" = fibonacci( 3),
    #"fib( 9)" = fibonacci( 9),
    #"fib(11)" = fibonacci(11),
    #"fib( 4)" = fibonacci( 4)
  ]
