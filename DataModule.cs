using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_Tools
{
    class DataModule
    {
        SqlConnection _Connection = new SqlConnection();

        public DataModule()
        {
        }

        public bool ConnectDatabase(string connName)
        {
            if (connName == "Closed")
            {
                _Connection.Close();
                return false;
            }
            else
            {
                string cs = ClsConfig.GetConnectionString(connName);
                _Connection.Close();
                try
                {
                    _Connection.ConnectionString = cs;
                    _Connection.Open();
                    return _Connection.State == System.Data.ConnectionState.Open;
                }
                catch (ArgumentException e)
                { 
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public string Execute(string SQLText, DataGridView dataGridView)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SqlCommand cmd = new SqlCommand(SQLText, _Connection);
                SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dataGridView.Visible = false;
                dataGridView.ReadOnly = true;
                dataGridView.AutoSize = false;
                dataGridView.VirtualMode = true;
                dataGridView.RowHeadersVisible = false;
                dataGridView.DataSource = ds.Tables[0];
                dataGridView.ReadOnly = false;
                dataGridView.AutoSize = true;
                dataGridView.RowHeadersVisible = true;
                dataGridView.Visible = true;
                return ds.Tables[0].Rows.Count.ToString() + " row(s) selected";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
