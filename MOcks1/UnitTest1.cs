using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using Mocks;

namespace MOcks1
{
    [TestClass]
    public class MockTest
    {
        const string JugoMora = "JugoMora";
        const string JugoGuanabana = "JugoGuanabana";
        [TestMethod]
        public void LaOrdenSeLlenaSiHaySuficienteEnLaBodega()
        {
            var bodega = MockRepository.GenerateStub<IBodega>();
            int cantidadInicial = 50;
            bodega.Stub(b => b.Existencia(JugoMora)).Return(cantidadInicial);

            int cantidadPedida = 50;
            Pedido pedido = new Pedido(JugoMora, cantidadPedida);
            pedido.Llenar(bodega);

            Assert.IsTrue(pedido.SeLleno);
            bodega.AssertWasCalled(b => b.ActualizarExistencia(JugoMora, cantidadInicial - cantidadPedida));
        }
    }
}
