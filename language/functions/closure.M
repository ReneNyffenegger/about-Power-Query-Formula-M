let
   twice = (n)        // twice is a function that
   => ()              // returns a function
   => 2*n,            // that returns twice the amount of
                      // the value with which twice was invoked
   eight = twice(4),
   six   = twice(3)
in
   eight() + six()
