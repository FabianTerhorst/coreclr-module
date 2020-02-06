using System;

namespace AltV.Net.Elements.Args
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args">IntPtr pointing to array of MValueConst pointers</param>
    /// <param name="size">Size of args array</param>
    public delegate IntPtr MValueFunctionCallback(IntPtr args, long size);
}