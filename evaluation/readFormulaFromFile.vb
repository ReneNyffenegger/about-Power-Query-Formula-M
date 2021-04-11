option explicit

sub evaluateFormulaMfromFile(fileName as string) ' {


   dim qry as WorkbookQuery
   set qry = activeWorkbook.queries.add( _
        name     := "qry_" & activeWorkbook.queries.count, _
        formula  := readFile(fileName))

   dim src as string
   src = "OLEDB;"                             & _
         "Provider=Microsoft.Mashup.OleDb.1;" & _
         "Data Source=$Workbook$;"            & _
         "Location=qry"

   dim  sh as worksheet
   set  sh = activeWorkbook.sheets.add

   dim  destTable as listObject
   set  destTable = sh.listObjects.add( _
        sourceType  := 0           , _
        source      := src         , _
        destination := cells(2, 2) )

   with destTable.queryTable

       .commandType              =  xlCmdSql
       .commandText              =  array("select * from [" & qry.name & "]")
       .refresh backgroundQuery :=  false

   end with

end sub ' }

function readFile(fileName as string) as string ' {

   dim f as integer : f = freeFile()

   open fileName for input as #f
   readFile = input(lof(f), #f)

   close f

end function ' }
