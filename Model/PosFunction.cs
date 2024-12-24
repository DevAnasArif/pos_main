using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_main.Model
{
    public interface PosFunction
    {
        string UserDetail(string Email, string Password);
        string UserLogin(string Email, string Password);
        bool SignUp(string UserName, string email, string Password, string TableName, int OrderCount);
        void NewUser(string tableName);
        void conection(string Ordername, int Quanity, int Price, string tableName);
        void Update(string Ordername, int Quanity, int Price, string tableName);
        int check(string Ordername,string tableName);
        bool MainshowData(DataGridView DGV, string query);
        void Detail(DataGridView DGV, string tableName);
        bool ShowingData(DataGridView DGV, string tableName);
        void Print(DataGridView DGV, string tableName);
        void Store(string Address, string phone, string recievetext);
        double total(double total, DataGridView DGV, Label label);
        void Check_the_Stock(string textbox, string product, int price, DataGridView DGV,string tableName);
        void Delete(string tableName);
        void PrintSlip(DataGridView DGV, PrintPageEventArgs e, string name, string phone, string Address, double total);
        void admintable(DataGridView DGV);
        void AdminUpdate(int id, string username, string email, string status);
        void DeleteRow(int id, string ordernumber);
        int Ordercheck();
        int tablesearch(DataGridView AdminGV, DateTime dtFromDate, DateTime dtToDate);
    }
}
