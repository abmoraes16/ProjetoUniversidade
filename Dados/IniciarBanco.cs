using System;

namespace ProjetoUniversidade.Dados
{
    public class IniciarBanco
    {
        public static void Inicializar(UniversidadeContexto contexto) { 
            //contexto.Database.EnsureCreated(); //Verifica se o banco já foi criado, caso não, o banco é criado.
            Console.WriteLine("Criação do Banco:" +contexto.Database.EnsureCreated());                      
        }
    }
}