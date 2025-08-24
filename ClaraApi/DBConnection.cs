using ClaraApi.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClaraApi
{
    public static class DBConnection
    {
        //private string connectionString = "Server=10.37.129.20:3306;Database=ClaraHack;User ID=sqladm;Password=Multiplan#1234;";
        //private static string connectionString = "Server=10.37.129.20;Database=ClaraHack;Uid=sqladm;Pwd=Multiplan#1234";
        //

        private static string connectionString = "Server=sql5.freesqldatabase.com;Database=sql5795955;Uid=sql5795955;Pwd=dCJui88MYR";
        public static void Test()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to MySQL database!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error connecting to MySQL: {ex.Message}");
                }
            }
        }

        public static List<Model.CPT> getAllCPTCodes()
        {
            List<Model.CPT> items = new List<Model.CPT>();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    //string query = "SELECT id, product_name, quantity FROM products WHERE product_name = @productName;";
                    string query = "SELECT * from CPT;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        //cmd.Parameters.AddWithValue("@productName", productName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //int id = reader.GetInt32("id");
                                //string name = reader.GetString("product_name");
                                //int quantity = reader.GetInt32("quantity");
                                //Console.WriteLine($"ID: {id}, Name: {name}, Quantity: {quantity}");
                                var dbItem = new Model.CPT();
                                dbItem.CPTCode = reader.ParseIntValue("CPTCode");
                                dbItem.Desc = reader.ParseStrValue("Desc");
                                dbItem.Category = reader.ParseStrValue("Category");
                                dbItem.BodyPart = reader.ParseStrValue("BodyPart");
                                dbItem.InjuryType = reader.ParseStrValue("InjuryType");
                                items.Add(dbItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return items;
        }

        public static List<Model.Member> getAllMembers()
        {
            List<Model.Member> items = new List<Model.Member>();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    //string query = "SELECT id, product_name, quantity FROM products WHERE product_name = @productName;";
                    string query = "SELECT * from Member;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        //cmd.Parameters.AddWithValue("@productName", productName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //int id = reader.GetInt32("id");
                                //string name = reader.GetString("product_name");
                                //int quantity = reader.GetInt32("quantity");
                                //Console.WriteLine($"ID: {id}, Name: {name}, Quantity: {quantity}");
                                var dbItem = new Model.Member();
                                dbItem.MemberId = reader.ParseIntValue("MemberId");
                                dbItem.FirstName = reader.ParseStrValue("FirstName");
                                dbItem.LastName = reader.ParseStrValue("LastName");
                                dbItem.MaxOutOfPocket = reader.ParseDoubleValue("MaxOutOfPocket");
                                dbItem.ExpiryDate = reader.ParseDateValue("ExpiryDate");
                                dbItem.Email = reader.ParseStrValue("Email");
                                dbItem.City = reader.ParseStrValue("City");
                                dbItem.State = reader.ParseStrValue("State");
                                dbItem.Copay = reader.ParseDoubleValue("Copay");
                                dbItem.CurrentPaidDeductible = reader.ParseDoubleValue("CurrentPaidDeductible");
                                dbItem.EligibilityValid = reader.ParseIntValue("EligibilityValid");
                                dbItem.GroupId = reader.ParseStrValue("GroupId");
                                dbItem.PayorId = reader.ParseIntValue("PayorId");
                                dbItem.Phone = reader.ParseStrValue("Phone");
                                dbItem.StreetAddress1 = reader.ParseStrValue("StreetAddress1");
                                dbItem.Zip = reader.ParseStrValue("Zip");
                                items.Add(dbItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return items;
        }

        public static List<Model.Network> getAllNetworks()
        {
            List<Model.Network> items = new List<Model.Network>();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    //string query = "SELECT id, product_name, quantity FROM products WHERE product_name = @productName;";
                    string query = "SELECT * from Network;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        //cmd.Parameters.AddWithValue("@productName", productName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //int id = reader.GetInt32("id");
                                //string name = reader.GetString("product_name");
                                //int quantity = reader.GetInt32("quantity");
                                //Console.WriteLine($"ID: {id}, Name: {name}, Quantity: {quantity}");
                                var dbItem = new Model.Network();
                                dbItem.Name = reader.ParseStrValue("Name");
                                dbItem.NetworkId = reader.ParseIntValue("NetworkId");
                                dbItem.Type = reader.ParseStrValue("Type");
                                items.Add(dbItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return items;
        }

        public static List<Model.Provider> getAllProviders()
        {
            List<Model.Provider> items = new List<Model.Provider>();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    //string query = "SELECT id, product_name, quantity FROM products WHERE product_name = @productName;";
                    string query = "SELECT * from Provider;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        //cmd.Parameters.AddWithValue("@productName", productName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //int id = reader.GetInt32("id");
                                //string name = reader.GetString("product_name");
                                //int quantity = reader.GetInt32("quantity");
                                //Console.WriteLine($"ID: {id}, Name: {name}, Quantity: {quantity}");
                                var dbItem = new Model.Provider();
                                dbItem.Name = reader.ParseStrValue("Name");
                                dbItem.StreetAddress = reader.ParseStrValue("StreetAddress1");
                                dbItem.Speciality = reader.ParseStrValue("StreetAddress1");
                                dbItem.Phone = reader.ParseStrValue("NAME");
                                dbItem.Email = reader.ParseStrValue("Email");
                                dbItem.NPINumber = reader.ParseStrValue("Phone");
                                dbItem.State = reader.ParseStrValue("State");
                                dbItem.City = reader.ParseStrValue("City");
                                dbItem.ProviderId = reader.ParseIntValue("ProviderId");
                                dbItem.ZipCode = reader.ParseStrValue("Zip");

                                var providerNetworkIds = getAllProviderNetworks().Where(x => x.ProviderId == dbItem.ProviderId).Select(x => x.NetworkId).ToArray();
                                if (providerNetworkIds?.Length > 0)
                                    dbItem.Networks = getAllNetworks().Where(x => providerNetworkIds.Contains(x.NetworkId)).ToList();

                                items.Add(dbItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return items;
        }

        public static List<Model.Payor> getAllPayors()
        {
            List<Model.Payor> items = new List<Model.Payor>();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    //string query = "SELECT id, product_name, quantity FROM products WHERE product_name = @productName;";
                    string query = "SELECT * from Payor;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        //cmd.Parameters.AddWithValue("@productName", productName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //int id = reader.GetInt32("id");
                                //string name = reader.GetString("product_name");
                                //int quantity = reader.GetInt32("quantity");
                                //Console.WriteLine($"ID: {id}, Name: {name}, Quantity: {quantity}");
                                var dbItem = new Model.Payor();
                                dbItem.StreetAddress1 = reader.ParseStrValue("StreetAddress1");
                                dbItem.NAME = reader.ParseStrValue("NAME");
                                dbItem.Email = reader.ParseStrValue("Email");
                                dbItem.Phone = reader.ParseStrValue("Phone");
                                dbItem.Type = reader.ParseStrValue("Type");
                                dbItem.PayorId = reader.ParseIntValue("PayorId");
                                items.Add(dbItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return items;
        }

        public static List<Model.Pricing> getAllPricings()
        {
            List<Model.Pricing> items = new List<Model.Pricing>();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    //string query = "SELECT id, product_name, quantity FROM products WHERE product_name = @productName;";
                    string query = "SELECT * from Pricing;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        //cmd.Parameters.AddWithValue("@productName", productName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //int id = reader.GetInt32("id");
                                //string name = reader.GetString("product_name");
                                //int quantity = reader.GetInt32("quantity");
                                //Console.WriteLine($"ID: {id}, Name: {name}, Quantity: {quantity}");
                                var dbItem = new Model.Pricing();
                                dbItem.PayorId = reader.ParseIntValue("PayorId");
                                dbItem.Payor = getAllPayors().FirstOrDefault(x => x.PayorId == dbItem.PayorId);
                                dbItem.PriceValidUntil = reader.ParseDateValue("PriceValidUntil");
                                dbItem.MaxPrice = reader.ParseDoubleValue("MaxPrice");
                                dbItem.MinPrice = reader.ParseDoubleValue("MinPrice");
                                dbItem.CPTCode = reader.ParseIntValue("CPTCode");
                                dbItem.CPT = getAllCPTCodes().FirstOrDefault(x => x.CPTCode == dbItem.CPTCode);
                                dbItem.PricingId = reader.ParseIntValue("PricingId");
                                dbItem.ProviderId = reader.ParseIntValue("ProviderId");
                                dbItem.Provider = getAllProviders().FirstOrDefault(x => x.ProviderId == dbItem.ProviderId);
                                items.Add(dbItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return items;
        }

        public static List<Model.ProviderNetwork> getAllProviderNetworks()
        {
            List<Model.ProviderNetwork> items = new List<Model.ProviderNetwork>();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    //string query = "SELECT id, product_name, quantity FROM products WHERE product_name = @productName;";
                    string query = "SELECT * from ProviderNetwork;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        //cmd.Parameters.AddWithValue("@productName", productName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //int id = reader.GetInt32("id");
                                //string name = reader.GetString("product_name");
                                //int quantity = reader.GetInt32("quantity");
                                //Console.WriteLine($"ID: {id}, Name: {name}, Quantity: {quantity}");
                                var dbItem = new Model.ProviderNetwork();
                                dbItem.Active = reader.ParseIntValue("Active");
                                dbItem.ProviderNetworkId = reader.ParseIntValue("ProviderNetworkId");
                                dbItem.NetworkId = reader.ParseIntValue("NetworkId");
                                dbItem.LastModifiedDate = reader.ParseDateValue("LastModifiedDate");
                                dbItem.CreateDate = reader.ParseDateValue("CreateDate");
                                dbItem.ProviderId = reader.ParseIntValue("ProviderId");
                                items.Add(dbItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return items;
        }

        private static DateTime ParseDateValue(this MySqlDataReader reader, string colName)
        {
            try
            {
                return reader.GetDateTime(colName);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }
        private static int ParseIntValue(this MySqlDataReader reader, string colName)
        {
            try
            {
                return reader.GetInt32(colName);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private static double ParseDoubleValue(this MySqlDataReader reader, string colName)
        {
            try
            {
                return reader.GetDouble(colName);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private static string ParseStrValue(this MySqlDataReader reader, string colName)
        {
            try
            {
                return reader.GetString(colName);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
