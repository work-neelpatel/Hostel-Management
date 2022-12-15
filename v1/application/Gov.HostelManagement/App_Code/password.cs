using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for password
/// </summary>
public class password
{
    string p;

    public char newp
    {
        get { return newp; }
        set { p = p + (value * value); }
    }
    public string show
    {
        get { return p; }
    }
    public void pass()
    { }

}