let
   tab_A  = #table (
     {  "id", "col_1", "col_2"},
     {
     {    1 , "one"  , "foo"  },
     {    2 , "two"  , "bar"  },
     {    3 , "three", "baz"  }}
   ),
   tab_B  = #table (
     {"id_A", "col_3", "col_4"},
     {
     {     1, "ab"   , "c"    },
     {     2, "m"    , "no"   },
     {     2, "m"    , "no"   },
     {     1, "f"    , "gh"   },
     {     3, "uv"   , "wx"   },
     {     3, "s"    , "t"    },
     {     2, "p"    , "qr"   },
     {     1, "d"    , "e"    },
     {     3, "y"    , "z"    },
     {     1, "ij"   , "kl"   }}
   )
in
   Table.Join(
      tab_A, "id",
      tab_B, "id_A"
   )
