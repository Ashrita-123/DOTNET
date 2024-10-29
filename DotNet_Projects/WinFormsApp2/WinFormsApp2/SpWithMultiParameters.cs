using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class SpWithMultiParameters : Form
    {
        SqlConnection con = new SqlConnection("Server =DESKTOP-5JT3T8O\\ASHRITA;Database = EmployeeDB;User Id = sa;Password=user123;Trusted_Connection=True;TrustServerCertificate = True;");
        SqlCommand cmd; SqlParameter p1;SqlDataReader dr;
        public SpWithMultiParameters()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SPEmp_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            p1 = new SqlParameter("@PEmpId", SqlDbType.Int);
            p1.Value = Convert.ToInt32(txtEmpId.Text);
            cmd.Parameters.Add(p1);

            p1 = new SqlParameter("@PEmpName", SqlDbType.VarChar);
            p1.Value = textEmpName.Text;
            cmd.Parameters.Add(p1);


            p1 = new SqlParameter("@PEmpDesig", SqlDbType.VarChar);
            p1.Value = txtEmpDesig.Text;
            cmd.Parameters.Add(p1);

            p1 = new SqlParameter("@PEmpDOJ", SqlDbType.DateTime);
            p1.Value = Convert.ToDateTime(txtEmpDoj.Text);
            cmd.Parameters.Add(p1);

            p1 = new SqlParameter("@PEmpSal", SqlDbType.Int);
            p1.Value = Convert.ToInt32(txtEmpSal.Text);
            cmd.Parameters.Add(p1);

            p1 = new SqlParameter("@PEmpDept", SqlDbType.Int);
            p1.Value = Convert.ToInt32(txtEmpDeptNo.Text);
            cmd.Parameters.Add(p1);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(i + "Record(s) Inserted");


        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("SPEmp_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            p1 = new SqlParameter("@EmpId", SqlDbType.Int);
            p1.Value = Convert.ToInt32(txtEmpId.Text);
            cmd.Parameters.Add(p1);

            p1 = new SqlParameter("@PEmpName", SqlDbType.VarChar);
            p1.Value = textEmpName.Text;
            cmd.Parameters.Add(p1);

            p1 = new SqlParameter("@PEmpDesg", SqlDbType.VarChar);
            p1.Value = txtEmpDesig.Text;
            cmd.Parameters.Add(p1);

            p1 = new SqlParameter("@PEmpDOJ", SqlDbType.DateTime);
            p1.Value = Convert.ToDateTime(txtEmpDoj.Text);
            cmd.Parameters.Add(p1);

            p1 = new SqlParameter("@PEmpSal", SqlDbType.Int);
            p1.Value = Convert.ToInt32(txtEmpSal.Text);
            cmd.Parameters.Add(p1);

            p1 = new SqlParameter("@PEmpDept", SqlDbType.Int);
            p1.Value = Convert.ToInt32(txtEmpDeptNo.Text);
            cmd.Parameters.Add(p1);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(i + "Record(s)Updated");
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SPEmp_Del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            p1.Value = Convert.ToInt32(txtEmpId.Text);
            cmd.Parameters.Add(p1);
            p1 = new SqlParameter("@PEmpId", SqlDbType.Int);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(i + "record(S)deleted");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SP_Find", con);
            cmd.CommandType = CommandType.StoredProcedure;
            p1.Value = Convert.ToInt32(txtEmpId.Text);
            cmd.Parameters.Add(p1);
            p1 = new SqlParameter("@PEmpId", SqlDbType.Int);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                txtEmpId.Text = dr[0].ToString();
                textEmpName.Text = dr[1].ToString();
                txtEmpDesig.Text = dr[2].ToString();
                txtEmpDoj.Text = dr[3].ToString();
                txtEmpSal.Text = dr[4].ToString();
                txtEmpDeptNo.Text = dr[5].ToString();
            }
            else
            {
                MessageBox.Show("recoreds not found");
                dr.Close();
                con.Close();

            }

        } 
        //private void txtEmpId_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtEmpId_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void SpWithMultiParameters_Load(object sender, EventArgs e)
        //{

        //}
    }
}
