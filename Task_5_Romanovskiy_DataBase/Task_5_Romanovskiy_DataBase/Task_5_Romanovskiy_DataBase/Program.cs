using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Romanovskiy_DataBase
{
    class Program
    {
        const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""..\..\..\DB\db1.mdb""";

        static void Main(string[] args)
        {

            OleDbDataReader reader = null;
            OleDbConnection cnn = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand();
            command = cnn.CreateCommand();
            command.CommandText = "SELECT (int(abs(x2-x1)+0.5)) AS len, Count(*) AS num  FROM Coordinates GROUP BY (int(abs(x2-x1)+0.5)) ORDER BY (int(abs(x2-x1)+0.5)) ";

            Dictionary<int, int> listLenghtCount = new Dictionary<int, int>();
            cnn.Open();

            try
            {
                using (reader = command.ExecuteReader())
                {
                    // формирование коллекции вида (len; num), где len – длина отрезка, округлённая до целого числа, num – количество отрезков длины len. 
                    while (reader.Read())
                    {
                        listLenghtCount.Add((int)reader.GetDouble(0), reader.GetInt32(1));
                    }
                    reader.Close();

                    //Список отсортировать по возрастанию поля len
                    listLenghtCount.OrderBy(x => x.Key);
                    foreach (int len in listLenghtCount.Keys)
                    {
                        Console.WriteLine(len + ";" + listLenghtCount[len]);
                    }
                    Console.WriteLine();

                    // очистка таблицы Frequencies
                    command.CommandText = "DELETE FROM Frequencies ";
                    command.ExecuteNonQuery();

                    //Сохранить получившийся список в таблицу Frequencies
                    command.CommandText = "INSERT INTO Frequencies VALUES (@Len,@num)";
                    command.Parameters.Add("@Len", OleDbType.Integer);
                    command.Parameters["@Len"].Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.Add("@num", OleDbType.Integer);
                    command.Parameters["@num"].Direction = System.Data.ParameterDirection.Input;
                    foreach (int len in listLenghtCount.Keys)
                    {
                        command.Parameters["@len"].Value = len;
                        command.Parameters["@num"].Value = listLenghtCount[len];
                        command.ExecuteNonQuery();
                    }

                    //Используя SQL запрос, найти записи в Frequencies, в которых len больше num
                    command.CommandText = "Select * from Frequencies where len > num";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["len"] + ";" + reader["num"]);
                    }

                }
            }
            catch (OleDbException e)
            {
                Console.WriteLine(e.Message + "  OleDb exception");
            }
            catch (ArgumentException ea)
            {
                Console.WriteLine(ea.Message + "  Argument exception");

            }
            catch (IndexOutOfRangeException ei)
            {
                Console.WriteLine(ei.Message + "  Index out of range ");

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                if (reader != null) reader.Dispose();
                if (command != null) command.Dispose();
                if (cnn != null) cnn.Dispose();
            }
            cnn.Close();

        }
    }
}
