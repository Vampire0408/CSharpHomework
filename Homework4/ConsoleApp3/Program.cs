using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//功能:当起床铃声响起,就引发事件

//声明参数类型
public class DownloadEventArgs : EventArgs
{
    public int Hour, Minute, Second;
}

// 定义一个委托
public delegate void DoSomething(object sender, DownloadEventArgs e);

// 产生事件的类 
public class Ring
{
    // 声明一个委托事件
    public event DoSomething DoIt;

    public void DoRing()
    {
        int hh = DateTime.Now.Hour;
        int mm = DateTime.Now.Minute;
        int ss = DateTime.Now.Second;
        string h = Console.ReadLine();
        int myhh = Int32.Parse(h);
        string m = Console.ReadLine();
        int mymm = Int32.Parse(m);
        string s = Console.ReadLine();
        int myss = Int32.Parse(s);
        if(myhh == hh && mymm ==mm && myss ==ss)
        {
            Console.WriteLine("闹钟响了");
        }
        else
        {
            Console.WriteLine("未到时间");
        }

        //发生事件，通知外界
        if(DoIt != null)
        {
            DownloadEventArgs args = new DownloadEventArgs();
            args.Hour = hh;
            args.Minute = mm;
            args.Second = ss;
            DoIt(this, args);
        }
    }
}

public class UseDownloader
{
    static void Main()
    {
        var downloader = new Ring();
        //注册事件
        downloader.DoIt += ShowProgress;
        downloader.DoRing();
    }

    //事件处理方法
    static void ShowProgress(object sender, DownloadEventArgs e)
    {
        Console.WriteLine($"运行中...");
    }
}