using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using Service.Repository.Core;
using Service.Repository.Operations;
using GRAMPRO.Platform.Utility.Model.Operations;

namespace Service.Repository.Operations
{
    public class TicketRepository : DBRepositoryBase, ITicketRepository
    {

        public IEnumerable<TicketCount> getticketcount()
        {
            var ticketList = new List<TicketCount>();
            SqlCommand command = base.CreateCommand("usp_getTicketCount", CommandType.StoredProcedure) as SqlCommand;
            if (command != null)
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null && (reader as SqlDataReader) != null && (reader as SqlDataReader).HasRows)
                    {
                        while (reader.Read())
                        {
                            ticketList.Add(new TicketCount
                            {
                                Status_Id = !reader.IsDBNull("Status_Id") ? reader.GetInt32("Status_Id") : 0,
                                Status = !reader.IsDBNull("Status") ? reader.GetString("Status") : "",
                                TotalCount = !reader.IsDBNull("TotalCount") ? reader.GetInt32("TotalCount") : 0,
                                TotalTicketCount = !reader.IsDBNull("TotalTicketCount") ? reader.GetInt32("TotalTicketCount") :0,
                                

                            }


                            );

                        }

                    }

                }


            }
            return ticketList;
        }
    }
}

//         public Assets GetAssetForEdit(int assetId)
//         {

//             Assets assets = new Assets();
//             SqlCommand command = base.CreateCommand("usp_get_asset_for_edit", CommandType.StoredProcedure) as SqlCommand;
//             if (command != null)
//             {
//                 command.Parameters.AddWithValue("@asset_id", assetId);
//                 using (SqlDataReader reader = command.ExecuteReader())
//                 {
//                     if (reader != null && (reader as SqlDataReader) != null && (reader as SqlDataReader).HasRows)
//                     {
//                         while (reader.Read())
//                         {
//                             assets = new Assets()
//                             {
//                                 AssetId = !reader.IsDBNull("asset_id") ? reader.GetInt32("asset_id") : 0,
//                                 AssetTypeId = !reader.IsDBNull("asset_type_id") ? reader.GetInt32("asset_type_id") : 0,
//                                 AssetTypeName = !reader.IsDBNull("asset_type_name") ? reader.GetString("asset_type_name") : "",
//                                 AssetName = !reader.IsDBNull("asset_name") ? reader.GetString("asset_name") : "",
//                                 StatusId = !reader.IsDBNull("status_id") ? reader.GetInt32("status_id") : 0,
//                                 UserName = reader.GetString("username"),
//                                 Password = reader.GetString("password"),
//                                 SerialNumber = !reader.IsDBNull("serial_number") ? reader.GetString("serial_number") : "",
//                                 SimNumber = !reader.IsDBNull("serial_number") ? reader.GetString("sim_number") : "",
//                                 MtmNumber = !reader.IsDBNull("mtm_number") ? reader.GetString("mtm_number") : "",
//                                 BrandId = !reader.IsDBNull("brand_id") ? reader.GetInt32("brand_id") : 0,
//                                 BrandName = !reader.IsDBNull("brand_name") ? reader.GetString("brand_name") : "",
//                                 DateOfPurchase = reader.GetDateTime("date_of_purchase"),
//                                  VendorId = !reader.IsDBNull("vendor_id") ? reader.GetInt32("vendor_id") : 0,
//                                 VendorName = !reader.IsDBNull("vendor_name") ? reader.GetString("vendor_name") : "",
//                                 WarrantyStartDate = reader.GetDateTime("warranty_start_date"),
//                                 WarrantyEndDate = reader.GetDateTime("warranty_end_date"),
//                                 cost = !reader.IsDBNull("cost") ? reader.GetDecimal("cost") : 0,
//                                 ServiceStatus = reader.GetByte("service_status"),
//                                 OsStatus = reader.GetBoolean("os_status"),
//                                 ExtendedServiceStatus = reader.GetByte("extended_service_status"),
//                                 Remarks = reader.GetString("remarks"),
//                                 Status = reader.GetString("Status"),
//                                 PackStartDate=reader.GetDateTime("pack_start_date"),
//                                 PackEndDate=reader.GetDateTime("pack_end_date"),
//                                 RecurringDate=reader.GetInt32("recurring_date"),
//                                 InvoiceNumber=reader.GetString("invoice_number")



//                             };
//                         }
//                     }


//                 }


//             }
//             return assets;
//         }


//     }
// }
