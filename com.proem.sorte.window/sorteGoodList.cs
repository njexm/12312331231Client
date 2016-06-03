using Branch;
using Branch.com.proem.exm.util;
using Oracle.ManagedDataAccess.Client;
using SorteClint.com.proem.sorte.dao;
using SorteClint.com.proem.sorte.domain;
using SorteClint.com.proem.sorte.window;
using sorteSystem.com.proem.sorte.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace sorteSystem.com.proem.sorte.window
{
    public partial class sorteGoodList : Form
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(sorteGoodList)); 

        private int select_value = 0;

        private int RowsCount = 0;

        ////刷新委托
        //private delegate void UpdateGridData(string str);
        //private UpdateGridData updateGridData;
        private delegate string updateGVDelegate();
        private string updateGV()
        {
            DataSet ds = getGridData();
            goodDataGridView.DataSource = ds;
            if(RowsCount != goodDataGridView.Rows.Count)
            {
                RowsCount = goodDataGridView.Rows.Count;
                select_value = 0;
            }
            if (goodDataGridView.Rows.Count > select_value)
            {
                goodDataGridView.Rows[select_value].Selected = true;
                goodDataGridView.CurrentCell = goodDataGridView.Rows[select_value].Cells[0];
            }
            //if (goodDataGridView.Rows.Count > _ScrollValue)
            //{
            //    goodDataGridView.FirstDisplayedScrollingRowIndex = _ScrollValue;
            //}
            color();
            return "1";
        }
        private SocketUtil su;
        object result;
        private DataSet ds = null;
        public string street
        {
            get;
            set; 
        }
        public sorteList sortelist
        {
            get;
            set;
        }
        public sorteGoodList()
        {
            InitializeComponent();

            //Thread thread = new Thread(new ThreadStart(refreshData));
            //thread.Start();
            //su = SocketUtil.GetInstance();
            //su.updateGridDataOthers = new SocketUtil.UpdateGridData(ReciveData);
            //updateGridData = new UpdateGridData(RefrushListBox);

            ////Thread th = new Thread(new ParameterizedThreadStart(su.RecMsg));
            ////th.Start();
            //Thread recTh = new Thread(su.RecMsg);
            //recTh.Start(ConstantUtil.socketList[ConstantUtil.socketName]);
        }

        //刷新数据
    //    public void ReciveData(string str)
    //    {
    //        this.BeginInvoke(updateGridData);
           
    //    }
    //    public void RefrushListBox(string str)
    //    {
    //        if (ConstantUtil.redStatus == 2)
    //        {
    //            redButton.Hide();
    //            redLabel.Hide();
    //            yellowButton.Hide();
    //            yellowLabel.Hide();
    //            greenButton.Show();
    //            greenLabel.Show();
    //        }
    //        else
    //        {
    //            redButton.Hide();
    //            redLabel.Hide();
    //            yellowButton.Show();
    //            yellowLabel.Show();
    //            greenButton.Hide();
    //            greenLabel.Hide();
    //        }
    //        string branchName = getBranchName();
    //        textBox1.Text = branchName;
    //        DataSet ds = new DataSet();
    //        OracleConnection connection = OracleUtil.OpenConn();
    //        string sql = "select name,serialNumber,goodsfile_id,sum(nums) as nums,branchid ,sorteNum ,workname,workcode,sorteId from "
    //  + "(select a.goods_state,a.name,a.nums,c.id as goodsfile_id,c.serialNumber,b.branchid,d.sortenum as sorteNum,e.workname,e.workcode,d.id as sorteId "
    //  + " from zc_order_process_item a "
    //  + " left join zc_order_process b on b.id=a.order_id left join zc_goods_master c on c.id=a.goodsfile_id left join zc_orders_sorte d on d.goods_id = c.id and b.branchid=d.address  left join zc_workstation e on e.id = c.zcuserinfo"
    //+ " where branchid = '" + ConstantUtil.street + "'  and c.ZCUSERINFO = '" + ConstantUtil.ipid + "') "
    //  + "group by name,serialNumber,goodsfile_id,branchid,sorteNum,workname,workcode,sorteId";
    //        OracleCommand cmd = new OracleCommand(sql, connection);
    //        OracleDataAdapter da = new OracleDataAdapter(cmd);
    //        da.Fill(ds, "Zc_sorte_item");
    //        goodDataGridView.DataSource = ds;
    //        goodDataGridView.AutoGenerateColumns = false;
    //        goodDataGridView.DataMember = "Zc_sorte_item";
    //    }

        public Boolean isSend = false;
        public string addOrReduceFlag = "add";
        private void goodDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void goodTableGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void sorteGoodList_Load(object sender, EventArgs e)
        {
            workNameText.Text = ConstantUtil.workName;
            //int hw = redButton.Height;
            //if (hw > redButton.Width) hw = redButton.Width;
            //System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            //gp.AddEllipse(4, 4, hw - 8, hw - 8);
            //gp.FillMode = System.Drawing.Drawing2D.FillMode.Winding;
            //redButton.Region = new Region(gp);
            //redButton.BackColor = Color.Red;
            //yellowButton.Region = new Region(gp);
            //yellowButton.BackColor = Color.Yellow;
            //greenButton.Region = new Region(gp);
            //greenButton.BackColor = Color.Green;
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();
            //展示数据
            showInfo();

            string branchName = getBranchName(ConstantUtil.street);
            textBox1.Text = branchName;

            System.Timers.Timer pTimer = new System.Timers.Timer(2000);//每隔5秒执行一次，没用winfrom自带的
            pTimer.Elapsed += pTimer_Elapsed;//委托，要执行的方法
            pTimer.AutoReset = true;//获取该定时器自动执行
            pTimer.Enabled = true;//这个一定要写，要不然定时器不会执行的
            Control.CheckForIllegalCrossThreadCalls = false;//这个不太懂，有待研究
        }

        public DataSet getGridData()
        {
            string street = getstreetName();
            ConstantUtil.street = street;
            string branchName = getBranchName(ConstantUtil.street);
            textBox1.Text = branchName;
            if (string.IsNullOrEmpty(ConstantUtil.remark) || " ".Equals(ConstantUtil.remark))
            {
                goodTablePanel.Location = new Point(4, 15);
                label1.Visible = false;
                textBox2.Visible = false;
                label1.Text = "";
            }
            else {
                goodTablePanel.Location = new Point(4, 85);
                label1.Visible = true;
                textBox2.Visible = true;
                textBox2.Text = ConstantUtil.remark;
            }
            try
            {
                OracleConnection connection = OracleUtil.OpenConn();
                if (connection == null)
                {
                    ds = null;

                }
                else
                {
                    //在每次查找或填充数据前判断ds是否为null
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            ds.Tables[0].Rows.Clear();
                            ds.Tables[0].Columns.Clear();
                            ds.Tables[0].AcceptChanges();
                        }
                    }
                    else
                    {
                        ds = new DataSet();
                    }
    //                    string sql = "select name,serialNumber,goodsfile_id,sum(nums) as nums,branchid ,sorteNum ,workname,workcode,sorteId from "
    //  + "(select a.goods_state,a.name,a.nums,c.id as goodsfile_id,c.serialNumber,b.branchid,d.sortenum as sorteNum,e.workname,e.workcode,d.id as sorteId "
    //  + " from zc_order_process_item a "
    //  + " left join zc_order_process b on b.id=a.order_id left join zc_goods_master c on c.id=a.goodsfile_id left join zc_orders_sorte d on d.goods_id = c.id and b.branchid=d.address  left join zc_workstation e on e.id = c.zcuserinfo"
    //+ " where branchid = '" + ConstantUtil.street + "'  and c.ZCUSERINFO = '" + ConstantUtil.ipid + "') "
    //  + "group by name,serialNumber,goodsfile_id,branchid,sorteNum,workname,workcode,sorteId";
                    string sql = "select name,serialNumber,goodsfile_id,sum(nums) as nums,branchid ,sorteNum ,workname,workcode from "
                    +" (select a.goods_state,a.name,a.nums,c.id as goodsfile_id,c.serialNumber,b.branchid,d.sortenum as sorteNum,e.workname,e.workcode "
                    +" from zc_order_process_item a "
                    +" left join zc_order_process b on b.id=a.order_id left join zc_goods_master c on c.id=a.goodsfile_id left join (select SUM(sortenum) as sortenum,goods_id ,address from ZC_ORDERS_SORTE where sorteId ='"+ConstantUtil.sorteId+"' GROUP by goods_id, address) d on d.goods_id = c.id and b.branchid=d.address  left join zc_workstation e on e.id = c.zcuserinfo "
                    + " where branchid = '" + ConstantUtil.street + "'  and c.ZCUSERINFO = '" + ConstantUtil.ipid + "') "
                    + " group by name,serialNumber,goodsfile_id,branchid,sorteNum,workname,workcode order by serialNumber";
                    OracleCommand cmd = new OracleCommand(sql, connection);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Zc_sorte_item");

                    //遍历一个表多行多列
                    //foreach (DataRow mDr in ds.Tables[0].Rows)
                    //{
                    //    foreach (DataColumn mDc in ds.Tables[0].Columns)
                    //    {
                    //        Console.WriteLine(num + "-〉data->" + mDr[mDc].ToString());
                    //    }
                    //}

                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                log.Error("获取工位相关商品信息失败", ex);
            }

            return ds;
        }
        public void showInfo()
        {
            //if (ConstantUtil.redStatus == 2)
            //{
            //    redButton.Hide();
            //    redLabel.Hide();
            //    yellowButton.Hide();
            //    yellowLabel.Hide();
            //    greenButton.Show();
            //    greenLabel.Show();
            //}
            //else
            //{
            //    redButton.Hide();
            //    redLabel.Hide();
            //    yellowButton.Show();
            //    yellowLabel.Show();
            //    greenButton.Hide();
            //    greenLabel.Hide();
            //}

            getGridData();
            goodDataGridView.DataSource = ds;
            goodDataGridView.AutoGenerateColumns = false;
            goodDataGridView.DataMember = "Zc_sorte_item";

            color();
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            sortelist.Show();
            this.Close();
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定退出系统?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
         
            //byte[] buffer = Encoding.Default.GetBytes(str);
            //connSocket.Send(buffer, buffer.Length, SocketFlags.None);
        }

        //public void AddGoods(string num)
        //{
        //    ///18位条码和13位条码混合
        //    if (string.IsNullOrEmpty(num) || (num.Length != 13 && num.Length != 18))
        //    {
        //        MessageBox.Show("请确认扫码的条码是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        numberTextBox.Text = "";
        //        return;
        //    }
        //    ///以后的13的条码
        //    //if(string.IsNullOrEmpty(num) || num.Length != 13)
        //    //{
        //    //    MessageBox.Show("请确认扫码的条码是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    numberTextBox.Text = "";
        //    //    return;
        //    //}
        //    ///扫码扫出来的结果
        //    string serialNumber = "";
        //    float weigth = 0;

        //    if (num.StartsWith("28"))
        //    {
        //        ///13位的条码
        //        //serialNumber = num.Substring(2, 5);
        //        //string weightString = num.Substring(7, 5);
        //        //weigth = float.Parse(weightString.Insert(2, "."));
        //        ///18位的条码
        //        serialNumber = num.Substring(2, 5);
        //        string weightString = num.Substring(12, 5);
        //        weigth = float.Parse(weightString.Insert(2, "."));
        //    }
        //    else
        //    {
        //        serialNumber = num;
        //    }

        //    DataSet ds = (DataSet)this.goodDataGridView.DataSource;
        //    bool flag = false;
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        string serialNum = this.goodDataGridView[0, i].Value == null ? "":this.goodDataGridView[0, i].Value.ToString();
        //        if (serialNum.Equals(serialNumber))
        //        {
        //            string nums = this.goodDataGridView[4, i].Value == null || "".Equals(this.goodDataGridView[4, i].Value) ? "0" : this.goodDataGridView[4, i].Value.ToString();
        //            string orderNums = this.goodDataGridView[3, i].Value.ToString();
                    
        //                flag = true;
        //                //if (nums == null || "0".Equals(nums) || "".Equals(nums))
        //                //{
        //                //    if (addOrReduceFlag == "add")
        //                //    {
        //                //        this.goodDataGridView[4, i].Value = 1;
        //                //    }
        //                //    else { 
        //                //        this.goodDataGridView[4, i].Value = 0;
        //                //        addOrReduceFlag = "add";
        //                //        addReduceButton.Text = "加（+）";
        //                //    }
        //                //}
        //                //else
        //                //{
        //                //    if (addOrReduceFlag == "add")
        //                //    {
        //                //        this.goodDataGridView[4, i].Value = Convert.ToInt32(nums) + Convert.ToInt32(1);
        //                //    }
        //                //    else {
        //                //        this.goodDataGridView[4, i].Value = Convert.ToInt32(nums) - Convert.ToInt32(1);
        //                //        addOrReduceFlag = "add";
        //                //        addReduceButton.Text = "加（+）";
        //                //    }
        //                //}
        //            ///start 新增判断
        //                if ((string.IsNullOrEmpty(nums) || "0".Equals(nums)) && addOrReduceFlag != "add")
        //                {
        //                    MessageBox.Show("此商品份数为0无法进行减去操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    numberTextBox.Text = "";
        //                    return;
        //                }
        //                else
        //                {
        //                    orderSorte orderSorte = new orderSorte();
        //                    //orderSorte.id = Guid.NewGuid().ToString();
        //                    orderSorte.createTime = DateTime.Now;
        //                    orderSorte.updateTime = DateTime.Now;
        //                    orderSorte.address = ConstantUtil.street;
        //                    orderSorte.goods_id = this.goodDataGridView.Rows[i].Cells[5].Value == null ? "" : this.goodDataGridView.Rows[i].Cells[5].Value.ToString();
        //                    orderSorte.id = Guid.NewGuid().ToString();
        //                    orderSorte.goods_name = this.goodDataGridView.Rows[i].Cells[2].Value == null ? "" : this.goodDataGridView.Rows[i].Cells[2].Value.ToString();
        //                    //订单份数
        //                    orderSorte.orderNum = this.goodDataGridView.Rows[i].Cells[3].Value == null ? "" : this.goodDataGridView.Rows[i].Cells[3].Value.ToString();
                           
        //                    orderSorte.weight = weigth.ToString();
        //                    sorteDao sortedao = new sorteDao();
        //                    if (addOrReduceFlag == "add")
        //                    {
        //                        orderSorte.sorteNum = "1";
        //                        sortedao.AddtransitItem(orderSorte);
        //                    }
        //                    else
        //                    {
        //                        List<string> list = sortedao.FindBy(orderSorte.goods_id, weigth.ToString(), ConstantUtil.street);
        //                        if(list.Count == 0)
        //                        {
        //                            MessageBox.Show("没有此商品对应得分拣记录，无需进行减去操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                            numberTextBox.Text = "";
        //                            return;
        //                        }
        //                        sortedao.DeleteBy(list[0]);
        //                        addOrReduceFlag = "add";
        //                        addReduceButton.Text = "加（F1）";
        //                    }
        //                }
        //            ///end
        //               // List<orderSorte> orderSorteList = new List<orderSorte>();
        //               // for (int x = 0; x < ds.Tables[0].Rows.Count; x++) { 
        //               // orderSorte orderSorte = new orderSorte();
        //               // //orderSorte.id = Guid.NewGuid().ToString();
        //               // orderSorte.createTime = DateTime.Now;
        //               // orderSorte.updateTime = DateTime.Now;
        //               // orderSorte.address = ConstantUtil.street;
        //               // orderSorte.goods_id = this.goodDataGridView.Rows[x].Cells[5].Value == null ? "" : this.goodDataGridView.Rows[x].Cells[5].Value.ToString();
        //               // orderSorte.id = this.goodDataGridView.Rows[x].Cells[6].Value == null ? "" : this.goodDataGridView.Rows[x].Cells[6].Value.ToString();
        //               // orderSorte.goods_name = this.goodDataGridView.Rows[x].Cells[2].Value == null ? "" : this.goodDataGridView.Rows[x].Cells[2].Value.ToString();
        //               // //订单份数
        //               // orderSorte.orderNum = this.goodDataGridView.Rows[x].Cells[3].Value == null ? "" : this.goodDataGridView.Rows[x].Cells[3].Value.ToString();
        //               // //分拣的份数
        //               // string newCount = this.goodDataGridView.Rows[x].Cells[4].Value == null ? "" : this.goodDataGridView.Rows[x].Cells[4].Value.ToString();
        //               // orderSorte.sorteNum = newCount;
        //               // orderSorteList.Add(orderSorte);
        //               // }
                        
        //               //List<string> idStr = sortedao.AddtransitItem(orderSorteList);
        //               //if (idStr != null && idStr.Count > 0) {
        //               //    for (int y = 0; y < idStr.Count; y++) {
        //               //        this.goodDataGridView.Rows[y].Cells[6].Value = idStr[y];
        //               //    }
        //               //}
        //        //        DataSet ds1 = new DataSet();
        //        //        OracleConnection connection = OracleUtil.OpenConn();
        //        //        string sql = "select name,serialNumber,goodsfile_id,sum(nums) as nums,branchid ,sorteNum ,workname,workcode,sorteId from "
        //        //  + "(select a.goods_state,a.name,a.nums,c.id as goodsfile_id,c.serialNumber,b.branchid,d.sortenum as sorteNum,e.workname,e.workcode,d.id as sorteId "
        //        //  + " from zc_order_process_item a "
        //        //  + " left join zc_order_process b on b.id=a.order_id left join zc_goods_master c on c.id=a.goodsfile_id left join zc_orders_sorte d on d.goods_id = c.id and b.branchid=d.address  left join zc_workstation e on e.id = c.zcuserinfo"
        //        //+ " where branchid = '" + ConstantUtil.street + "' ) "
        //        //            // and c.ZCUSERINFO = '" + LoginUserInfo.branchName + "'
        //        //  + "group by name,serialNumber,goodsfile_id,branchid,sorteNum,workname,workcode,sorteId";
        //        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        //        OracleDataAdapter da = new OracleDataAdapter(cmd);
        //        //        da.Fill(ds1, "Zc_sorte_item");
        //        //        goodDataGridView.DataSource = ds1;
        //        //        goodDataGridView.AutoGenerateColumns = false;
        //        //        goodDataGridView.DataMember = "Zc_sorte_item";
        //                numberTextBox.Text = "";
        //            //}
        //        }
        //        else
        //        {
                   
        //        }
        //    }
        //    if (!flag)
        //    {
        //        MessageBox.Show("没有此商品，请确认商品或者货号是否正确");
        //        numberTextBox.Text = "";
        //        return; 
        //    }
        //    //自动计算
        //    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //{
        //    //    if (ds.Tables[0].Rows[i][0].ToString().ToString().Equals(obj.SerialNumber))
        //    //    {
        //    //        string nums = itemDataGridView[5, i].Value.ToString();
        //    //        itemDataGridView[5, i].Value = Convert.ToInt32(nums) + Convert.ToInt32(num);
        //    //        return;
        //    //    }
        //    //}
        //    //ds.Tables[0].Rows.Add(obj.SerialNumber, obj.GoodsName, obj.GoodsUnit, obj.GoodsSpecifications, num, obj.GoodsPrice, (Convert.ToInt32(num) * obj.GoodsPrice).ToString("0.00"), obj.Remark, Guid.NewGuid().ToString(), obj.Id);
        //    //Calculate();
        //}
        private void sorteGoodList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                leaveButton_Click(this, EventArgs.Empty);

            }
            else if (e.KeyCode == Keys.Up)
            {
                if (select_value > 0)
                {
                    select_value -= 1;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (select_value < goodDataGridView.Rows.Count - 1)
                {
                    select_value += 1;
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (select_value - goodDataGridView.DisplayedRowCount(false) >= 0)
                {
                    select_value -= goodDataGridView.DisplayedRowCount(false);
                }
                else
                {
                    select_value = 0;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (select_value + goodDataGridView.DisplayedRowCount(false) < goodDataGridView.RowCount - 1)
                {
                    select_value += goodDataGridView.DisplayedRowCount(false);
                }
                else
                {
                    select_value = goodDataGridView.RowCount - 1;
                }
            }
        }

        private void numberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void endButton_Click(object sender, EventArgs e)
        {
            if (isSend == false)
            {
                if (goodDataGridView.Rows.Count > 0)
                {
                    for (int i = 0; i < goodDataGridView.Rows.Count; i++)
                    {
                        string oldCount = goodDataGridView.Rows[i].Cells[3].Value == null ? "" : goodDataGridView.Rows[i].Cells[3].Value.ToString();
                        string newCount = goodDataGridView.Rows[i].Cells[4].Value == null ? "" : goodDataGridView.Rows[i].Cells[4].Value.ToString();
                        if (oldCount.Equals(newCount)) { }
                        else
                        {
                           DialogResult r1= MessageBox.Show("存在分拣份数不符合的商品,是否继续？","结束分拣",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                           if (r1.ToString() == "Yes")

                           {  }

                           if (r1.ToString().Equals("No"))

                           { return; }

                           if (r1.ToString().Equals("Cancel"))

                           { return; }
                            
                        }
                    }
                    //发送分拣商品数量到主客户端
                    string sendResult = LoginUserInfo.branchName;
                     isSend = true;
                    MessageBox.Show("分拣成功");
                    sorteDao sortedao = new sorteDao();
                    sortedao.deleteSorteStatus(ConstantUtil.ip);
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("没有正在进行分拣的商品!");
                }
            }
            else {
                MessageBox.Show("分拣结果已经提交，请勿多次提交!");
            }
           
        }

        public string getBranchName(string street) {
            //获取数据库连接
            OracleConnection connection = OracleUtil.OpenConn();
            string queryString = "select a.branch_name from zc_branch_total a left join zc_zoning b on b.id = a.zoning_id where b.street= '" + street + "'";

            OracleCommand command = new OracleCommand(queryString);
            command.Connection = connection;

            try
            {
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string confirmPassword = string.Format("{0}", reader["branch_name"]);
                    return confirmPassword;
                }
            }
            catch (Exception ex)
            {
                log.Error("获取分店名称失败", ex);
            }
            finally
            {
                OracleUtil.CloseConn(connection);
            }
            return null;
        }
        public string getstreetName()
        {
            //获取数据库连接
            OracleConnection connection = OracleUtil.OpenConn();
            string queryString = "select a.street, b.remark from zc_sorte_status a left join ZC_SORTE_ITEM b on a.\"sorteId\" = b.SORTE_ID and a.STREET = b.AREAID "+
                " where a.ip = '"+ConstantUtil.ip+"'";
            OracleCommand command = new OracleCommand(queryString);
            command.Connection = connection;

            try
            {
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string street = string.Format("{0}", reader["street"]);
                    string remark = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    ConstantUtil.remark = remark;
                    return street;
                }
            }
            catch (Exception ex)
            {
                log.Error("获取分店street编码失败", ex);
            }
            finally
            {
                OracleUtil.CloseConn(connection);
            }
            return null;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void greenButton_Click(object sender, EventArgs e)
        {

        }

        private void goodDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            color();
            //if (e.RowIndex != -1 && e.ColumnIndex == 3)
            //{
            //    int cot = Convert.ToInt32(goodDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString()) - Convert.ToInt32(goodDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
            //    if (cot != 0)
            //    {
            //        this.goodDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            //    }
            //    else
            //    {
            //        this.goodDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
            //    }
            //}
        }
        public void color()
        {
            for (int i = 0; i < goodDataGridView.Rows.Count; i++)
            {
                int cot = Convert.ToInt32(goodDataGridView[4, i].Value.ToString().Trim() == "" ? "0" : goodDataGridView[4, i].Value.ToString());
                int cot2 = Convert.ToInt32(goodDataGridView[3, i].Value.ToString().Trim() == "" ? "0" : goodDataGridView[3, i].Value.ToString());

                //int cot = Convert.ToInt32(goodDataGridView[4, i].Value.ToString()) - Convert.ToInt32(goodDataGridView[3, i].Value.ToString());
                if (cot != cot2)
                {
                    this.goodDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(201, 67, 65);//Color.Red;
                    this.goodDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    this.goodDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(51, 153, 255);//Color.Blue;
                    this.goodDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void redButton_Click(object sender, EventArgs e)
        {

        }

        private void pTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Timebutton_Click(updateGV);
        }
        int num = 0;
        private string Timebutton_Click(updateGVDelegate updategv_dele)
        {
            if (this.InvokeRequired)
            {
                return (string)this.Invoke(updategv_dele);
            }
            else
            {
                return updategv_dele();
            }
        }

    //    private void reLoadData()
    //    {
    //        if (ConstantUtil.redStatus == 2)
    //        {
    //            redButton.Hide();
    //            redLabel.Hide();
    //            yellowButton.Hide();
    //            yellowLabel.Hide();
    //            greenButton.Show();
    //            greenLabel.Show();
    //        }
    //        else
    //        {
    //            redButton.Hide();
    //            redLabel.Hide();
    //            yellowButton.Show();
    //            yellowLabel.Show();
    //            greenButton.Hide();
    //            greenLabel.Hide();
    //        }
    //        string street = getstreetName();
    //        string branchName = getBranchName(street);
    //        textBox1.Text = branchName;
    //        DataSet ds = new DataSet();
    //        OracleConnection connection = OracleUtil.OpenConn();
    //        string sql = "select name,serialNumber,goodsfile_id,sum(nums) as nums,branchid ,sorteNum ,workname,workcode,sorteId from "
    //  + "(select a.goods_state,a.name,a.nums,c.id as goodsfile_id,c.serialNumber,b.branchid,d.sortenum as sorteNum,e.workname,e.workcode,d.id as sorteId "
    //  + " from zc_order_process_item a "
    //  + " left join zc_order_process b on b.id=a.order_id left join zc_goods_master c on c.id=a.goodsfile_id left join zc_orders_sorte d on d.goods_id = c.id and b.branchid=d.address  left join zc_workstation e on e.id = c.zcuserinfo"
    //+ " where branchid = '" + street + "'  and c.ZCUSERINFO = '" + ConstantUtil.ipid + "') "
    //  + "group by name,serialNumber,goodsfile_id,branchid,sorteNum,workname,workcode,sorteId";
    //        OracleCommand cmd = new OracleCommand(sql, connection);
    //        OracleDataAdapter da = new OracleDataAdapter(cmd);
    //        da.Fill(ds, "Zc_sorte_item");
    //        goodDataGridView.DataSource = ds;
    //        goodDataGridView.AutoGenerateColumns = false;
    //        goodDataGridView.DataMember = "Zc_sorte_item";

    //        color();
    //    }

        private void goodDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //行号
            using (SolidBrush b = new SolidBrush(this.goodDataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
            }
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        //private int _ScrollValue = 0;

        //private void goodDataGridView_Scroll(object sender, ScrollEventArgs e)
        //{
        //    if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
        //    {
        //        _ScrollValue = e.NewValue;
        //    }
        //}
            
    }
}
