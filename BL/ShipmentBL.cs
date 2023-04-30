using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.BL
{
    public class ShipmentBL
    {
        private string containerNo;
        private string sealNo;
        private string vehicleNo;
        private int id;
        private int volume;

        public ShipmentBL()
        {
        }

        public ShipmentBL(string containerNo, string sealNo, string vehicleNo, int id, int volume)
        {
            this.containerNo = containerNo;
            this.sealNo = sealNo;
            this.vehicleNo = vehicleNo;
            this.id = id;
            this.volume = volume;
        }

        public static string goForShipment(ShipmentBL p, string con)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Shipment([ContainerNo],[VehicleNo],[SealNo],[Volume],[PackingListId],[Date]) values(@ContainerNo,@VehicleNo,@SealNo,@Volume,@PackingListId,@Date)", conn);

            cmd.Parameters.AddWithValue("@ContainerNo", p.containerNo);
            cmd.Parameters.AddWithValue("@Date", DateTime.Today.ToString());
            cmd.Parameters.AddWithValue("@VehicleNo", p.vehicleNo);
            cmd.Parameters.AddWithValue("@SealNo", p.sealNo);
            cmd.Parameters.AddWithValue("@Volume", p.volume);
            cmd.Parameters.AddWithValue("@PackingListId", p.id);

            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }
    }
}