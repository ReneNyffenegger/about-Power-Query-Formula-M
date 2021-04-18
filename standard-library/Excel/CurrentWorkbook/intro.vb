option explicit

sub main() ' {

    dim sh as workSheet : set sh = activeSheet

    createRange sh

    dim formula_M as string

    formula_M = formula_M & "Excel.CurrentWorkbook()"

    activeWorkbook.queries.add _
       name    := "query",     _
       formula :=  formula_M

    dim connectionString as string
    connectionString = "OLEDB;"                             & _
                       "Provider=Microsoft.Mashup.OleDb.1;" & _
                       "Data Source=$Workbook$;"            & _
                       "Location=query;"


    dim destTable as listObject
    set destTable = activeSheet.listObjects.add( _
       sourceType  := xlSrcExternal            , _
       source      := connectionString         , _
       destination := cells(2, 6))

    destTable.name = "queryResult"

    with destTable.queryTable ' {

        .commandType              = xlCmdSql
        .commandText              = array("select * from [query]")
        .refresh backgroundQuery := false

    end With ' }

end sub ' }

sub createRange(sht as worksheet) ' {

    with sht

        .range(.cells(2,2), .cells(2,4)) = array("txt", "num", "dat")
        .range(.cells(3,2), .cells(3,4)) = array("foo",  42, #2018-12-25#)
        .range(.cells(4,2), .cells(4,4)) = array("bar",  99, #2019-05-18#)
        .range(.cells(5,2), .cells(5,4)) = array("baz",  71, #2020-02-13#)

        with .range(.cells(2,2), .cells(5,4))

             .name           = "namedRange"
             .interior.color =  13431551

        end with


    end with

end sub ' }
