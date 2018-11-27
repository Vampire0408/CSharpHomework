using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

public class Crawler
{
    private Hashtable urls = new Hashtable();
    private int count = 0;

    static void Main(string[] args)
    {
        Crawler myCrawler = new Crawler();

        string startUrl = "http://www.baidu.com";
        if (args.Length >= 1) startUrl = args[0];

        myCrawler.urls.Add(startUrl, false);          //加入初始页面

        new Thread(myCrawler.Crawl).Start();          //开始爬行

        Task task = Task.Run(() => myCrawler.Crawl());      //并行

        Action[] actions = { new Action(myCrawler.Crawl), myCrawler.Crawl };
        Parallel.Invoke(actions);
    }

    public void Crawl()
    {
        while(true)
        {
            string current = null;
            foreach(string url in urls.Keys)        //找到一个还没有下载过的链接
            {
                if ((bool)urls[url]) continue;        //已经下载过的，不再下载
                current = url;
            }
            if (current == null || count > 10) break;

            Console.WriteLine("爬行" + current + "页面！");

            string html = Download(current);     //下载

            urls[current] = true;
            count++;

            Parse(html);                   //解析，并加入新的链接
        }

        Console.WriteLine("爬行结束");
    }

    public string Download(string url)
    {
        try
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);

            string fileName = count.ToString();
            File.WriteAllText(fileName, html, Encoding.UTF8);
            return html;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "";
        }
    }

    public void Parse(string html)
    {
        string strRef = @"(href | HREF)[] * = [] *[""'][^""'#>] + [""']";
        MatchCollection matches = new Regex(strRef).Matches(html);
        foreach (Match match in matches)
        {
            strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"','\"','#',' ','>');
            if (strRef.Length == 0) continue;
            if (urls[strRef] == null) urls[strRef] = false;
        }
    }
}
