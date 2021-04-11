option explicit

sub helloWorld() ' {

   activeWorkbook.queries.add _
     name    := "qry",        _
     formula := """Hello world"""

   dim destTable as listObject

   dim src as string
   src = "OLEDB;"                             & _
         "Provider=Microsoft.Mashup.OleDb.1;" & _
         "Data Source=$Workbook$;"            & _
         "Location=qry"

   set destTable = activeSheet.listObjects.add( _
       sourceType  := 0           , _
       source      := src         , _
       destination := cells(2, 2) )

   with destTable.queryTable

       .commandType              =  xlCmdSql
       .commandText              =  array("select * from [qry]")

       .rowNumbers               =  false

       .backgroundQuery          =  true
       .refreshStyle             =  xlInsertDeleteCells

       .saveData                 =  false
       .refreshOnFileOpen        =  true

       .adjustColumnWidth        =  true
       .refreshPeriod            =  0
       .preserveColumnInfo       =  true

       .listObject.DisplayName   = "destinationTable"

       .refresh BackgroundQuery :=  false

    end with

end sub ' }
