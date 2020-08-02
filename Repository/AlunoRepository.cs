using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain;
using Repository.Context;

namespace Repository
{
    public class AlunoRepository
    {
        //private static List<Aluno> Alunos { get; set; } = new List<Aluno>();

        private InfnetContext Context { get; set; }

        public AlunoRepository(InfnetContext context)
        {
            this.Context = context;
        }

        //private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Aluno> GetAll() 
        {
            return Context.Alunos.AsEnumerable();

            //using (SqlConnection connection = new SqlConnection(this.ConnectionString)) 
            //{
            //    return connection.Query<Aluno>("SELECT * FROM ALUNO").ToList();
            //}

            //return Alunos;
        }

        public Aluno GetAlunoById(Guid id) 
        {
            return Context.Alunos.FirstOrDefault(x => x.Id == id);

            //using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            //{
            //    return connection.QuerySingleOrDefault<Aluno>("SELECT * FROM ALUNO WHERE ID = @P1", new { P1 = id });
            //}

            //return Alunos.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Aluno aluno) 
        {
            this.Context.Alunos.Add(aluno);
            this.Context.SaveChanges();

            //using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            //{
            //    connection.Execute(@"INSERT INTO ALUNO(ID, NOME, MATRICULA, EMAIL, STATUS, DATANASCIMENTO) 
            //                                VALUES(@P1,@P2,@P3,@P4,@P5,@P6)", 
            //                                new { P1 = aluno.Id, P2 = aluno.Nome, P3 = aluno.Matricula, 
            //                                      P4 = aluno.Email, P5 = aluno.Status, P6 = aluno.DataNascimento });
            //}

            //Alunos.Add(aluno);
        }

        public Aluno GetAlunoByEmail(string email) 
        {
            return Context.Alunos.FirstOrDefault(x => x.Email == email);

            //using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            //{
            //    return connection.QuerySingleOrDefault<Aluno>("SELECT * FROM ALUNO WHERE EMAIL = @P1", new { P1 = email });
            //}

            //return Alunos.FirstOrDefault(x => x.Email == email);
        }

        public void Delete(Guid id) 
        {
            var aluno = Context.Alunos.FirstOrDefault(x => x.Id == id);
            this.Context.Alunos.Remove(aluno);
            this.Context.SaveChanges();

            //using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            //{
            //    connection.Execute("DELETE FROM ALUNO WHERE ID = @P1", new { P1 = id });
            //}

            //var aluno = this.GetAlunoById(id);

            //if (aluno != null) 
            //{
            //    Alunos.Remove(aluno);
            //}
        }

        public void Update(Guid id, Aluno aluno) 
        {
            var alunoOld = Context.Alunos.FirstOrDefault(x => x.Id == id);

            alunoOld.DataNascimento = aluno.DataNascimento;
            alunoOld.Email = aluno.Email;
            alunoOld.Matricula = aluno.Matricula;
            alunoOld.Status = aluno.Status;
            alunoOld.Nome = aluno.Nome;
            alunoOld.CPF = aluno.CPF;

            Context.Alunos.Update(alunoOld);
            this.Context.SaveChanges();
        }
    }
}
