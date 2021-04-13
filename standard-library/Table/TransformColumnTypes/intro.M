let
    Source = #table(
    {   "A",               "B" ,    "C",               "D"},
     {
      {  1 , #date(2021,12,15) , 43210 , #date(2020, 4,21)},
      {  2 , #date(2019, 8,28) , 40100 , #date(2018, 5, 2)}
     }
    ),
    typedSource = Table.TransformColumnTypes(Source,
      {
        {"A", Int64.Type },
        {"B", type date  },
        {"C", type date  }
      })
in
    typedSource
