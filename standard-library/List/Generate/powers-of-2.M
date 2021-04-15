List.Generate(
   ()    =>   1,  //  initial value
   each _ < 100,  //  condition to go on
   each _*2       //  Next value, takes previous value as function-input
)
