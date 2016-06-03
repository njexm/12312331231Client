using Branch;
using Oracle.ManagedDataAccess.Client;
using SorteClint.com.proem.sorte.window;
using sorteSystem.com.proem.sorte.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sorteSystem.com.proem.sorte.window
{
    public partial class sorteList : Form
    {
        public sorteList()
        {
            InitializeComponent();
        }

        private void sorteList_Load(object sender, EventArgs e)
        {

            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();

            //获取数据库连接
            OracleConnection connection = OracleUtil.OpenConn();
            string queryString = "select a.*,b.username as checkName,c.username as createName from zc_sorte a left join zc_user_info b on b.user_id=a.audit_men left join zc_user_info c on c.user_id=a.make_men   where AUDITS_TATUS ='2'";

            OracleCommand command = new OracleCommand(queryString);
            command.Connection = connection;

            try
            {
                var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Sorte newSorte = new Sorte();
                        String sorteId = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("CODE"));
                        String id = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("ID"));
                        newSorte.makeMen = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("createName"));
                        newSorte.createTime = reader.IsDBNull(2) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("CREATETIME"));
                       // newSorte.remrks =  reader.IsDBNull(8) ? string.Empty : reader.GetString(reader.GetOrdinal("REMRKS"));
                       // newSorte.auditStatus =  reader.IsDBNull(1) ? default(int) : reader.GetInt32(reader.GetOrdinal("AUDITSTATUS"));
                        newSorte.auditTime = reader.IsDBNull(1) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("AUDIT_TIME"));
                        newSorte.auditMen = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("checkName"));
                        newSorte.Id = id;
                        newSorte.code = sorteId;
                        idComboBox.Items.Add(newSorte);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                OracleUtil.CloseConn(connection);
            }

            idComboBox.DisplayMember = "code";
            idComboBox.ValueMember = "Id";
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void typoButton_Click(object sender, EventArgs e)
        {

        }

        private void idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选中分拣单
            Sorte sorteDetail = (Sorte)idComboBox.SelectedItem;
            examineManTextBox.Text = sorteDetail.auditMen;
            makeDateTextBox.Text = sorteDetail.createTime.ToLongDateString();
            makerTextBox.Text = sorteDetail.makeMen;
            examineDateTextBox.Text = sorteDetail.auditTime.ToLongDateString();
            loadBranchTotal(sorteDetail.Id);
        }

        private void sorteListTableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsANonHeaderLinkCell(e))
            {
            }
            else if (IsANonHeaderButtonCell(e))
            {
                sorteGoodList goodsList = new sorteGoodList();
                goodsList.sortelist = this;
                goodsList.street=sorteListTableDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Value.ToString();
                goodsList.Show();
                this.Hide();
            }
        }


        private bool IsANonHeaderLinkCell(DataGridViewCellEventArgs cellEvent)
        {
            if (sorteListTableDataGridView.Columns[cellEvent.ColumnIndex] is
                DataGridViewLinkColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return false; }
        }

        private bool IsANonHeaderButtonCell(DataGridViewCellEventArgs cellEvent)
        {
            if (sorteListTableDataGridView.Columns[cellEvent.ColumnIndex] is
                DataGridViewButtonColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return (false); }
        }


        /// <summary>
        /// 加载分店信息
        /// </summary>
        private void loadBranchTotal(string id)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("branch_code"));
            //dt.Columns.Add(new DataColumn("branch_name"));
            //dt.Columns.Add(new DataColumn("duty_man"));
            //dt.Columns.Add(new DataColumn("mobile_phone"));
            //dt.Columns.Add(new DataColumn("Column1"));
            //dt.Columns.Add(new DataColumn("id"));
            //dt.Columns.Add(new DataColumn("goodsFile_id"));
            //获取数据库连接
            DataSet ds = new DataSet();
            OracleConnection connection = OracleUtil.OpenConn();
            string sql = "select a.*,b.branch_code,b.branch_name,c.username,c.mobilephone,d.street,'商品详情' as buttonText from Zc_sorte_item a "
                 + "left join zc_branch_total b on b.id=a.branch_total_id "
                 + "left join zc_user_info c on c.id=a.customer "
                 + "left join zc_zoning d on d.id=b.zoning_id "
                 + "where a.sorte_id ='" + id + "' order by a.createTime desc ";
            OracleCommand cmd = new OracleCommand(sql, connection);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds, "Zc_sorte_item");
            sorteListTableDataGridView.DataSource = ds;
            sorteListTableDataGridView.AutoGenerateColumns = false;
            sorteListTableDataGridView.DataMember = "Zc_sorte_item";

            //OracleCommand command = new OracleCommand(sql);
            //command.Connection = connection;

            //try
            //{
            //    var reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string branch_code = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("BRANCH_CODE"));
            //        string branch_name = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("BRANCH_NAME"));
            //        string duty_man = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("USERNAME"));
            //        string mobile_phone = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("MOBILEPHONE"));
            //        string Id = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("ID"));
            //        string goodsFile_id = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("STREET"));
            //        dt.Rows.Add(new object[] { branch_code, branch_name, duty_man, mobile_phone, "", Id, goodsFile_id });
            //    }
            //    sorteListTableDataGridView.AutoGenerateColumns = false;
            //    sorteListTableDataGridView.DataSource = dt;  
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    OracleUtil.CloseConn(connection);
            //}
        }
    }
}
