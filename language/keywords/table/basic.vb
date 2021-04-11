option explicit

sub main() ' {

   activeWorkbook.queries.add _
     name     := "qry"                                    , _
     formula  := readFile(activeWorkbook.path & "\table.M")

   dim src as string
   src = "OLEDB;"                             & _
         "Provider=Microsoft.Mashup.OleDb.1;" & _
         "Data Source=$Workbook$;"            & _
         "Location=qry"

   dim  destTable as listObject
   set  destTable = activeSheet.listObjects.add( _
        sourceType  := 0           , _
        source      := src         , _
        destination := cells(2, 2) )

   with destTable.queryTable

       .commandType              =  xlCmdSql
       .commandText              =  array("select * from [qry]")
       .refresh backgroundQuery :=  false

    end with

end sub ' }

function readFile(fileName as string) as string ' {

   dim f as integer : f = freeFile()

   open fileName for input as #f
   readFile = input(lof(f), #f)

   close f

end function ' }
