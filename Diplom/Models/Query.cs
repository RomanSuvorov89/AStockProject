using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Diplom.Models
{
    public class Query
    {
        static private string _conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\RuSH\\Desktop\\Подбор компьютерных комплектующих.mdb";

        static public List<ViewModel> Cpu()
        {
            int i = 0;
            //     ViewModel result = new ViewModel();
            List<ViewModel> result = new List<ViewModel>();
            using (OleDbConnection con = new OleDbConnection(_conn))
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = @"SELECT        Cpus.nameCpu, Sockets.socket, Cpus.coresCpu, Cpus.Price, Cpus.[Count], Manufacturers.Manufacture
                                    FROM            ((Cpus INNER JOIN
                                    Sockets ON Cpus.socketCpu = Sockets.id) INNER JOIN
                                    Manufacturers ON Cpus.idManufacture = Manufacturers.id)";
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ViewModel { id = i, cpu = reader[0].ToString(), socket = reader[1].ToString(), brand = reader[5].ToString(), core = reader[2].ToString(), price = Convert.ToInt32(reader[3]), count = Convert.ToInt32(reader[4]) });
                        i++;
                    }
                    reader.Close();
                    con.Close();
                }
                return result;
            }
        }

        static public List<ViewModel> MB()
        {
            int i = 0;
            string ask= @"SELECT        Manufacturers.Manufacture, MotherBoards.nameMB, RamType.typeMemory, FormFactorMB.nameFF, Sockets.socket, MotherBoards.Price, MotherBoards.[Count], slotBus.typeBus
                         FROM            (((((Manufacturers INNER JOIN
                         MotherBoards ON Manufacturers.id = MotherBoards.idManufacture) INNER JOIN
                         FormFactorMB ON MotherBoards.FFMB = FormFactorMB.id) INNER JOIN
                         RamType ON MotherBoards.typeRam = RamType.id) INNER JOIN
                         Sockets ON MotherBoards.socketMB = Sockets.id) INNER JOIN
                         slotBus ON MotherBoards.slotsBus = slotBus.id)";
            List<ViewModel> result = new List<ViewModel>();
            using (OleDbConnection con = new OleDbConnection(_conn))
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = ask;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ViewModel { id = i, Name = reader[1].ToString(), type = reader[2].ToString(), brand = reader[0].ToString(), other = reader[3].ToString(), socket = reader[4].ToString(), price = Convert.ToInt32(reader[5]), count = Convert.ToInt32(reader[6]), bus = reader[7].ToString() });
                        i++;
                    }
                    reader.Close();
                    con.Close();
                }
                return result;
            }
        }

        static public List<ViewModel> RAM()
        {
            int i = 0;
            string ask = @"SELECT        Rams.nameRam, Rams.capRam, Manufacturers.Manufacture, partsFreq.frequency, RamType.typeMemory, Rams.Price, Rams.[Count]
                         FROM            (((Manufacturers INNER JOIN
                         Rams ON Manufacturers.id = Rams.idManufacture) INNER JOIN
                         RamType ON Rams.typeRam = RamType.id) INNER JOIN
                         partsFreq ON Rams.freqRam = partsFreq.id)";
            List<ViewModel> result = new List<ViewModel>();
            using (OleDbConnection con = new OleDbConnection(_conn))
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = ask;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ViewModel { id = i, Name = reader[0].ToString(), cap = Convert.ToInt32(reader[1]), brand = reader[2].ToString(), frequency = Convert.ToInt32(reader[3]), price = Convert.ToInt32(reader[5]), type = reader[4].ToString(), count = Convert.ToInt32(reader[6]) });
                        i++;
                    }
                    reader.Close();
                    con.Close();
                }
                return result;
            }
        }

        static public List<ViewModel> Video()
        {
            int i = 0;
            string ask = @"SELECT        VideoCards.NameVideo, Manufacturers.Manufacture, RamType.typeMemory, slotBus.typeBus, VideoCards.DirectX, VideoCards.Price, VideoCards.[Count]
                         FROM            (((VideoCards INNER JOIN
                         Manufacturers ON VideoCards.idProizv = Manufacturers.id) INNER JOIN
                         RamType ON VideoCards.TypeMem = RamType.id) INNER JOIN
                         slotBus ON VideoCards.Bus = slotBus.id)";
            List<ViewModel> result = new List<ViewModel>();
            using (OleDbConnection con = new OleDbConnection(_conn))
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = ask;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ViewModel { id = i, Name=reader[0].ToString(),brand=reader[1].ToString(),type=reader[2].ToString(),bus=reader[3].ToString(),other=reader[4].ToString(),price= Convert.ToInt32(reader[5]),count=Convert.ToInt32(reader[6]) });
                        i++;
                    }
                    reader.Close();
                    con.Close();
                }
                return result;
            }
        }

        static public List<ViewModel> Box()
        {
            int i = 0;
            string ask = @"SELECT        Boxes.nameBox, FormFactorMB.nameFF, Manufacturers.Manufacture, Powers.NameBox AS Expr1, Powers.Watts, Boxes.Price, Boxes.[Count]
                         FROM            (((Powers INNER JOIN
                         Boxes ON Powers.id = Boxes.id) INNER JOIN
                         FormFactorMB ON Powers.id = FormFactorMB.id) INNER JOIN
                         Manufacturers ON Powers.id = Manufacturers.id)";
            List<ViewModel> result = new List<ViewModel>();
            using (OleDbConnection con = new OleDbConnection(_conn))
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = ask;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ViewModel { id = i, Name = reader[0].ToString(), type = reader[1].ToString(), brand = reader[2].ToString(), other=reader[3].ToString(), cap=Convert.ToInt32(reader[4]), price = Convert.ToInt32(reader[5]),  count = Convert.ToInt32(reader[6]) });
                        i++;
                    }
                    reader.Close();
                    con.Close();
                }
                return result;
            }
        }

        static public List<ViewModel> Audio()
        {
            int i = 0;
            string ask = @"SELECT        AudioCards.NameAudio, Manufacturers.Manufacture, slotBus.typeBus, AudioCards.Price, AudioCards.[Count]
                         FROM            ((Manufacturers INNER JOIN
                         AudioCards ON Manufacturers.id = AudioCards.idManufacture) INNER JOIN
                         slotBus ON AudioCards.Bus = slotBus.id)";
            List<ViewModel> result = new List<ViewModel>();
            using (OleDbConnection con = new OleDbConnection(_conn))
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = ask;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ViewModel { id = i, Name = reader[0].ToString(), brand = reader[1].ToString(), price = Convert.ToInt32(reader[3]), type = reader[2].ToString(), count = Convert.ToInt32(reader[4]) });
                        i++;
                    }
                    reader.Close();
                    con.Close();
                }
                return result;
            }
        }

        static public List<ViewModel> HDD()
        {
            int i = 0;
            string ask = @"SELECT        HDDs.nameHDD, HDDs.capatity, Manufacturers.Manufacture, HDDType.Type, HDDs.Price, HDDs.[Count]
                         FROM            ((HDDType INNER JOIN
                         HDDs ON HDDType.id = HDDs.typeHDD) INNER JOIN
                         Manufacturers ON HDDs.idManufacture = Manufacturers.id)";
            List<ViewModel> result = new List<ViewModel>();
            using (OleDbConnection con = new OleDbConnection(_conn))
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = ask;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ViewModel { id = i, Name = reader[0].ToString(),cap=Convert.ToInt32(reader[1]), brand = reader[2].ToString(), price = Convert.ToInt32(reader[4]), type = reader[3].ToString(), count = Convert.ToInt32(reader[5]) });
                        i++;
                    }
                    reader.Close();
                    con.Close();
                }
                return result;
            }
        }

        static public List<ViewModel> Power()
        {
            int i = 0;
            string ask = @"SELECT        Powers.NameBox, Manufacturers.Manufacture, Powers.Watts, Powers.Price, Powers.Count
                         FROM            (Powers INNER JOIN
                         Manufacturers ON Powers.id = Manufacturers.id)";
            List<ViewModel> result = new List<ViewModel>();
            using (OleDbConnection con = new OleDbConnection(_conn))
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = ask;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ViewModel { id = i, Name = reader[0].ToString(), brand = reader[1].ToString(), price = Convert.ToInt32(reader[3]), cap = Convert.ToInt32(reader[2]), count = Convert.ToInt32(reader[4]) });
                        i++;
                    }
                    reader.Close();
                    con.Close();
                }
                return result;
            }
        }

        static public List<ViewModel> Provider()
        {
            int i = 0;
            string ask = @"SELECT        Manufacture, Adress FROM            Manufacturers";
            List<ViewModel> result = new List<ViewModel>();
            using (OleDbConnection con = new OleDbConnection(_conn))
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = ask;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ViewModel { id = i, Name = reader[1].ToString(), brand = reader[0].ToString()});
                        i++;
                    }
                    reader.Close();
                    con.Close();
                }
                return result;
            }
        }

    }
}