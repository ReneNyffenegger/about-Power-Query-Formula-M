let
   tbl = #table (
    {"col_1", "col_2", "col_3"  },
    {
    {"foo"  ,     42 , "one"    },
    {"bar"  ,     99 , "two"    },
    {"baz"  ,      0 , "three"  }})
in
   tbl{ [col_3="two"] }
