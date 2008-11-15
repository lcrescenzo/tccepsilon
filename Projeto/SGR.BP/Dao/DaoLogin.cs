using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    class DaoLogin : IDao<Login>
    {
        
        public int Incluir(Login objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("sp_Login_i", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }

        public void Incluir(Login objeto, IDbConnection connection)
        {
            using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Login_i", ParametrosIncluir(objeto)))
            {
                DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Incluir);
            }
        }

        public void Alterar(Login objeto)
        {
            DaoUtil.Execute("sp_Login_u", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Login objeto, IDbConnection connection)
        {
            using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Login_d", ParametrosExcluir(objeto)))
            {
                DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Excluir);
            }
        }

        public void Excluir(Login objeto)
        {
            DaoUtil.Execute("sp_Login_d", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public void Carregar(int pId, Login objeto)
        {
            DaoUtil.Carregar("sp_LoginById_s", pId, "p_idUsuario", objeto);
            if (objeto.Senha == null)
            {
                throw new SGRErroException("Usuário não encontrado!");
            }
        }

        public void Autenticar(string login, string senha, Login objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                try
                {
                    connection.Open();

                    IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_AutenticarLogin_s", ParametrosAutenticar(objeto));
                    IDataReader reader = DaoUtil.Execute(comm);
                    if (reader.Read())
                    {
                        objeto.PreencheObjeto(reader);
                    }
                    else
                    {
                        throw new SGRErroException("Usuário ou Senha inválidos!");
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void CarregarPorEmail(string login, string email, Login objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                try
                {
                    connection.Open();

                    IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_AutenticarLoginEmail_s", ParametrosCarregarPorEmail(login, email));
                    IDataReader reader = DaoUtil.Execute(comm);
                    if (reader.Read())
                    {
                        objeto.PreencheObjeto(reader);
                    }
                    else
                    {
                        throw new SGRErroException("Usuário e e-mail inválidos!");
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private List<IDataParameter> ParametrosCarregarPorEmail(string usuario, string email)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_login", DbType.String, usuario));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_email", DbType.String, email));
            return parameters;
        }

        private List<IDataParameter> ParametrosAutenticar(Login objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_login", DbType.String, objeto.Usuario));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_senha", DbType.String, objeto.Senha));
            return parameters;
           
        }

        public List<IDataParameter> ParametrosIncluir(Login objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_login", DbType.String, objeto.Usuario));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_senha", DbType.String, objeto.Senha));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(Login objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Login objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_login", DbType.String, objeto.Usuario));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_senha", DbType.String, objeto.Senha));
            return parameters;
        }

    }
}
