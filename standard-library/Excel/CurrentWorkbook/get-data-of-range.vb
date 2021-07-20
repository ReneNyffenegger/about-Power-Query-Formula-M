option explicit

sub main() ' {

    activeSheet.name = "worksheet one"

    createRange activeSheet

    dim formula_M as string

    formula_M = formula_M & "let"
    formula_M = formula_M & "   range = Excel.CurrentWorkbook(){ [ Name=""namedRange"" ] }[ Content ],"
    formula_M = formula_M & "   wHdr  = Table.PromoteHeaders(range),"
    formula_M = formula_M & "   typed = Table.TransformColumnTypes(wHdr,{ {""dat"", type date    } }) "  ' This step seems necessary to recognize dat as a date
    formula_M = formula_M & "in typed"

    activeWorkbook.queries.add _
       name    := "qry",       _
       formula :=  formula_M

    dim connectionString as string
    connectionString = "OLEDB;"                             & _
                       "Provider=Microsoft.Mashup.OleDb.1;" & _
                       "Data Source=$Workbook$;"            & _
                       "Location=qry;"                      & _
                       "Extended Properties="""""


    dim destTable as listObject
    set destTable = activeSheet.listObjects.add( _
       sourceType  := xlSrcExternal            , _
       source      := connectionString         , _
       destination := cells(1,5))

    destTable.name = "listObjectOfResult"

    with destTable.queryTable ' {

        .commandType              = xlCmdSql
        .commandText              = array("select * from [qry]")
        .backgroundQuery          = false

        .refresh backgroundQuery := false

    end With ' }

    activeSheet.usedRange.columns.autoFit
    cells(6,9).select

end sub ' }

sub createRange(sht as worksheet) ' {

    with sht ' {

        .range(.cells(1,1), .cells(1,3)) = array("txt", "num", "dat")
        .range(.cells(2,1), .cells(2,3)) = array("foo",  42, #2018-12-25#)
        .range(.cells(3,1), .cells(3,3)) = array("bar",  99, #2019-05-18#)
        .range(.cells(4,1), .cells(4,3)) = array("baz",  71, #2020-02-13#)

        .range(.cells(1,1), .cells(4,3)).name = "namedRange"

    end with ' }

end sub ' }
