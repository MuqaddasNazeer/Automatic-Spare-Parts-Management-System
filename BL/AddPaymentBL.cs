using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.BL
{
    public class AddPaymentBL
    {
        private int AccountNo;
        private int OrderNo;
        private string PaymentType;


        public AddPaymentBL(int accountNo, int orderNo, string paymentType)
        {
            AccountNo = accountNo;
            OrderNo = orderNo;
            PaymentType = paymentType;
        }

        public static string AddPayment(AddPaymentBL m, string con)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Payment([AccountNo.],[OrderNo.],PaymentType) values(@AccountNo,@OrderNo,@PaymentType)", conn);

            cmd.Parameters.AddWithValue("@AccountNo", m.AccountNo);
            cmd.Parameters.AddWithValue("@OrderNo", m.OrderNo);
            cmd.Parameters.AddWithValue("@PaymentType", m.PaymentType);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }
    }
}