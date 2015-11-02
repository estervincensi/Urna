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
            bool cadastro = cargoRep.AdicionarCargo(cargo, false);
            Assert.AreEqual(true, cadastro);
        }

        [TestMethod]
        public void DeletarCargo()
        {
            Cargo cargo = new Cargo(100, "Presidente", 'I');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool delete = cargoRep.DeletarCargo(5, false);
            Assert.AreEqual(true, delete);
        }

        [TestMethod]
        public void AlterarCargoParaInativo()
        {
            Cargo cargo = new Cargo(7, "Rei do Mundo", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool altera = cargoRep.InativarCargo(6, false);
            Assert.AreEqual(true, altera);
        }

        [TestMethod]
        public void AlterarCargoParaAtivo()
        {
            Cargo cargo = new Cargo(8, "Rei da Galaxia", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool altera = cargoRep.AtivarCargo(6, false);
            Assert.AreEqual(true, altera);
        }

        [TestMethod]
        public void NaoCadastraCargoComEleicaoAberta()
        {
            Cargo cargo = new Cargo(6, "Rei do lol", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool cadastro = cargoRep.AdicionarCargo(cargo, true);
            Assert.AreEqual(false, cadastro);
        }

        [TestMethod]
        public void NaoDeletaCargoComEleicaoAberta()
        {
            Cargo cargo = new Cargo(70, "Rei do lol", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool delete = cargoRep.DeletarCargo(6, true);
            Assert.AreEqual(false, delete);
        }

        [TestMethod]
        public void NaoAlteraCargoParaInativoComEleicaoAberta()
        {
            Cargo cargo = new Cargo(42, "Sindico", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool altera = cargoRep.InativarCargo(1, true);
            Assert.AreEqual(false, altera);

        }

        [TestMethod]
        public void NaoAlteraCargoPraAtivoComEleicaoAberta()
        {
            Cargo cargo = new Cargo(42, "Sindico", 'A');
            CargoRepositorio cargoRep = new CargoRepositorio();
            bool altera = cargoRep.AtivarCargo(1, true);
            Assert.AreEqual(false, altera);
        }
        
    }
}
