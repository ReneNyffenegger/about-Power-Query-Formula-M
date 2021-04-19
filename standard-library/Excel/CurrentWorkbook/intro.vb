option explicit

sub main() ' {

    dim sh as workSheet : set sh = activeSheet

    createNamedRange sh

    addFormula cells(2, 6), "Excel.CurrentWorkbook()"
    addFormula cells(2, 9), "Excel.CurrentWorkbook() { [Name = ""namedRange""] }"
    addFormula cells(2,12), "Excel.CurrentWorkbook() { [Name = ""namedRange""] } [Content]"

    sh.usedRange.columns.autofit

end sub ' }

sub createNamedRange(sh as worksheet) ' {

    with sh

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

sub addFormula(dest as range, formula_M as string)  ' {

    dim qry as workbookQuery
    set qry = activeWorkbook.queries.add                ( _
       name    := "qry_" & activeWorkbook.queries.count , _
       formula :=  formula_M                            )

    dim connectionString as string
    connectionString = "OLEDB;"                             & _
                       "Provider=Microsoft.Mashup.OleDb.1;" & _
                       "Data Source=$Workbook$;"            & _
                       "Location=" & qry.name


    dim destTable as listObject
    set destTable = activeSheet.listObjects.add( _
       sourceType  := xlSrcExternal            , _
       source      := connectionString         , _
       destination := dest )

    destTable.name = qry.name

    with destTable.queryTable ' {

        .commandType              = xlCmdSql
        .commandText              = array("select * from [" & qry.name & "]")
        .refresh backgroundQuery := false

    end With ' }

end sub ' }
