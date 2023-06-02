// Протоколировать результаты работы
// (количество перемещений элементов, время расчёта,
// конечное состояние массива данных, вид данных). 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace program_tech_labs_cw.Models;

public static class ThirdTaskModel
{
    public static void Log(LogLevel logLevel, string message)
    {
        string logMessage = string.Empty;
        /*logMessage += logLevel switch
        {
            LogLevel.Trace => "TRACE|",
            LogLevel.Info => "INFO|",
            LogLevel.Warning => "WARNING|",
            LogLevel.Error => "ERROR|",
            _ => "UNKNOWN|"
        };
        
        logMessage += $"{DateTime.Now}|";*/
        logMessage += message /*+ "\n"*/;
        List<string> lines = File.ReadAllLines("Assets/trace.log").ToList();
        lines.Add(logMessage);
        File.WriteAllLines("Assets/trace.log", lines);
    }

    public enum LogLevel
    {
        Trace,
        Info,
        Warning,
        Error
    }
}