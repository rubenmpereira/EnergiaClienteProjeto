using Microsoft.Data.SqlClient;
using System.Data;
using EnergiaClienteDados.RequestModels;
using EnergiaClienteDominio;
using System.Reflection;
using System.Text;

namespace EnergiaClienteDados
{
    public class Database
    {
        private SqlConnection connection = new SqlConnection("Data Source=MSIRUBEN\\SQLEXPRESS;Initial Catalog=EnergiaClienteDados;Integrated Security=True;TrustServerCertificate=True");

        public List<Invoice> GetInvoices(GetInvoicesRequestModel requestModel)
        {
            //set parameters
            var param = new SqlParameter("habitacao", requestModel.habitacao);

            //execute stored procedure
            var response = RunSelectProcedure("UltimasFaturas", new SqlParameter[1] { param });

            //mapping
            var invoices = new List<Invoice>();
            foreach (DataRow row in response)
            {
                var invoice = new Invoice();
                invoice.number = row["numero"].ToString();
                invoice.startDate = DateTime.Parse(row["dataInicio"].ToString());
                invoice.endDate = DateTime.Parse(row["dataFim"].ToString());
                invoice.Paid = bool.Parse(row["pago"].ToString());
                invoice.Value = decimal.Parse(row["valor"].ToString());
                invoice.limitDate = DateTime.Parse(row["dataLimite"].ToString());
                invoice.habitation = int.Parse(row["idHabitacao"].ToString());
                invoice.document = Encoding.ASCII.GetBytes(row["documento"].ToString());
                invoices.Add(invoice);
            }

            return invoices;
        }

        private int Run(SqlCommand command)
        {
            command.Connection = connection;
            return command.ExecuteNonQuery();
        }

        private DataRowCollection RunGet(SqlCommand command)
        {
            command.Connection = connection;
            var dataAdapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count == 0)
                return null;

            return dataSet.Tables[0].Rows;
        }

        private DataRowCollection RunSelectProcedure(string procedure, SqlParameter[] parameters)
        {
            var dataAdapter = new SqlDataAdapter(procedure, connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddRange(parameters);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count == 0)
                return null;

            return dataSet.Tables[0].Rows;
        }
    }
}
