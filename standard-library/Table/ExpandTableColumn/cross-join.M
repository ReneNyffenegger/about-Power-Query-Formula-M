let
    tab_A = #table (
       { "col_1", "col_2"},
       {
       {      1 , "one"  },
       {      2 , "two"  },
       {      3 , "three"}}
    ),
    tab_B = #table (
       { "col_3"},
       {
       {     "A"},
       {     "B"}}
    ),
    tab_joined = Table.AddColumn(
       tab_A,
      "col_B",     // The name of the added column
       each tab_B  // The value of each record in the added column is the entire table B
    )
in
    Table.ExpandTableColumn(
        tab_joined,
       "col_B",
      {"col_3"}
    )
