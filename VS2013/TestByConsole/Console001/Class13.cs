using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// Base64字符串转成二进制
  /// </summary>
  class C13
  {
    public static void Execute()
    {
      string Base64String = "eJy1WFlvIlcX%2fC9%2btTXcfRkpD3fFGC%2bsbTOfItRAA21Ds2NDlP%2beg%2bUZzSiR8JeAHxBGTVM6XVWn6v5xkWTLVT4rLr5esC%2f4C7q4urjN%2b1mxyuCTu5de9jJoP71OXrJ99cktnoo7T9ql1aYod2zx8LDchqI25vXJ5XLHK8lDY7%2bojGasnNy09reymAxLw8dYTMr8xqJaxaDtolcZ%2bsqseKlUitUr3y5f8HRUn3RmpaENlTw8kN3b7SttV4eT8rCT1p%2facrEdzhvXvfalu7XTzSuJHabzJNM3ixq%2fv7md7xohu9sne%2f923Sgt1ajS8Y83vT5uWUXr2D7h%2b04vu1WuIZjzSdHc2oQv0zrphPneNcu0R0tj8xyIXOTfyjbJlCgNF41VUtmWWE8rU%2b636KUej5NO77G8KZGRLDVe6smofr1utDf4gd%2fv9qHRet5PvnU6d3Jut%2bOcPPYrk6fxXTYJKiWN1mW9k78u95vGIGy02FyLb%2fVq%2feEWPVQTtdW7UaNSokmZVndPfUTmetFODX%2fmzyPaekumu2RT3cVFercc9Gezu9dv2cszv42o2YdLWrWRy0MyTvtxW6qvFvV%2bWBBbK57vh229e3StjFwm6015%2f1jlgcbVS%2b8%2b2dcbq0Vp92R6ldb9QAWUr1%2bW1ca%2bR6%2fF5vLOYp10WpXpfjzL72%2fe8kEoXTdW02nKVuOcPm3vqpWemU43k%2frwabUczbadbJ202f1OJbN5OkfrS1ydN55vp7vn8e75tdy7aZBmmc%2fDft5pJbr%2b229AMjebztNiV%2fFAs96gSIFvVxcxn2Sri6%2f%2f%2b%2bP93X06PZDQFOlkt8%2bau6L%2fZZ%2fP4bLwlvUrxSB7u%2fiKri7uBtzNBocrCQqBCeOp9EyEyBDzQhJBlA%2fUBIGNdl7xGOEWlVVznvXzdFJL1%2f3x%2b33iJB29v2lk6WSdT7MfH5SXs828tZvDb6A%2fr34Bdz9bTtNJDvA2vVV%2fmc%2fXoKUjMENAljEjFZHGS%2buMZMgaqgnmOBKGlfJMUxxOCLPdZBh3iUJId9vzQbrOPqZa2%2fQm%2bWqc5Nnr6ghsE7jhJjIVGfZYW2WjOfxZjIL11HBAjhE95XR%2fhh3zt88zwbngOKXOG%2bRICJEKr33EwlIWUVTCK9ACMe7EWMl%2fHDGxEltvpBCee40iR1pZjagzmiEcKacqOuvYWWG7dF3xbjbZTIujeDEl0RqMPDbRBiCv5wioHZTliiDPJUgSqVMzmRw4Qdn%2fyQkKsgK2WoVZQMF4B7LzAWmrHdbaRBMJEFyekhMwynQyGx0B5j2LwhEJdmC95UE5T7ENXoZouNKcOIQ54eqEwL5P7fOmZUE00jElRDSISEqDJT5IrbjQImBBTUSMGnFCkDEvRtlyvsyL9apr01V%2b7AkbbIVCRgcjpbTMAC1hgtZ4LTAjgfNgKLPylIP8GeMx2%2fdReMwQNSY64yyg1AzGCTYEYEHixrAQMT2xWGiXwFNSXTMY1JazbT7Ilu3G7RGsSPnILXUyKjAkZ4SkwfMoiZOC6yiixIpLj0%2bPVSGBu7ZWPQJQ44gVuCKhEshHPJMuRm%2bJYdpTwb2iWDOg5zkAat39iMjVbOdmm2JdKfqz5TLrr4%2bNVQM3DabgjAQHJI0DsQcPJq%2bojToa4kH8%2ftT%2bfkCNuewm%2b9rDMM0nx5iqgjY0Bk1A0d4beCcR5CZjfCQaZh4tclgxew6YinTzVXezygbdIXzvCFLsDaydSK1X3jr4z1EuJWYUXryVRB9mzMgpXek7UqJk97Auu%2f1Zse0ON0UfgK822bHZSmVZ0IoJqzxWyHJstYKawTDTEiIUcNfBejoHYkk%2bVvxHJPnYAp9JJgpagoRQ6oMXUQUuOccU4FpDsD4sfauNc%2bIMepNao4N5fUjucC1ctM6Wx7ZqxBoRwt0BtBTBo%2bC8REAQLC3UAYQp5Bbnz4L4PZr4zXyS92HcHmLAsfkyhKxH3AuCEDFIei4o9VFyuJ2Lh0oD0J08h58h1A3Fupb2X97N7JjkFNfaES2ElVJpYhQPGEOPoZRzgZyHgCqUOsMaeyfwT5Gv0%2fTZYDOHDXws%2bcEWE5HF4KHle2G4016RdxvjELixYIIyCKrngIxIt7Lu1mZdn0%2bbr9evx6A6GSDuWQdVFUOAUUpCbUEGCRkJsgL8DPkYzjFdTvmvxeXdF0LrWFYglKoAJdaZAOBh8SpHJaZGCyWghimuJHaGn9oaGEAW%2bBdC%2fJRmP9dfMHZRaS88RTY6ZTihGlnnlQxcW0iRMHeO2SkD449Ky75Pu5mtP87guj9OE46xBEirYFNIrCGJWxY9uEdEwoL2IJcrDfYGe%2fAsJwj%2fhPvjARxBLaNkFGQIaqNURoQEJYJAxTFRmMPZh6TwCOSpZfg31HCDwTT7JGiFieUHKQpjHATNgJE%2btEcMXTdSRYW0%2fpCRzlDJMaf%2fEnSQEDGFs9hQQij3BMoGMVB%2fIbRTqYIVlhArTg76ey%2f%2fd6g1w54SoLOSRmkEcR4JFFW0YNvAFxEDZA0lTs3q99gpyN9Af1aMTlkCcR6sGiPYh9oixHyI6HAyAo05CKhSRqBzWPY%2fwf7crAlV3EJCwhGc7tCXOdVEwuIBQgdIGzFErtjJtfjdtP8daMkVOfQ7CgHEYcuJdgbCUji8IuQRrEij7H9s0L9fXdymq%2fUB%2bPvhNOcE7mcns%2f5LE8hw8RUjAmENvd9oscmX2eDH9w9n1%2bgK%2f%2f7nXxQznI4%3d";
      Stream stream   = null;
      StreamReader sr = null;
      try
      {
        byte[] bdata    = Convert.FromBase64String(Base64String);
        stream          = new MemoryStream(bdata);
        sr              = new StreamReader(stream);
        string filenote = sr.ReadToEnd();
        Console.WriteLine(filenote);
      }
      finally
      {
        if (stream != null) stream.Close();
        if (sr != null) sr.Close();
      }
    }
  }
}
