# WFDemo
.NET Framework下Windows Workflow Foundation (WF) 的Demo。



## HelloWorkflow

待完成。



## StateMachineExample

状态机工作流实例，其流程图如下。

![流程审批2](https://gitee.com/MouZhuangZi/pic-go/raw/master/%E6%B5%81%E7%A8%8B%E5%AE%A1%E6%89%B92.png)

状态机设计见`ActivityLib/MyWorkflow.xaml`。



## PersistenceExample

持久化工作流实例，流程图同上。运行前需进行持久化配置，配置步骤如下：

1. 下载安装SQL Server。

2. 通过创建一个数据库来持久保存工作流实例。

   ```sql
   CREATE DATABASE [数据库名]
    CONTAINMENT = NONE
    ON  PRIMARY 
   ( NAME = N'数据库名', FILENAME = N'自己的路径\数据库名.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
    LOG ON 
   ( NAME = N'数据库名_log', FILENAME = N'自己的路径\数据库名_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
   GO
   ```
   e.g.
   
   ![image-20210305210459914](https://gitee.com/MouZhuangZi/pic-go/raw/master/image-20210305210459914.png)
   
3. 新建表来存储工作流的实例数据。按Win+R，运行%WINDIR%\Microsoft.NET\Framework，到\v4.xxx\SQL\EN 文件夹下面去寻找脚本。

   ![image-20210305205749705](https://gitee.com/MouZhuangZi/pic-go/raw/master/image-20210305205749705.png)

   找到这两个SQL脚本之后，在数据库WorkFlowDB中首先运行 SqlWorkflowInstanceStoreSchema.sql 文件，然后运行 SqlWorkflowInstanceStoreLogic.sql 文件。执行完成之后，就会在数据库WorkFlowDB中新建如下表。

   <img src="https://gitee.com/MouZhuangZi/pic-go/raw/master/image-20210305210720187.png" alt="image-20210305210720187" style="zoom: 67%;" />

4. 将连接语句以 `SqlConfig.txt` 文件的形式与 `PersistenceExample.exe` 程序保存在同一文件夹内。

   e.g.

   ```sql
   Data Source=DESKTOP-G6OFSPR;Initial Catalog=WorkflowDB;Integrated Security=TRUE;
   ```



## 推荐阅读

如果想快速入手WF，推荐阅读[WF - 随笔分类 - 邹琼俊 - 博客园](https://www.cnblogs.com/jiekzou/category/925128.html)这个专栏；如果想对WF进行更加深入的了解，可以去阅读[WF4.0 技术文章 - 随笔分类 - WXWinter(冬) - 博客园](https://www.cnblogs.com/foundation/category/215023.html)以及WXWinter这位博主的其他专栏，写的非常详实而且示例很多。

- [工作流持久性 | Microsoft Docs](https://docs.microsoft.com/zh-cn/dotnet/framework/windows-workflow-foundation/workflow-persistence)
- [WorkflowApplication 类 (System.Activities) | Microsoft Docs](https://docs.microsoft.com/zh-cn/dotnet/api/system.activities.workflowapplication?view=netframework-4.8)
- [NativeActivity 类 (System.Activities) | Microsoft Docs](https://docs.microsoft.com/zh-cn/dotnet/api/system.activities.nativeactivity?view=netframework-4.8)
- [WF - 随笔分类 - 邹琼俊 - 博客园](https://www.cnblogs.com/jiekzou/category/925128.html)
- [WF4.0 技术文章 - 随笔分类 - WXWinter(冬) - 博客园](https://www.cnblogs.com/foundation/category/215023.html)
  - [WF4.0 基础篇 (十七) Bookmark - WXWinter(冬) - 博客园](https://www.cnblogs.com/foundation/archive/2010/01/08/1642614.html)
  - [WF4.0 基础篇 (十九) Persistence 持久化 - WXWinter(冬) - 博客园](https://www.cnblogs.com/foundation/archive/2010/01/15/1648611.html)

- [WF 例子 - 随笔分类 - WXWinter(冬) - 博客园](https://www.cnblogs.com/foundation/category/212579.html)
  - [WF是什么系列之 [ 使用WF 实现会签业务流程 ] - WXWinter(冬) - 博客园](https://www.cnblogs.com/foundation/archive/2010/03/04/1678612.html)

- [workflow_tulandsoft的专栏_赵之章-CSDN博客](https://blog.csdn.net/tulandsoft/category_7757574.html)