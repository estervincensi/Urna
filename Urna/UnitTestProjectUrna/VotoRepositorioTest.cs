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
    public class VotoRepositorioTest
    {

        [TestMethod]
        public void PessoaNaoVotouAinda()
        {
            VotoRepositorio votoRp = new VotoRepositorio();
            bool jaVotou = votoRp.VerificarSeJaVotou("00000000325");

            Assert.IsFalse(jaVotou);
        }


        [TestMethod]
        public void PessoaVota()
        {
            VotoRepositorio votoRp = new VotoRepositorio();
            bool ConseguilVotar = votoRp.Votar("00000000326", 1);

            Assert.IsTrue(ConseguilVotar);
        }


        [TestMethod]
        public void PessoaTentaVotarMasNaoConseguePorqueJaVotou()
        {
            VotoRepositorio votoRp = new VotoRepositorio();
            bool ConseguilVotar = votoRp.Votar("00000000326",1);

            Assert.IsFalse(ConseguilVotar);
        }


    }
}
