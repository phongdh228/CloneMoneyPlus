using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Wallet
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool createDatabase()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "walletDB.db");

                var connection = new SQLiteConnection(path);
                connection.CreateTable<WalletInfo>();
                connection.CreateTable<Payment>();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddNewWallet(WalletInfo walletInfo)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "walletDB.db");

                var connection = new SQLiteConnection(path);

                connection.Insert(walletInfo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<WalletInfo> GetWallets()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "walletDB.db");

                var connection = new SQLiteConnection(path);
                return connection.Table<WalletInfo>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<WalletInfo> GetOneWallet(int walletId)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "walletDB.db");

                var connection = new SQLiteConnection(path);
                return connection.Query<WalletInfo>("select * from WalletInfo where Id=" + walletId.ToString());
            }
            catch
            {
                return null;
            }
        }
        public bool UpdateOneWallet(WalletInfo wallet)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "walletDB.db");

                var connection = new SQLiteConnection(path);
                connection.Update(wallet);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteOneWallet(WalletInfo wallet)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "walletDB.db");

                var connection = new SQLiteConnection(path);
                connection.Delete(wallet);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddNewPayment(Payment payment)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "walletDB.db");

                var connection = new SQLiteConnection(path);

                connection.Insert(payment);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Payment> GetPayments()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "walletDB.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<Payment>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteOnePayment(Payment payment)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "walletDB.db");

                var connection = new SQLiteConnection(path);
                connection.Delete(payment);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
