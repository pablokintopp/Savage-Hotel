using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savage_Hotel_System.Class
{
    class Funcoes
    {
        public Funcoes()
        {

        }

        public int verificatelefone(String entrada)
        {
            //Verifica Telefone
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 1
            //Se o tamanho da entrada for diferente de 10 retorna 2 (Casas incompletas ou maior que a necessária)
            int tam = entrada.Length;
            for (int i = 0; i < tam; i++)
            {
                if (entrada[i] > 47 && entrada[i] < 58)
                {
                    //cout<<entrada[i]<<endl;
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            if (tam != 10)
            {
                return 2;
            }
            return 0;
        }

        public int verificanome(String entrada)
        {
            //Verifica Nome
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 2 (Tamanho Mínino 1)
            //Caso contrário retorna 1 (caracteres Inválidos)
            int tam = entrada.Length;
            for (int i = 0; i < tam; i++)
            {
                if (((entrada[i] > 64 && entrada[i] < 91) || (entrada[i] > 96 && entrada[i] < 123)) || (entrada[i] == 32))
                {
                    //cout<<entrada[i];
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            if (tam <= 1)
            {
                return 2;
            }
            return 0;
        }

        public int verificacpf(String entrada)
        {
            //Verifica CPF
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 1
            //Se o tamanho da entrada for diferente de 11 retorna 2 (Casas incompletas ou maior que a necessária)
            int tam = entrada.Length;
            for (int i = 0; i < tam; i++)
            {
                if (entrada[i] > 47 && entrada[i] < 58)
                {
                    //cout<<entrada[i]<<endl;
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            if (tam != 11)
            {
                return 2;
            }
            return 0;
        }

        public int verificasalario(String entrada)
        {
            //Verifica Salário
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 1
            //Caso contrário retorna 2 (Tamanho Mínino 1)
            int tam = entrada.Length;
            if (tam<=1)
            {
                return 2;
            }
            for (int i = 0; i < tam; i++)
            {
                if (entrada[i] > 47 && entrada[i] < 58)
                {
                    //cout<<entrada[i]<<endl;
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            return 0;
        }
    }
}
