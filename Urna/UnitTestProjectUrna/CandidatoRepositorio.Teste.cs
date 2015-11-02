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

        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarComNomePopularEmBranco()
        {
            Candidato c = new Candidato("teste", "", new DateTime(2015 - 11 - 02), "12345", 18, "abcd", 18103, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c, false);
            Assert.AreEqual(false, cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarComNomePopularIgualOutroRegistroDaTabela()
        {
            Candidato c = new Candidato("teste", "Pedro II", new DateTime(2015 - 11 - 02), "12345", 18, "abcd", 18103, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c, false);
            Assert.AreEqual(false, cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarComRegistroTREJaExistente()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015 - 11 - 02), "0001", 18, "abcd", 18103, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c, false);
            Assert.AreEqual(false, cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarComNumeroJaExistente()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015 - 11 - 02), "12345", 18, "abcd", 20102, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c, false);
            Assert.AreEqual(false, cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeTerCargoPrefeitoSeJaTemAlgueDoPartidoComEsseCargo()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015 - 11 - 02), "12345", 1, "abcd", 20102, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c, false);
            Assert.AreEqual(false, cadastrou);
        }

        //[TestMethod]
        //public void CadastrarCandidatoNaoPodeCadastrarComNumeroJaExistente()
        //{
        //    Candidato c = new Candidato("teste", "teste", new DateTime(2015 - 11 - 02), "12345", 18, "abcd", 20102, 1, true);
        //    CandidatoRepositorio cr = new CandidatoRepositorio();
        //    bool cadastrou = cr.Cadastrar(c, false);
        //    Assert.AreEqual(false, cadastrou);
        //}   
    }
}
