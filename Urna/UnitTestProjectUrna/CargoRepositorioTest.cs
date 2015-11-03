using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urna;

namespace UnitTestProjectUrna
{
    [TestClass]
    public class CargoRepositorioTest
    {
        [TestMethod]
        public void CadastrarCargo()
        {
            Cargo cargo = new Cargo(6, "Deputado", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool cadastro = cargoRep.AdicionarCargo(cargo);
            Assert.AreEqual(true, cadastro);
        }

        [TestMethod]
        public void DeletarCargo()
        {
            Cargo cargo = new Cargo(100, "Presidente", 'I');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool delete = cargoRep.DeletarCargo(5);
            Assert.AreEqual(true, delete);
        }

        [TestMethod]
        public void AlterarCargoParaInativo()
        {
            Cargo cargo = new Cargo(7, "Rei do Mundo", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool altera = cargoRep.InativarCargo(6);
            Assert.AreEqual(true, altera);
        }

        [TestMethod]
        public void AlterarCargoParaAtivo()
        {
            Cargo cargo = new Cargo(8, "Rei da Galaxia", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool altera = cargoRep.AtivarCargo(6);
            Assert.AreEqual(true, altera);
        }


        [TestMethod]
        public void NaoAlteraCargoPraAtivoComEleicaoAberta()
        {
            Cargo cargo = new Cargo(42, "Sindico", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool altera = cargoRep.AtivarCargo(1);
            Assert.AreEqual(false, altera);
        }

        [TestMethod]
        public void NaoCadastraComNomeVazio()
        {
            Cargo cargo = new Cargo(12, "", 'I');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool cadastrar = cargoRep.AdicionarCargo(cargo);
            Assert.AreEqual(true, cadastrar);
        }

        [TestMethod]
        public void NaoCadastraComNomeNulo()
        {
            Cargo cargo = new Cargo(22, null, 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool cadastrar = cargoRep.AdicionarCargo(cargo);
            Assert.AreEqual(true, cadastrar);
        }
        
    }
}
