using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Mocks
{
    [TestClass]
    public class OrderStateTest
    {
        const string JugoMora = "JugoMora";
        const string JugoGuanabana = "JugoGuanabana";
        

        [TestMethod]
        public void LaOrdenSeLlenaSiHaySuficienteEnLaBodega()
        {
            Bodega bodega = new Bodega();
            int existenciaJugoMora = 0;
            int cantidadInicial = 50;
            bodega.Agregar(JugoMora, cantidadInicial);

            int cantidadPedida = 50;
            Pedido pedido = new Pedido(JugoMora, cantidadPedida);
            pedido.Llenar(bodega);
           
            Assert.IsTrue(pedido.SeLleno);
            Assert.AreEqual(existenciaJugoMora, bodega.Existencia(JugoMora));
        }

        [TestMethod]
        public void LaOrdenNoSeLlenaSiNoHaySuficienteEnLaBodega()
        {
            Bodega bodega = new Bodega();
            int existenciaJugoMora = 50;
            bodega.Agregar(JugoMora, existenciaJugoMora);

            int cantidadPedido = 51;
            Pedido pedido = new Pedido(JugoMora, cantidadPedido);
            pedido.Llenar(bodega);
         
            Assert.IsFalse(pedido.SeLleno);
            Assert.AreEqual(existenciaJugoMora, bodega.Existencia(JugoMora));
        }
    }
}
