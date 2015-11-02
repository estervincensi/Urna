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
    public class UnitTestPartidoRepositorio
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
            ConfigurationManager.AppSettings["App.config"].Clone();

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

    }
}
