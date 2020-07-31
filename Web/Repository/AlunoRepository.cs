using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Repository
{
    public class AlunoRepository
    {
        private static List<Aluno> Alunos { get; set; }

        public List<Aluno> GetAll() 
        {
            return Alunos;
        }

        public Aluno GetAlunoById(Guid id) 
        {
            return Alunos.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Aluno aluno) 
        {
            Alunos.Add(aluno);
        }

        public void Delete(Guid id) 
        {
            var aluno = this.GetAlunoById(id);

            if (aluno != null) 
            {
                Alunos.Remove(aluno);
            }
        }
    }
}
