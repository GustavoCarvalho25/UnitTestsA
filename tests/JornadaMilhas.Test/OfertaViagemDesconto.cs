using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test
{
    public class OfertaViagemDesconto
    {
        [Fact]
        public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
        {
            //arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 5), new DateTime(2024, 2, 1));
            double precoInicial = 100.0;
            double desconto = 10.0;
            double precoAtualizado = precoInicial - desconto;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoInicial);

            //act
            oferta.Desconto = desconto;

            //assert
            Assert.Equal(precoAtualizado, oferta.Preco);
        }

        [Theory]
        [InlineData(120,5)]
        [InlineData(100, 5)]
        public void RetornaDescontoMaximoQuandoDescontoMaiorOuIgualAoPreco(double desconto, double precoAtualizado)
        {
            //arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 5), new DateTime(2024, 2, 1));
            double precoInicial = 100.0;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoInicial);

            //act
            oferta.Desconto = desconto;

            //assert
            Assert.Equal(precoAtualizado, oferta.Preco, 0.001);
        }

        [Fact]
        public void RetornaValorOriginalQuandoDescontoForNegativo()
        {
            //arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 5), new DateTime(2024, 2, 1));
            double precoInicial = 100.0;
            double desconto = -50.0;
            double precoAtualizado = precoInicial;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoInicial);

            //act
            oferta.Desconto = desconto;

            //assert
            Assert.Equal(precoAtualizado, oferta.Preco, 0.001);
        }
    }
}
