let
   one   = let
              a = -2,
              b =  3
           in
              a + b,

   two   = let
              c =  5,
              d =  3
           in
              c - d,

   three = let
              e = 1
           in
              e + two

in
   one + two + three
