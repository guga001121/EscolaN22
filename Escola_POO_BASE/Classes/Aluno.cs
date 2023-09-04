﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_POO_BASE.Classes
{
    public class Aluno : Usuario
    {
        #region Propriedades
        public DateTime DtMatricula { get; set; }
        #endregion

        #region Construtores
        public Aluno()
        {
        }

        public Aluno(int id, string nome, DateTime dtNascimento, DateTime dtMatricula, string email, string senha, bool ativo) : base(id, nome, dtNascimento, email, senha, ativo)
        {
            DtMatricula = dtMatricula;
        }
        #endregion

        #region Métodos

        public void Cadastrar(List<Aluno> alunos)
        {
            string query = string.Format($"INSERT INTO Aluno VALUES('{Nome}','{DtNascimento}','{DtMatricula}','{Email}','{Crypto.Sha256("123")}',1)");
            query += "; select SCOPE_IDENTITY()I";
            Conexao cn = new Conexao(query);

            Aluno usuario = new Aluno();

            try
            {
                cn.AbrirConexao();
                Id = Convert.ToInt32(cn.comando.ExecuteScalar());
                alunos.Add(this);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FecharConexao();
            }
        }

        public void Alterar()
        {
            string query = string.Format($"UPDATE Aluno SET Nome = '{Nome}',DtNascimento = '{DtNascimento}' ,DtMatricula = '{DtMatricula}',Email = '{Email}' where Id = 4 ");
            Conexao cn = new Conexao(query);
            try
            {
                cn.AbrirConexao();
                cn.comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.FecharConexao(); }
        }


        public void Excluir()
        {
            string query = string.Format($"update Aluno set ativo = 0 where id = {Id}");
            Conexao cn = new Conexao(query);

            try
            {
                cn.AbrirConexao();
                cn.comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FecharConexao();
            }
        }


        public static List<Aluno> Buscar(List<Aluno> alunos,int indexCbbBuscar,string texto)
        {
            switch (indexCbbBuscar)
            {
                case 0:
                    //Busca por nome

                    return  alunos.Where(a => a.Nome.ToUpper().Contains(texto.ToUpper())).ToList();

                    //breal; quando não for return, é obrigatorio o uso do break
                    
                    case 1:
                    //Busca por Email

                    return alunos.Where(a => a.Email.Contains(texto)).ToList();


                    
                    case 2:
                    //Busca por Matrícula (Id)

                    return alunos.Where(a => a.Id == Convert.ToInt32(texto)).ToList();

                    

                default:
                    //Retornar a lista sem filtro

                    return alunos;
                   
            }
        }


        #endregion
    }
    


}
 