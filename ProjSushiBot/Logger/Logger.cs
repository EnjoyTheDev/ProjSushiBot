using System;
using System.IO;

namespace ProjSushiBot.Logger
{
  class Logger
  {
    private int _counter = 0;
    private string _path;

    public void StartLog()
    {
      string path = $"/Windows/Temp/log {DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}_{_counter}.txt";

      File.AppendAllText(path, $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}-{DateTime.Now.Year}:{DateTime.Now.Month}:{DateTime.Now.Day}-Create LogFile" + Environment.NewLine);

      _path = path;
      _counter++;
    }

    public void Debug()
    {
      File.AppendAllText(_path, $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}-{DateTime.Now.Year}:{DateTime.Now.Month}:{DateTime.Now.Day}-Program RunTime" + Environment.NewLine);
    }

    public void Info(string message)
    {
      File.AppendAllText(_path, $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}-{DateTime.Now.Year}:{DateTime.Now.Month}:{DateTime.Now.Day}-{message}" + Environment.NewLine);
    }

    public void Error(string message)
    {
      File.AppendAllText(_path, $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}-{DateTime.Now.Year}:{DateTime.Now.Month}:{DateTime.Now.Day}-{message}" + Environment.NewLine);
    }
  }
}