using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace program_tech_labs_cw.Models;

public class StringItem : IDataItem<string>
{
    public string Value { get; set; }
    public string Type => Value.GetType().ToString();
}

public class DoubleItem : IDataItem<double>
{
    public double Value { get; set; }
    public string Type => Value.GetType().ToString();
}

public interface IDataItem<T>
{
    public T Value { get; set; }
}
