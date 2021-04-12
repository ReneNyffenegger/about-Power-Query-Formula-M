let
   get_fld = each [txt],
   REC     = [
                num =  42,
                txt = "Hello world"
             ]
in
   get_fld(REC)
