namespace NewTalents
{
    public class Calculadora
    {
        private List<string> historico;
        private string data;
        public Calculadora(string data)
        {
            historico = new List<string>();
            this.data = data;
        }

        private int CalculaOperacoes(char op, int[] num)
        {
            if (num.Length < 2) throw new ArgumentException("O array deve conter pelo menos dois números.");
            int res;
            switch (op)
            {
                case '+':
                    res = num[0] + num[1];
                    break;
                case '-':
                    res = num[0] - num[1];
                    break;
                case '*':
                    res = num[0] * num[1];
                    break;
                case '/':
                    {
                        if (num[1] == 0) throw new DivideByZeroException("Não é possível dividir por zero.");
                        res = num[0] / num[1];
                        break;
                    }
                default:
                    throw new ArgumentException("Operador inválido.");
            }

            AdicionaOperacaoNoHistorico(res);
            return res;
        }

        private void AdicionaOperacaoNoHistorico(int res)
        {
            historico.Insert(0, $"Resultado: {res} - data: {data}");
        }

        public int Somar(int num1, int num2)
        {
            return CalculaOperacoes('+', [num1, num2]);
        }
        public int Subtrair(int num1, int num2)
        {
            return CalculaOperacoes('-', [num1, num2]);
        }
        public int Multiplicar(int num1, int num2)
        {
            return CalculaOperacoes('*', [num1, num2]);
        }
        public int Dividir(int num1, int num2)
        {
            return CalculaOperacoes('/', [num1, num2]);
        }

        public List<string> Historico()
        {
            int range = 3;

            if (historico.Count > 3)
            {
                historico.RemoveRange(range, historico.Count - range);
            }
            return historico;
        }
    }
}