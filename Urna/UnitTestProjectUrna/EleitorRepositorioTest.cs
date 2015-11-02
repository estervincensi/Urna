using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Urna;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace UnitTestProjectUrna
{
  
    [TestClass]
    public class EleitorRepositorioTest
    {

        [TestMethod]
        public void PessoaNaoVotouAinda()
        {
            EleitorRepositorio votoRp = new EleitorRepositorio();
            bool jaVotou = votoRp.VerificarSeJaVotou("00000000324");

            Assert.IsFalse(jaVotou);
        }


        [TestMethod]
        public void PessoaVota()
        {
            EleitorRepositorio votoRp = new EleitorRepositorio();
            bool ConseguilVotar = votoRp.Votar("00000000325", "0001");

            Assert.IsTrue(ConseguilVotar);
        }


        [TestMethod]
        public void PessoaTentaVotarMasNaoConseguePorqueJaVotou()
        {
            EleitorRepositorio votoRp = new EleitorRepositorio();
            bool ConseguilVotar = votoRp.Votar("00000000326", "0001");

            Assert.IsFalse(ConseguilVotar);
        }


    }
}
