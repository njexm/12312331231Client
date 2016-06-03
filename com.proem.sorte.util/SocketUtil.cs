using sorteSystem.com.proem.sorte.window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sorteSystem.com.proem.sorte.util
{
    class SocketUtil
    {
        public delegate void UpdateGridData(string str);
        public UpdateGridData updateGridDataOthers;

        public static int bufferSize = 1024;
        public static int count = 0;//表示对话序号

        private volatile static SocketUtil instanceWork;    // 单例
        public SocketUtil(){
 
         }
 
       // 对外接口，获取单例
       public static SocketUtil GetInstance()
         {
             if (null == instanceWork)
             {
                 instanceWork = new SocketUtil();
            } 

             return instanceWork;
        }

        public static void RecMsg(object o)
        {
            Socket connSocket = o as Socket;
            while (true)
            {
                byte[] buffer = new Byte[bufferSize];
                try
                {
                    int length = connSocket.Receive(buffer);
                    byte[] realBuffer = new Byte[length];
                    Array.Copy(buffer, 0, realBuffer, 0, length);
                    string str = System.Text.Encoding.Default.GetString(realBuffer);
                    if (str != string.Empty) {
                        sorteGoodList list = new sorteGoodList();
                        //list.street = str;
                        ConstantUtil.redStatus = 2;
                        ConstantUtil.street = str;
                        //Application.Run(list);
                        //updateGridDataOthers(str);
                        
                    }
                    Console.Write("[{0}] ", count++);
                    Console.WriteLine("{0}说：{1}.", connSocket.RemoteEndPoint, str);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        public static void SendToServer(object o)
        {
            Socket socket = o as Socket;
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (str != string.Empty)
                    {
                        byte[] bt = Encoding.Default.GetBytes(str);
                        socket.Send(bt, bt.Length, 0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送失败。");
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
