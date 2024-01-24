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

        public dbResponse<Invoice> GetInvoices(GetInvoicesRequestModel requestModel)
        {
            //set parameters
            var param = new SqlParameter("habitacao", requestModel.habitation);

            //execute stored procedure
            var response = RunSelectProcedure("UltimasFaturas", new SqlParameter[1] { param });

            if (response.Count == 0)
                return new dbResponse<Invoice> { error = true, errorMessage = "Not found", statusCode = 404 };

            //mapping
            var invoices = new List<Invoice>();
            foreach (DataRow row in response)
            {
                var invoice = new Invoice();
                invoice.number = GetParam<string>(row["numero"]);
                invoice.startDate = GetParam<DateTime>(row["dataInicio"]);
                invoice.endDate = GetParam<DateTime>(row["dataFim"]);
                invoice.Paid = GetParam<bool>(row["pago"]);      
                invoice.Value = GetParam<decimal>(row["valor"]);
                invoice.limitDate = GetParam<DateTime>(row["dataLimite"]);
                invoice.habitation = GetParam<int>(row["idHabitacao"]);
                invoice.document = Encoding.ASCII.GetBytes(row["documento"].ToString());
                invoices.Add(invoice);
            }

            return new dbResponse<Invoice>
            {
                result = invoices,
                error = false
            };
        }

        private T GetParam<T>(object value) {

            string param = value.ToString();

            T result;

            try
            {
               result = (T)Convert.ChangeType(param, typeof(T));
            }
            catch
            {
                result = default(T);
            }

            return result;
        }

        private DataRowCollection RunSelectProcedure(string procedure, SqlParameter[] parameters)
        {
            var dataAdapter = new SqlDataAdapter(procedure, connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddRange(parameters);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            return dataSet.Tables[0].Rows;
        }
    }
}
