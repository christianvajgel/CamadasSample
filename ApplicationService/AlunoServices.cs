using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService
{
    public class AlunoServices
    {
        private AlunoRepository Repository { get; set; }

        public AlunoServices(AlunoRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Aluno> GetAll()
        {
            return Repository.GetAll();
        }

        public Aluno GetAlunoById(Guid id)
        {
            return Repository.GetAlunoById(id);
        }

        public void Save(Aluno aluno)
        {

            if (this.GetAlunoByEmail(aluno.Email) != null)
            {
                throw new Exception("Já existe um aluno com este email, por favor cadastre outro email.");
            }

            if (String.IsNullOrWhiteSpace(aluno.Email))
            {
                throw new Exception("Email em branco, por favor entre com um email válido.");
            }

            var anoAtual = DateTime.Now.Year;

            if ((anoAtual - aluno.DataNascimento.Year < 18))
            {
                throw new Exception("Para cadastrar um novo aluno ele deve ter no mínimo 18 anos.");
            }
            aluno.Status = Status.EM_CONFIRMACAO_EMAIL;
            //aluno.Id = Guid.NewGuid();

            Repository.Save(aluno);
        }

        public Aluno GetAlunoByEmail(string email)
        {
            return Repository.GetAlunoByEmail(email);
        }

        public void Delete(Guid id)
        {
            Repository.Delete(id);
        }

        public void Update(Guid id, Aluno aluno) 
        {
            Repository.Update(id, aluno);
        }
    }
}
