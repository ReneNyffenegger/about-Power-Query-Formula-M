let
    L      = {
               [ a = 1, b = 7, c = "A" ],
               [ a = 3, b = 6, c = "B" ],
               [ a = 9, b = 7, c = "C" ],
               [ a = 8, b = 2, c = "D" ],
               [ a = 2, b = 4, c = "E" ],
               [ a = 4, b = 5, c = "F" ]
             },

    a_gt_b = List.Select(
               L,
               each [a] > [b]
             )
in
    Table.FromList(
        a_gt_b,
        Record.FieldValues,          // Apply this function on each element in a_gt_b: it turns the record into a list
      { "col a", "col b", "col c" }  // Name the columns
   )
