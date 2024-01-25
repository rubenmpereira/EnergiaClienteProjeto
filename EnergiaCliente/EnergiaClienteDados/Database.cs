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

        public dbResponse<Reading> GetReadings(GetReadingsRequestModel requestModel)
        {
            //set parameters
            var parameters = new SqlParameter[2] {
                new SqlParameter("habitacao", requestModel.habitation),
                new SqlParameter("quantidade", requestModel.quantity)
            };

            //execute stored procedure
            var response = RunSelectProcedure("UltimasLeituras", parameters);

            if (response.Count == 0)
                return new dbResponse<Reading> { error = true, errorMessage = "Not found", statusCode = 404 };

            //mapping
            var readings = new List<Reading>();
            foreach (DataRow row in response)
            {
                var reading = new Reading();
                reading.id = GetParam<int>(row["id"]);
                reading.vazio = GetParam<int>(row["vazio"]);
                reading.ponta = GetParam<int>(row["ponta"]);
                reading.cheias = GetParam<int>(row["cheias"]);
                reading.month = GetParam<int>(row["mes"]);
                reading.year = GetParam<int>(row["ano"]);
                reading.readingDate = GetParam<DateTime>(row["dataLeitura"]);
                reading.habitation = GetParam<int>(row["idHabitacao"]);
                reading.estimated = GetParam<bool>(row["estimada"]);

                readings.Add(reading);
            }

            return new dbResponse<Reading>
            {
                result = readings,
                error = false
            };
        }

        private T GetParam<T>(object value)
        {

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
