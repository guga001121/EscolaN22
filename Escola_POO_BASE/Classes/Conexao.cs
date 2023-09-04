using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_POO_BASE.Classes
{
    internal class Conexao
    {

        //conexão remota

        #region Variáveis

        //String de conexão                                            Informações CHUMBADAS - HardCode
        private static string _strConexao = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=EscolaN22;Integrated Security=True";

        //Variaveis de uso(podem ou não serem usadas ao decorrer do projeto)
        public SqlConnection conexao = new SqlConnection(_strConexao);
        public SqlCommand comando; //Armazenar a query
        public SqlDataAdapter da; //Adaptador para alguns componentes
        public SqlDataReader dr; //Recebe os select´s
        public DataSet ds; //trabalha com multiplas tabelas



        #endregion

        #region Construtores

        public Conexao(string query) 
        { 
            comando = new SqlCommand(query, conexao); //comando montado
            da = new SqlDataAdapter(query, conexao); //caso necessario, esta pronto
            ds = new DataSet(); //se necessario
        }

        #endregion

        #region Métodos
        //um metodo para abrir a conexao com o banco

        public void AbrirConexao()
        {
            if (conexao.State == ConnectionState.Open) 
            {
                conexao.Close();    
            } 
            conexao.Open(); 
            

        }
        public void FecharConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        #endregion
    }
}
