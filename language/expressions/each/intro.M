let
   incr     = each   _ + 1,
   incr_    = (_) => _ + 1,  // same thing as above
   get_fld  = each   _[FLD],
   get_fld_ = (_) => _[FLD], // same thing as above
   REC      = [
     ABC = "abcdef",
     FLD =  123456
   ]
in
  {
     incr (get_fld (REC)),
     incr_(get_fld_(REC))
  }
