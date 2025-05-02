namespace EFex1
{
   public class ConsoleHelper
    {
        public T LerValor<T>(string mensagem)    // Método genérico para ler valores 
        {
            while (true)
            {
                Console.Write(mensagem);
                string? entrada = Console.ReadLine();

                try
                {
                    if (entrada is null)
                    {
                        Console.WriteLine($"Entrada inválida. Por favor, digite um valor válido.");
                        continue;
                    }

                    var valorConvertido = (T)Convert.ChangeType(entrada, typeof(T));
                    return valorConvertido;
                }
                catch
                {
                    Console.WriteLine($"Entrada inválida. Por favor, digite um valor válido.");
                }
            }
        }
    }
}