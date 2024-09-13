using NewTalents;

namespace NewTalentsTest;

public class UnitTest1
{
    private static string data = "13/09/2024";
    private Calculadora _calculadora = new Calculadora(data);

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 5, 9)]
    public void TesteSomar(int num1, int num2, int resultado)
    {
        int resultadoCalculado = _calculadora.Somar(num1, num2);

        Assert.Equal(resultado, resultadoCalculado);
    }

    [Theory]
    [InlineData(10, 2, 8)]
    [InlineData(15, 5, 10)]
    public void TesteSubtrair(int num1, int num2, int resultado)
    {
        int resultadoCalculado = _calculadora.Subtrair(num1, num2);

        Assert.Equal(resultado, resultadoCalculado);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(4, 5, 20)]
    public void TesteMultiplicar(int num1, int num2, int resultado)
    {
        int resultadoCalculado = _calculadora.Multiplicar(num1, num2);

        Assert.Equal(resultado, resultadoCalculado);
    }

    [Theory]
    [InlineData(6, 2, 3)]
    [InlineData(10, 5, 2)]
    [InlineData(7, 5, 1)]
    public void TesteDividir(int num1, int num2, int resultado)
    {
        var resultadoCalculado = _calculadora.Dividir(num1, num2);
        Assert.Equal(resultado, resultadoCalculado);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        var resultado = Assert.Throws<DivideByZeroException>(() => _calculadora.Dividir(3, 0));
        Assert.Equal("Não é possível dividir por zero.", resultado.Message);
    }

    [Fact]
    public void TestarHistorico()
    {
        _calculadora.Somar(7, 1);
        _calculadora.Subtrair(9, 2);
        _calculadora.Multiplicar(3, 2);
        _calculadora.Dividir(6, 5);

        var lista = _calculadora.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}