using Branch;
using SorteClint.com.proem.sorte.dao;
using SorteClint.com.proem.sorte.util;
using sorteSystem.com.proem.sorte.util;
using sorteSystem.com.proem.sorte.window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace SorteClint
{
    static class Program
    {

        private static string host = "192.168.1.113";

        private static int port = 8888;
        static IPAddress ip = IPAddress.Parse(host);
        static IPEndPoint ipe = new IPEndPoint(ip, port);
        /// <summary>
        /// 应用程序            的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BranchLogin login = new BranchLogin();
            //窗口居中
            login.StartPosition = FormStartPosition.CenterScreen;
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                string ip = getIPUtil.GetIPAddress();
                sorteDao sortedao = new sorteDao();
                string id = sortedao.getIpName(ip);
                string sorteId = sortedao.getSorteId(ip);
                ConstantUtil.ipid = id;
                ConstantUtil.ip = ip;
                ConstantUtil.sorteId = sorteId;
                sorteGoodList main = new sorteGoodList();
                //窗口居中
                main.StartPosition = FormStartPosition.CenterScreen;
                Application.Run(main);
            }
        }
    }
}
