using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Urna;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace UnitTestProjectUrna
{
    [TestClass]
    public class PartidoRepositorioTest
    {
        [TestMethod]
        public void PartidoNaoAtendeAosRequisitosPorTerNomeNull()
        {
            Partido partido = new Partido(2,null, "MNY" , "nao faremos nada");
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool atendeAosRequi = reposi.AtendeAosRequisitos(partido);

            Assert.IsFalse(atendeAosRequi);
            
        }


        [TestMethod]
        public void PartidoNaoAtendeAosRequisitosPorTerSiglaNull()
        {
            Partido partido = new Partido(2, "stolers", null, "nao faremos nada");
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool atendeAosRequi = reposi.AtendeAosRequisitos(partido);

            Assert.IsFalse(atendeAosRequi);

        }


        [TestMethod]
        public void PartidoNaoAtendeAosRequisitosPorTerSiglaVazia()
        {
            Partido partido = new Partido(2, "stolers", "", "nao faremos nada");
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool atendeAosRequi = reposi.AtendeAosRequisitos(partido);

            Assert.IsFalse(atendeAosRequi);

        }


        [TestMethod]
        public void PartidoNaoAtendeAosRequisitosPorTerNomeVazio()
        {
            Partido partido = new Partido(2, "", "MNY", "nao faremos nada");
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool atendeAosRequi = reposi.AtendeAosRequisitos(partido);

            Assert.IsFalse(atendeAosRequi);

        }



        [TestMethod]
        public void PartidoNaoAtendeAosRequisitosPorTerSloganVazio()
        {
            Partido partido = new Partido(2, "stolers", "MNY", "");
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool atendeAosRequi = reposi.AtendeAosRequisitos(partido);

            Assert.IsFalse(atendeAosRequi);

        }


        [TestMethod]
        public void PartidoNaoAtendeAosRequisitosPorTerSloganNull()
        {
            Partido partido = new Partido(2, "stolers", "MNY", null);
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool atendeAosRequi = reposi.AtendeAosRequisitos(partido);

            Assert.IsFalse(atendeAosRequi);

        }


        [TestMethod]
        public void PartidoJaExisteNoBanco()
        {

            Partido partido = new Partido(1, "Tribunal Regional Eleitoral", "TRE", "Ética em primeiro lugar");
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool jaExiste = reposi.JaExisteNoBanco(partido);

            Assert.IsTrue(jaExiste);

        }


        [TestMethod]
        public void PartidoNaoExisteNoBanco()
        {
            Partido partido = new Partido(1, "partido do software", "PDS", "Café em primeiro lugar");
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool jaExiste = reposi.JaExisteNoBanco(partido);

            Assert.IsFalse(jaExiste);

        }


        [TestMethod]
        public void IdDoPartidoExisteNoBanco()
        {
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool existe = reposi.IdExisteNoBanco(1);

            Assert.IsTrue(existe);

        }


        [TestMethod]
        public void IdDoPartidoNaoExisteNoBanco()
        {
            PartidoRepositorio reposi = new PartidoRepositorio();
            bool existe = reposi.IdExisteNoBanco(5515451);

            Assert.IsFalse(existe);

        }

        [TestMethod]
        public void CadastrandoUmpartidoNoBanco()
        {
            Partido partido = new Partido(5, "partido do software", "PDS", "Café em primeiro lugar");
            PartidoRepositorio reposi = new PartidoRepositorio();
            reposi.CadastrarNovoPartido(partido);

            bool iDExistenoBanco = reposi.IdExisteNoBanco(5);

            Assert.IsTrue(iDExistenoBanco);

        }


        [TestMethod]
        public void EditandoUmPartido()
        {
            Partido partido = new Partido(5, "Associação brasileira de software", "ABDS", "Café em primeiro lugar e salgado em Segundo");
            PartidoRepositorio reposi = new PartidoRepositorio();
            reposi.EditarPartido(partido);

                                        //este metodo verifica se o nome ou a sigla estão cadastradas no banco
            bool partidoExisteNoBanco = reposi.JaExisteNoBanco(partido);

            Assert.IsTrue(partidoExisteNoBanco);

        }



        [TestMethod]
        public void DeletaUmPartidoDoBanco()
        {
            Partido partido = new Partido(5, "Associação brasileira de software", "ABDS", "Café em primeiro lugar e salgado em Segundo");
            PartidoRepositorio reposi = new PartidoRepositorio();
            reposi.ExcluirPartido(5);

            bool iDExistenoBanco = reposi.IdExisteNoBanco(5);

            Assert.IsFalse(iDExistenoBanco);

        }

    }
}
