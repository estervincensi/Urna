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
            Candidato c = new Candidato("", "teste", new DateTime(2015, 11, 02), "12345", 18, "abcd", 18103, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c);
            Assert.AreEqual(false,cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarComNomePopularEmBranco()
        {
            Candidato c = new Candidato("teste", "", new DateTime(2015, 11, 02), "12345", 18, "abcd", 18103, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c);
            Assert.AreEqual(false, cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarComNomePopularIgualOutroRegistroDaTabela()
        {
            Candidato c = new Candidato("teste", "Pedro II", new DateTime(2015, 11, 02), "12345", 18, "abcd", 18103, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c);
            Assert.AreEqual(false, cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarComRegistroTREJaExistente()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015, 11, 02), "0001", 18, "abcd", 18103, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c);
            Assert.AreEqual(false, cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarComNumeroJaExistente()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015, 11, 02), "12345", 18, "abcd", 20102, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c);
            Assert.AreEqual(false, cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeTerCargoPrefeitoSeJaTemAlgueDoPartidoComEsseCargo()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015, 11, 02), "12345", 1, "abcd", 10103, 1, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c);
            Assert.AreEqual(false, cadastrou);
        }

        [TestMethod]
        public void CadastrarCandidatoNaoPodeCadastrarSeAsEleicoesJaComecaram()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015, 11, 02), "12345", 1, "abcd", 18103, 2, true);
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c);
            Eleicao e = new Eleicao();
            e.IniciarEleicao();
            Assert.AreEqual(false, cadastrou);
            e.TerminarEleicao();
        }

        [TestMethod]
        public void CadastrarCandidatoCadastraCandidato()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015, 11, 02), "12345", 1, null, 18103, 2, true);
            c.IDCandidato = 15;
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Cadastrar(c);
            Assert.AreEqual(true, cadastrou);
        }

        [TestMethod]
        public void EditarCandidatoNaoPodeEditarComNomeCompletoEmBranco()
        {
            Candidato c = new Candidato("", "teste", new DateTime(2015, 11, 02), "12345", 18, "abcd", 18103, 1, true);
            c.IDCandidato = 15;
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool editou = cr.Editar(c);
            Assert.AreEqual(false, editou);
        }

        [TestMethod]
        public void EditarCandidatoNaoPodeEditarComNomePopularEmBranco()
        {
            Candidato c = new Candidato("teste", "", new DateTime(2015, 11, 02), "12345", 18, "abcd", 18103, 1, true);
            c.IDCandidato = 15;
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool editou = cr.Editar(c);
            Assert.AreEqual(false, editou);
        }

        [TestMethod]
        public void EditarCandidatoNaoPodeEditarComNomePopularIgualOutroRegistroDaTabela()
        {
            Candidato c = new Candidato("teste", "Pedro II", new DateTime(2015, 11, 02), "12345", 18, "abcd", 18103, 1, true);
            c.IDCandidato = 15;
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool editou = cr.Editar(c);
            Assert.AreEqual(false, editou);
        }

        [TestMethod]
        public void EditarCandidatoNaoPodeEditarComRegistroTREJaExistente()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015, 11, 02), "0001", 18, "abcd", 18103, 1, true);
            c.IDCandidato = 15;
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool editou = cr.Editar(c);
            Assert.AreEqual(false, editou);
        }

        [TestMethod]
        public void EditarCandidatoNaoPodeEditarComNumeroJaExistente()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015, 11, 02), "12345", 18, "abcd", 20102, 1, true);
            c.IDCandidato = 15;
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool editou = cr.Editar(c);
            Assert.AreEqual(false, editou);
        }

        [TestMethod]
        public void EditarCandidatoNaoPodeTerCargoPrefeitoSeJaTemAlgueDoPartidoComEsseCargo()
        {
            Candidato c = new Candidato("teste", "teste", new DateTime(2015, 11, 02), "12345", 1, "abcd", 20102, 1, true);
            c.IDCandidato = 15;
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool editou = cr.Editar(c);
            Assert.AreEqual(false, editou);
        }


        [TestMethod]
        public void EditarCandidatoEditaCandidato()
        {
            Candidato c = new Candidato("abcdef", "BCDEF", new DateTime(2015, 11, 02), "1234567", 1, "abcd", 1675843, 2, true);
            c.IDCandidato = 15;
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool cadastrou = cr.Editar(c);
            Assert.AreEqual(true, cadastrou);
        }
        [TestMethod]
        public void ExcluirCandidatoNaoPodeExcluirCandidatoComNomeVotoNulo()
        {
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool excluiu = cr.ExcluirPorID(1);
            Assert.AreEqual(false,excluiu);
        }

        [TestMethod]
        public void ExcluirCandidatoNaoPodeExcluirCandidatoComNomeVotoemBranco()
        {
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool excluiu = cr.ExcluirPorID(2);
            Assert.AreEqual(false, excluiu);
        }


        [TestMethod]
        public void ExcluirCandidatoExcluiCandidato()
        {
            CandidatoRepositorio cr = new CandidatoRepositorio();
            bool excluiu = cr.ExcluirPorID(15);
            Assert.AreEqual(true, excluiu);
        }
    }
}
