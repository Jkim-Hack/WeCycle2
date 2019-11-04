using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace WeCycle
{
    class SQLManager
    {
        public static SqlConnectionStringBuilder sqlConnectionString(String dataSource, String userID, String password, String dataBaseName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = dataSource;
            builder.UserID = userID;
            builder.Password = password;
            builder.InitialCatalog = dataBaseName;


            return builder;
        }

        private static SqlConnection getNewConnection(SqlConnectionStringBuilder connectionInfo)
        {
            return new SqlConnection(connectionInfo.ConnectionString);
        }


        public static User readSingleUserData(String user_name, SqlConnectionStringBuilder connectionInfo)
        {
            User user = null;

            try
            {
                using (SqlConnection connection = getNewConnection(connectionInfo))
                {
                    connection.Open();
                    StringBuilder instruction = new StringBuilder();
                    instruction.Append("SELECT * FROM users WHERE user_name = " + "'" + user_name + "'");

                    using (SqlCommand command = new SqlCommand(instruction.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return user;
        }

        public static void insertSingleUser(User user, SqlConnectionStringBuilder connectionInfo)
        {
            try
            {
                using (SqlConnection connection = getNewConnection(connectionInfo))
                {
                    connection.Open();
                    StringBuilder instruction = new StringBuilder();
                    instruction.Append("INSERT INTO users VALUES(" + "'" + user.User_Name + "'," + "'" + user.User_Password + "'," + "'" + user.User_Email + "'," + "'" + user.User_PhoneNumber + "'," + "'" + user.User_CoinCount + "'," + "'" + user.User_Num_ChallengeCompleted + "'" + ")");

                    using (SqlCommand command = new SqlCommand(instruction.ToString(), connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("REEEEEEE");
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void insertFriendPair(String userName1, String userName2, SqlConnectionStringBuilder connectionInfo)
        {
            try
            {
                using (SqlConnection connection = getNewConnection(connectionInfo))
                {
                    connection.Open();
                    StringBuilder instruction = new StringBuilder();

                    instruction.Append("INSERT INTO friendrelations VALUES(" + "'" + userName1 + "'," + "'" + userName2 + "'" + ")");
                    using (SqlCommand command = new SqlCommand(instruction.ToString(), connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void updateCoins(User user, int coinIncrement, SqlConnectionStringBuilder connectionInfo)
        {
            try
            {
                using (SqlConnection connection = getNewConnection(connectionInfo))
                {
                    connection.Open();
                    StringBuilder instruction = new StringBuilder();

                    int newCoinCount = user.User_CoinCount + coinIncrement;

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    instruction.Append("UPDATE users SET user_coincoint = " + "'" + newCoinCount + "'" + "WHERE user_name = " + "'" + user.User_Name + "'"  +  ")" );
                    using (SqlCommand command = new SqlCommand(instruction.ToString(), connection))
                    {
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }


    }
}