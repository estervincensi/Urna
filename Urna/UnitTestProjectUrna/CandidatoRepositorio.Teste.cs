using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Urna;

namespace UnitTestProjectUrna
{
    [TestClass]
    public class CandidatoRepositorioTeste
    {
        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarComNomeCompletoEmBranco()
        {
            Candidato c = new Candidato("","teste",new DateTime(2015-11-02),"12345",18,"abcd",18103,1,true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c, false);
            Assert.AreEqual(false,cadastrou);
        }

        //[TestMethod]
        //public void CadastrarCandidatoNaoPodeCadastrarComNomePopularEmBranco()
        //{
        //    Candidato c = new Candidato("teste", "", new DateTime(2015 - 11 - 02), "12345", 18, "abcd", 18103, 1, true);
        //    CandidatoRepositorio cr = new CandidatoRepositorio();
        //    bool cadastrou = cr.Cadastrar(c, false);
        //    Assert.AreEqual(false, cadastrou);
        //}
    }
}
