using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using Service.Repository.Core;
using GRAMPRO.Platform.Utility.Model.General;
using GRAMPRO.Platform.Utility.Model.Authentication;


namespace Service.Repository.Authenticate
{
    public class AuthenticateRepository : DBRepositoryBase, IAuthenticateRepository
    {

       /* public IEnumerable<RegisterModel> getRegister()
        {
            var authList = new List<RegisterModel>();
            SqlCommand command = base.CreateCommand("usp_get_auth", CommandType.StoredProcedure) as SqlCommand;
            if (command != null)
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null && (reader as SqlDataReader) != null && (reader as SqlDataReader).HasRows)
                    {
                        while (reader.Read())
                        {
                            authList.Add(new RegisterModel
                            {
                                Id = reader.GetString("Id"),
                                Username = reader.GetString("UserName"),
                                Email = reader.GetString("Email"),
                                DisplayName = reader.GetString("DisplayName"),
                                PhoneNumber = reader.GetString("PhoneNumber"),
                                EntityId = reader.GetInt32("Entity_Id"),
                                EntityName = reader.GetString("Entity_Name"),
                                //UserRoleId = reader.GetInt32("UserRoleId"),
                               // UserType = reader.GetString("UserType"),
                               //Status = reader.GetInt16("Status")



                            }


                            );

                        }

                    }

                }


            }
            return authList;
        }

        public RegisterModel getRegisterForEdit(string Id)
        {

            RegisterModel registerModel = new RegisterModel();
            SqlCommand command = base.CreateCommand("usp_get_register_for_edit", CommandType.StoredProcedure) as SqlCommand;
            if (command != null)
            {
                command.Parameters.AddWithValue("@register_id", Id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null && (reader as SqlDataReader) != null && (reader as SqlDataReader).HasRows)
                    {
                        while (reader.Read())
                        {
                            registerModel = new RegisterModel()
                            {
                                Id = reader.GetString("Id"),
                                Username = reader.GetString("UserName"),
                                Email = reader.GetString("Email"),
                                // Password=reader.GetString("Password"),
                                DisplayName = reader.GetString("DisplayName"),
                                PhoneNumber = reader.GetString("PhoneNumber"),
                                EntityId = reader.GetInt32("Entity_Id"),
                                EntityName = reader.GetString("Entity_Name"),
                               // UserRoleId = reader.GetInt32("UserRoleId"),
                                //UserType = reader.GetString("UserType"),
                               // Status = reader.GetInt16("Status")



                            };
                        }
                    }


                }


            }
            return registerModel;
        }*/


    }
}
