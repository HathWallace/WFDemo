using System;
using System.IO;
using System.Xml;

namespace ActivityLib.Toolbox
{
    public class Dao
    {
        public void Update(int id, string stateName)
        {
            //写入数据库
            if (stateName != "结束")
                Console.WriteLine($"流程{id}开始{stateName}。");
            else
                Console.WriteLine($"流程{id}已结束。");
        }

    }
}